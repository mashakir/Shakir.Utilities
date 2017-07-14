using System;

namespace Shakir.Utilities.Retrier.Interface
{
    public interface IRetrier<TResult>
    {
        #region Method

        TResult TryWithDelay(Func<TResult> func, int maxRetries, int delayInMilliseconds);
        #endregion
    }
}
