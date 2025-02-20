using System;
using System.Timers;

namespace JGEmulator
{
    public class Clock
    {
        private readonly System.Timers.Timer _timer;
        private bool _tick;
        private readonly Computer _computer;

        public event Action OnTick;
        public event Action OnTock;

        public Clock(int interval, Computer computer)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += OnTimedEvent;
            _tick = false; // Start with a tock
            _computer = computer;
            _computer.DisplayMessage("CL - Clock created.");
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void SetSpeed(int interval)
        {
            _timer.Interval = interval;
            _computer.DisplayMessage($"CL - Clock speed set to {interval} ms.");
        }

        public void Step()
        {
            if (_tick)
            {
                _computer.DisplayMessage($"    CL - Clock Tick (Write Signal)");
                OnTick?.Invoke();
            }
            else
            {
                _computer.DisplayMessage($"    CL - Clock Tock (Control Signals)");
                OnTock?.Invoke();
            }
            _tick = !_tick;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Step(); // Reuse Step method for timed events
        }
    }
}
