using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Taravask.TrafficLights
{
    public class TrafficLightOptionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI optionText;
        [SerializeField] private Button optionButton;

        public void SetOption(string trafficLightsCaption, Action<string> onButtonClickedAction)
        {
            optionText.text = trafficLightsCaption;
            optionButton.onClick.AddListener(() => onButtonClickedAction(trafficLightsCaption));
        }
    }
}