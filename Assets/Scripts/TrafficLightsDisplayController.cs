using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Taravask.TrafficLights
{
    public class TrafficLightsDisplayController : IUpdatable, IDisposable
    {
        public struct Context
        {
            public TrafficLightsConfigViewPair TrafficLightsConfigViewPair { get; }
            public Transform MainCanvas { get; }
            public TrafficLightsDisplayView TrafficLightsDisplayViewPrefab { get; }
            public Action BackButtonClickedAction { get; }

            public Context(TrafficLightsConfigViewPair trafficLightsConfigViewPair, Transform mainCanvas, TrafficLightsDisplayView trafficLightsDisplayViewPrefab,
                Action backButtonClickedAction)
            {
                TrafficLightsConfigViewPair = trafficLightsConfigViewPair;
                TrafficLightsDisplayViewPrefab = trafficLightsDisplayViewPrefab;
                MainCanvas = mainCanvas;
                BackButtonClickedAction = backButtonClickedAction;
            }
        }
        
        private readonly Context _context;
        private readonly TrafficLightsDisplayView _view;
        private readonly StateSwitchTimer _switchTimer;
        private TrafficLightsController _trafficLightsController;

        public TrafficLightsDisplayController(Context context)
        {
            _context = context;
            
            _view = Object.Instantiate(context.TrafficLightsDisplayViewPrefab, _context.MainCanvas);
            _view.BackButton.onClick.AddListener(() => _context.BackButtonClickedAction());
            _switchTimer = new StateSwitchTimer();
            Show();
        }
        
        public void OuterUpdate(float deltaTime)
        {
            _switchTimer.OuterUpdate(deltaTime);
        }

        public void Dispose()
        {
            Object.Destroy(_view.gameObject);
            _switchTimer.Dispose();
            _trafficLightsController.Dispose();
        }

        private void Show()
        {
            TrafficLightsController.Context trafficLightsControllerContext =
                new TrafficLightsController.Context(_context.TrafficLightsConfigViewPair, _context.MainCanvas);
            _trafficLightsController = new TrafficLightsController(trafficLightsControllerContext);
            _view.CurrentStateName.text = _trafficLightsController.CurrentStateName;
            _switchTimer.OnIntervalEnded += Switch;
        }

        private void Switch()
        {
            _trafficLightsController.Switch();
            _view.CurrentStateName.text = _trafficLightsController.CurrentStateName;
        }
    }
}