namespace Turbo.plugins.patrick.util.executors
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

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

            new Thread(action.Invoke).Start();
        }
    }
}