namespace Turbo.plugins.patrick.util.executors
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using logger;

    public class ThreadedExecutor
    {
        private readonly Dictionary<string, long> identifierToExecutionTime = new Dictionary<string, long>();

        public void Execute(Action action, string identifier, long minimumTimeElapsed)
        {
            var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            
            if (!identifierToExecutionTime.ContainsKey(identifier))
                identifierToExecutionTime.Add(identifier, now);
            else
            {
                var lastExecutionTime = identifierToExecutionTime[identifier];
                if (now - lastExecutionTime < minimumTimeElapsed)
                    return;

                identifierToExecutionTime[identifier] = now;
            }

            new Thread(() => ExecuteWithErrorHandling(action)).Start();
        }

        private static void ExecuteWithErrorHandling(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Logger.error("ThreadedExecutor execution error: " + e);
            }
        }
    }
}