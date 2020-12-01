using UnityEngine;

namespace Taravask.TrafficLights
{
    public class SingleLightWorldView : AbstractSingleLightView
    {
        [SerializeField] private MeshRenderer lightMesh;

        public override void Colorize(LightColorConfig lightConfig)
        {
            lightMesh.material.color = lightConfig.ColorAppearance;
        }

        public override void TurnOn()
        {
            lightMesh.enabled = true;
        }
        
        public override void TurnOff()
        {
            lightMesh.enabled = false;
        }
    }
}