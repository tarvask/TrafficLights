using System;
using System.Collections.Generic;
using UnityEngine;

namespace Taravask.TrafficLights
{
    public class TrafficLightsSelectorView : MonoBehaviour
    {
        [SerializeField] private TrafficLightOptionView trafficLightOptionPrefab;
        [SerializeField] private Transform optionsRootTransform;

        private List<TrafficLightOptionView> _trafficLightsOptions;

        public void Init(TrafficLightsPoolConfig trafficLightsPool, Action<string> onOptionSelectedAction)
        {
            _trafficLightsOptions = new List<TrafficLightOptionView>();
            
            foreach (TrafficLightsConfigViewPair trafficLightConfigViewPair in trafficLightsPool.AvailableTrafficLights)
            {
                TrafficLightOptionView newOption = CreateOption(trafficLightConfigViewPair, onOptionSelectedAction);
                _trafficLightsOptions.Add(newOption);
            }
        }

        private TrafficLightOptionView CreateOption(TrafficLightsConfigViewPair trafficLightConfigViewPair, Action<string> onOptionSelectedAction)
        {
            TrafficLightOptionView newOption = Instantiate(trafficLightOptionPrefab, optionsRootTransform);
            newOption.SetOption(trafficLightConfigViewPair.Config.Caption, onOptionSelectedAction);

            return newOption;
        }
    }
}