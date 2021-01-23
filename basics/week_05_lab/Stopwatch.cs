using System;

namespace week_05_lab
{
    class Stopwatch
    {
        private DateTime start;
        private DateTime stop;
        private bool started = false;
        private double duration;

        public void Start()
        {
            if (started) throw new InvalidOperationException("Already started");
            this.start = DateTime.Now;
            this.started = true;
        }

        public void Stop()
        {
            if (!started) throw new InvalidOperationException("Has not started");
            this.stop = DateTime.Now;
            this.started = false;
            this.duration = stop.Subtract(start).TotalMilliseconds / 1000;
            Console.WriteLine(duration.ToString("\t#.000"));
        }

    }
}
