using UnityEngine;

namespace Taravask.TrafficLights
{
    [CreateAssetMenu(menuName = "Configs/TrafficLights Pool", fileName = "NewPool")]
    public class TrafficLightsPoolConfig : ScriptableObject
    {
        [SerializeField] private TrafficLightsConfigViewPair[] availableTrafficLights;
        
        public TrafficLightsConfigViewPair[] AvailableTrafficLights => availableTrafficLights;
    }
}