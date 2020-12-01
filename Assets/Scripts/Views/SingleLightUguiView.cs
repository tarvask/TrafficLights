using UnityEngine;
using UnityEngine.UI;

namespace Taravask.TrafficLights
{
    public class SingleLightUguiView : AbstractSingleLightView
    {
        [SerializeField] private Image lightImage;

        public override void Colorize(LightColorConfig lightConfig)
        {
            lightImage.color = lightConfig.ColorAppearance;
        }

        public override void TurnOn()
        {
            lightImage.enabled = true;
        }
        
        public override void TurnOff()
        {
            lightImage.enabled = false;
        }
    }
}
