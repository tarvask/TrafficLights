using UnityEngine;

namespace Taravask.TrafficLights
{
    public abstract class AbstractSingleLightView : MonoBehaviour, IColorizable, ISwitchable
    {
        public abstract void Colorize(LightColorConfig lightConfig);
        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}