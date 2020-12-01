using System;

namespace Taravask.TrafficLights
{
    public class StateSwitchTimer : IUpdatable, IDisposable
    {
        private const float SwitchInterval = 2f;
        private float _currentInterval;

        public event Action OnIntervalEnded;
        
        public void OuterUpdate(float deltaTime)
        {
            _currentInterval += deltaTime;

            if (_currentInterval >= SwitchInterval)
            {
                _currentInterval = 0;
                OnIntervalEnded?.Invoke();
            }
        }
        
        public void Dispose()
        {
            OnIntervalEnded = null;
        }
    }
}