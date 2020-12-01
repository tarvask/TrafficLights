using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Taravask.TrafficLights
{
    [Serializable]
    public class LightTransitionConfig
    {
        [SerializeField] private LightColorRulesConfig targetState;
        [FormerlySerializedAs("switchOffOnEnter")] [SerializeField] private bool switchOffCurrentStateOnEnter;
        
        public LightColorRulesConfig TargetState => targetState;
        public bool SwitchOffCurrentStateOnEnter => switchOffCurrentStateOnEnter;
    }
}