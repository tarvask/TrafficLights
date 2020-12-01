using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Taravask.TrafficLights
{
    public class TrafficLightsController : IDisposable
    {
        public struct Context
        {
            public TrafficLightsConfigViewPair TrafficLightsConfigViewPair { get; }
            public Transform MainCanvas { get; }

            public Context(TrafficLightsConfigViewPair trafficLightsConfigViewPair, Transform mainCanvas)
            {
                TrafficLightsConfigViewPair = trafficLightsConfigViewPair;
                MainCanvas = mainCanvas;
            }
        }

        private readonly Context _context;
        private readonly TrafficLightsView _view;
        private readonly Dictionary<LightColorRulesConfig, AbstractSingleLightView> _rulesAndViews;
        private LightColorRulesConfig _currentState;
        private LightColorRulesConfig _previousState;

        public string CurrentStateName => _currentState.LightSettings.ColorName;

        public TrafficLightsController(Context context)
        {
            _context = context;

            _view = Object.Instantiate(context.TrafficLightsConfigViewPair.View, _context.MainCanvas);
            _rulesAndViews = new Dictionary<LightColorRulesConfig, AbstractSingleLightView>(_view.Lights.Length);

            for (int i = 0; i < _view.Lights.Length; i++)
            {
                _view.Lights[i].Colorize(_context.TrafficLightsConfigViewPair.Config.LightsWithRules[i].LightSettings);
                _rulesAndViews.Add(_context.TrafficLightsConfigViewPair.Config.LightsWithRules[i], _view.Lights[i]);
            }

            Launch();
        }

        public void Dispose()
        {
            Object.Destroy(_view.gameObject);
            _rulesAndViews.Clear();
            _currentState = null;
            _previousState = null;
        }

        private void Launch()
        {
            ChangeState(_context.TrafficLightsConfigViewPair.Config.LightsWithRules[0]);
        }

        private void ChangeState(LightColorRulesConfig newState, LightTransitionConfig transition = null)
        {
            foreach (var t in _view.Lights)
                t.TurnOff();

            if (transition != null && !transition.SwitchOffCurrentStateOnEnter)
                _rulesAndViews[_currentState].TurnOn();
            
            _rulesAndViews[newState].TurnOn();
            _previousState = _currentState;
            _currentState = newState;
        }

        public void Switch()
        {
            LightTransitionConfig nextTransition = GetNextTransition();

            if (nextTransition != null)
                ChangeState(nextTransition.TargetState, nextTransition);
        }

        private LightTransitionConfig GetNextTransition()
        {
            if (_currentState.PossibleTransitions.Length > 1)
            {
                foreach (LightTransitionConfig transition in _currentState.PossibleTransitions)
                {
                    if (transition.TargetState != _previousState)
                    {
                        return transition;
                    }
                }
                
                throw new ArgumentException();
            }
            
            if (_currentState.PossibleTransitions.Length == 1)
            {
                return _currentState.PossibleTransitions[0];
            }

            throw new ArgumentException();
        }
    }
}