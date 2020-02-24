using System;
using System.Threading.Tasks;

namespace Firewatch.Common
{
    public static class TaskExtensions
    {
        public static async Task ContinueWith<T>(this Task<T> task, Action<T> action)
        {
            //return await task.ContinueWith(t => action(t.Result));
        }
    }
}
