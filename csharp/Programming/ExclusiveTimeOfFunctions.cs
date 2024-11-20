using System;

namespace Programming;

public class ExclusiveTimeOfFunctions
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        int[] res = new int[n];
        var stack = new Stack<Function>();

        foreach (string logStr in logs)
        {
            string[] log = logStr.Split(":");
            string logType = log[1];
            if (logType == "start")
            {
                var newFunc = new Function(log[0], log[2]);
                if (stack.Count > 0)
                {
                    var runningFunc = stack.Peek();
                    runningFunc.Duration += newFunc.Start - runningFunc.Start;
                }

                stack.Push(newFunc);
            }
            else
            {
                var runningFunc = stack.Pop();
                int end = int.Parse(log[2]);
                runningFunc.Duration += (end - runningFunc.Start + 1);
                res[runningFunc.Id] += runningFunc.Duration;

                if (stack.Count > 0)
                {
                    var resumingFunc = stack.Peek();
                    resumingFunc.Start = end + 1;
                }
            }
        }

        return res;
    }

    class Function
    {
        public int Id { get; }
        public int Start { get; set; }
        public int Duration { get; set; }

        public Function(string id, string start)
        {
            Id = int.Parse(id);
            Start = int.Parse(start);
        }
    }
}
