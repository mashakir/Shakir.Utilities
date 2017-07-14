using System;
using System.Threading;
using System.Threading.Tasks;
using Shakir.Utilities.Wrappers.Interfaces;

namespace Shakir.Utilities.Wrappers
{
    public class TaskWrapper : ITaskWrapper
    {
        #region Method
        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        public Task StartNew(Action action) => Task.Factory.StartNew(action);

        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <param name="token">An instance of CancellationToken.</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        public Task StartNew(Action action, CancellationToken token) => Task.Factory.StartNew(action, token);

        /// <summary>
        /// Returns a task after Creating and starting a new threading task.
        /// </summary>
        /// <param name="action">Name of delagate action</param>
        /// <param name="state">An object of containing data to be used by delegate action</param>
        /// <returns>Returns a task after Creating and starting a new threading task.</returns>
        public Task StartNew(Action<object> action, object state) => Task.Factory.StartNew(action, state);

        /// <summary>
        /// Returns an instance of CancellationToken.
        /// </summary>
        /// <returns>Returns an instance of CancellationToken.</returns>
        public CancellationToken GetCancellationToken() => new CancellationTokenSource().Token;

        #endregion
    }
}
