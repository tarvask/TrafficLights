using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Taravask.TrafficLights
{
    public class TrafficLightsSelectorController : IDisposable
    {
        public struct Context
        {
            public TrafficLightsPoolConfig AvailableTrafficLights { get; }
            public Transform MainCanvas { get; }
            public TrafficLightsSelectorView TrafficLightsSelectorViewPrefab { get; }
            public Action<string> OptionSelectedAction { get; }

            public Context(TrafficLightsPoolConfig availableTrafficLights, Transform mainCanvas, TrafficLightsSelectorView trafficLightsSelectorViewPrefab,
                Action<string> optionSelectedAction)
            {
                AvailableTrafficLights = availableTrafficLights;
                MainCanvas = mainCanvas;
                TrafficLightsSelectorViewPrefab = trafficLightsSelectorViewPrefab;
                OptionSelectedAction = optionSelectedAction;
            }
        }

        private readonly Context _context;
        private readonly TrafficLightsSelectorView _view;

        public TrafficLightsSelectorController(Context context)
        {
            _context = context;

            _view = Object.Instantiate(_context.TrafficLightsSelectorViewPrefab, _context.MainCanvas);
            _view.Init(_context.AvailableTrafficLights, _context.OptionSelectedAction);
        }

        public void Close()
        {
            _view.gameObject.SetActive(false);
        }
        
        public void Show()
        {
            _view.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}