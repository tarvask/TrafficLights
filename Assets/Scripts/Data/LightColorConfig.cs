using UnityEngine;

namespace Taravask.TrafficLights
{
    [CreateAssetMenu(menuName = "Configs/LightColor", fileName = "NewColor")]
    public class LightColorConfig : ScriptableObject
    {
        [SerializeField] private LightColorType colorType;
        [SerializeField] private Color colorAppearance;
        [SerializeField] private string colorName;

        public LightColorType ColorType => colorType;
        public Color ColorAppearance => colorAppearance;
        public string ColorName => colorName;
    }
}
