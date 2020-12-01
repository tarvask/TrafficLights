using UnityEngine;

namespace Taravask.TrafficLights
{
    public class TrafficLightsView : MonoBehaviour
    {
        [SerializeField] private AbstractSingleLightView[] lights;

        public AbstractSingleLightView[] Lights => lights;
    }
}