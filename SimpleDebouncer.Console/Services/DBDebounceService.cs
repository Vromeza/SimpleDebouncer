using SimpleDebouncer.Core;

namespace SimpleDebouncer.Console.Services
{
    /// <summary>
    /// Concrete implementation of <see cref="IDebounceService"/> utilizing the database as means of persistence.
    /// </summary>
    public class DBDebounceService : IDebounceService
    {
        #region Public Constructors

        public DBDebounceService()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Uses the debounce mechanism to acquire a debounce entry. Throws a <see cref="DebounceException"/> if it fails to acquire the debounce entry.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="signature"></param>
        /// <param name="requestor"></param>
        /// <exception cref="DebounceException">Thrown when the debounce entry fails to be acquired</exception>
        public void Debounce(string scope, string signature, string requestor)
        {
            bool debounceAcquired = AcquireDebounceEntry(scope, signature, requestor);
            if (!debounceAcquired) {
                throw new DebounceException($"Debounced entry! - Scope: {scope}, Signature: {signature}, Requestor:{requestor}");
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Returns true/false on whether the debounce entry was acquired or not
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="signature"></param>
        /// <param name="requestor"></param>
        /// <returns></returns>
        private bool AcquireDebounceEntry(string scope, string signature, string requestor)
        {
            //Add debounce entry to db
            //If it fails because of constraint, return false;
            return false;
        }

        #endregion Private Methods
    }
}