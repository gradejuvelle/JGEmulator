using System;
using System.Timers;

namespace JGEmulator
{
    public class Clock
    {
        private readonly System.Timers.Timer _timer;
        private bool _tick;

        public event Action OnTick;
        public event Action OnTock;
        private Computer _thiscomputer;

        public Clock(int interval,Computer computer)
        {
            _thiscomputer = computer;
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += OnTimedEvent;
            _tick = true; // Start with a tick
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Clock initialized.", "CLK"));


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
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Clock speed set to {interval} ms.", "CLK"));
        }

        public void Step()
        {


            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "***** Clock Tick", "CLK"));

            OnTick?.Invoke();


           _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Clock Tock", "CLK"));

            OnTock?.Invoke();

            }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Step(); // Reuse Step method for timed events
        }
    }
}
