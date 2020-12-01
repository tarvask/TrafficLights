using UnityEngine;

namespace Taravask.TrafficLights
{
    [CreateAssetMenu(menuName = "Configs/TrafficLight", fileName = "NewTrafficLight")]
    public class TrafficLightsConfig : ScriptableObject
    {
        [SerializeField] private string caption;
        [SerializeField] private LightColorRulesConfig[] lightsWithRules;

        public string Caption => caption;
        public LightColorRulesConfig[] LightsWithRules => lightsWithRules;
    }
}
