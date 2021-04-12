namespace Turbo.plugins.patrick.util.executors
{
    using System;
    using System.Threading;

    public class TimedRetryExecutor
    {
        private int elapsed;

        private bool success;

        private readonly int intervalMs;

        private readonly int maxTimeMs;

        private readonly Func<bool> condition;

        public TimedRetryExecutor(int maxTimeMs, int intervalMs, Func<bool> condition)
        {
            this.intervalMs = intervalMs;
            this.maxTimeMs = maxTimeMs;
            this.condition = condition;
        }

        public bool Invoke()
        {
            while (!success && elapsed < maxTimeMs)
            {
                Execute();
                Thread.Sleep(intervalMs);
            }
            
            return success;
        }
        
        private void Execute()
        {
            success = condition.Invoke();
            elapsed += intervalMs;
        }
    }
}