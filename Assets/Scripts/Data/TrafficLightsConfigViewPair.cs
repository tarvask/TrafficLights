using System;
using UnityEngine;

namespace Taravask.TrafficLights
{
    [Serializable]
    public class TrafficLightsConfigViewPair
    {
        [SerializeField] private TrafficLightsConfig config;
        [SerializeField] private TrafficLightsView view;

        public TrafficLightsConfig Config => config;
        public TrafficLightsView View => view;
    }
}