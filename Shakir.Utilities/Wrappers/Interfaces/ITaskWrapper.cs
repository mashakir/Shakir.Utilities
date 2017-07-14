using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shakir.Utilities.Wrappers.Interfaces
{
    public interface ITaskWrapper
    {
        #region Method

        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        Task StartNew(Action action);

        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <param name="token">An instance of CancellationToken.</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        Task StartNew(Action action, CancellationToken token);

        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <param name="state">An object of containing data to be used by delegate action</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        Task StartNew(Action<object> action, object state);

        /// <summary>
        /// Returns an instance of CancellationToken.
        /// </summary>
        /// <returns>Returns an instance of CancellationToken.</returns>
        CancellationToken GetCancellationToken();

        #endregion
    }
}
