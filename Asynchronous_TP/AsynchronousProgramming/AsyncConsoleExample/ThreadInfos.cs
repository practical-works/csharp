using System.Threading;

namespace AsyncConsoleExample
{
    public static class ThreadInfos
    {
        public static string CurrentThreadInfos
        {
            get
            {
                return string.Format("{0} Thread ({1})", 
                     Thread.CurrentThread.ThreadState, Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
