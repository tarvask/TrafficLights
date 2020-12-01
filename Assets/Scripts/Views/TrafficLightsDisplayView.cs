using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Taravask.TrafficLights
{
    public class TrafficLightsDisplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentStateName;
        [SerializeField] private Transform content;
        [SerializeField] private Button backButton;

        public TextMeshProUGUI CurrentStateName => currentStateName;
        public Transform Content => content;
        public Button BackButton => backButton;
    }
}