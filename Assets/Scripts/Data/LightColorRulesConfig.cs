
using UnityEngine;

namespace Taravask.TrafficLights
{
    [CreateAssetMenu(menuName = "Configs/RuleForColor", fileName = "NewRule")]
    public class LightColorRulesConfig : ScriptableObject
    {
        [SerializeField] private LightColorConfig lightSettings;
        [SerializeField] private LightTransitionConfig[] possibleTransitions;
        
        public LightColorConfig LightSettings => lightSettings;
        public LightTransitionConfig[] PossibleTransitions => possibleTransitions;
    }
}