using System;
using UnityEngine;

namespace Taravask.TrafficLights
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private TrafficLightsPoolConfig lightsPoolConfig;
        [SerializeField] private Transform mainCanvas;
        [SerializeField] private TrafficLightsSelectorView selectorViewPrefab;
        [SerializeField] private TrafficLightsDisplayView displayViewPrefab;

        private TrafficLightsSelectorController _trafficLightsSelectorController;
        private TrafficLightsDisplayController _trafficLightsDisplayController;

        private void Awake()
        {
            TrafficLightsSelectorController.Context trafficLightsSelectorControllerContext =
                new TrafficLightsSelectorController.Context(lightsPoolConfig, mainCanvas, selectorViewPrefab,
                    OnTrafficLightsOptionSelectedEventHandler);
            _trafficLightsSelectorController = new TrafficLightsSelectorController(trafficLightsSelectorControllerContext);
        }

        private void Update()
        {
            _trafficLightsDisplayController?.OuterUpdate(Time.deltaTime);
        }

        private void OnTrafficLightsOptionSelectedEventHandler(string option)
        {
            _trafficLightsSelectorController.Close();

            TrafficLightsConfigViewPair selectedPair = GetConfigViewPairByOption(option);
            TrafficLightsDisplayController.Context trafficLightsDisplayControllerContext =
                new TrafficLightsDisplayController.Context(selectedPair, mainCanvas, displayViewPrefab, OnTrafficLightsDisplayClosedEventHandler);
            _trafficLightsDisplayController = new TrafficLightsDisplayController(trafficLightsDisplayControllerContext);
        }

        private void OnTrafficLightsDisplayClosedEventHandler()
        {
            _trafficLightsDisplayController.Dispose();
            _trafficLightsSelectorController.Show();
        }

        private TrafficLightsConfigViewPair GetConfigViewPairByOption(string option)
        {
            foreach (TrafficLightsConfigViewPair pair in lightsPoolConfig.AvailableTrafficLights)
            {
                if (String.CompareOrdinal(pair.Config.Caption, option) == 0)
                    return pair;
            }
            
            throw new ArgumentException();
        }

        private void OnApplicationQuit()
        {
            _trafficLightsSelectorController.Dispose();
        }
    }
}