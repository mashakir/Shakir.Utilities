using System;
using System.Threading;
using Shakir.Utilities.Retrier.Interface;

namespace Shakir.Utilities.Retrier
{
    public class Retrier<TResult> : IRetrier<TResult>
    {
        public TResult TryWithDelay(Func<TResult> func, int maxRetries, int delayInMilliseconds)
        {
            var returnValue = default(TResult);
            var numTries = 0;
            var succeeded = false;
            while (numTries < maxRetries)
            {
                try
                {
                    returnValue = func();
                    succeeded = true;
                }
                catch (Exception)
                { 
                        throw;
                }
                finally
                {
                    numTries++;
                }
                if (succeeded)
                    return returnValue;

                Thread.Sleep(delayInMilliseconds);
            }
            return default(TResult);
        }
    }
}
