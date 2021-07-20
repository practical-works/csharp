using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsoleExample
{
    class AsyncRepeater
    {
        public int Interval { get; set; }
        public bool IsOn { get; private set; }
        public Action ActionToRepeat { get; set; }
        public Action RepetitionLoopFunction { get; private set; }
        public AsyncRepeater(int interval = 1000, Action actionToRepeat = null)
        {
            Interval = interval;
            IsOn = false;
            ActionToRepeat = actionToRepeat;
            RepetitionLoopFunction = delegate()
            {
                while (IsOn)
                {
                    ActionToRepeat();
                    Thread.Sleep(Interval);
                }
            };
        }

        public void Start(Action actionAtStart = null)
        {
            IsOn = true;
            if (actionAtStart != null) actionAtStart();
            RepetitionLoopFunction.BeginInvoke(EndRepetitionLoop, RepetitionLoopFunction);
        }
        private void EndRepetitionLoop(IAsyncResult asynResult)
        {
            ((Action)asynResult.AsyncState).EndInvoke(asynResult);
        }
        public void Start2(Action actionAtStart = null)
        {
            IsOn = true;
            if (actionAtStart != null) actionAtStart();
            Task repetitionLoopTask = new Task(RepetitionLoopFunction);
            repetitionLoopTask.Start();
        }
        public void Stop(Action actionAtStop = null)
        {
            IsOn = false;
            if (actionAtStop != null) actionAtStop();
        }
    }
}
