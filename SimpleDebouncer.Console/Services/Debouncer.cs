using SimpleDebouncer.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDebouncer.Console.Services
{
    /// <summary>
    /// Wrapper around a <see cref="IDebounceService"/>. Contains additional functions for wrapping the debounce mechanism around an <see cref="Action"/> or <see cref="Func{TResult}"/>
    /// This class should be the prefered use for consuming debouncing functionality
    /// Currently utilizes <see cref="DBDebounceService"/> implementation for debouncing functionality
    /// </summary>
    public class Debouncer
    {
        #region Private Fields

        private readonly IDebounceService _debounceService;

        #endregion Private Fields

        #region Public Constructors

        public Debouncer(IDebounceService debounceService)
        {
            _debounceService = debounceService;
        }

        public Debouncer()
        {
            _debounceService = new InMemoryDebounceService();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Uses the debounce mechanism to acquire a debounce entry. If acquired, executes the specified lambda ( <paramref name="execution"/> ) and returns.
        /// Returns default value if acquiring fails.
        /// This does NOT throw any exception in the case acquiring fails
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope"></param>
        /// <param name="signature"></param>
        /// <param name="requestor"></param>
        /// <param name="execution"></param>
        /// <returns></returns>
        public T Debounce<T>(string scope, string signature, string requestor, Func<T> execution)
        {
            try {
                _debounceService.Debounce(scope, signature, requestor);
                return execution();
            }
            catch (DebounceException ex) {
            }

            return default(T);
        }

        /// <summary>
        /// Uses the debounce mechanism to acquire a debounce entry. If acquired, executes the specified lambda ( <paramref name="execution"/> ) and returns.
        /// Returns default value if acquiring fails.
        /// This does NOT throw any exception in the case acquiring fails.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="signature"></param>
        /// <param name="requestor"></param>
        /// <param name="execution"></param>
        public void Debounce(string scope, string signature, string requestor, Action execution)
        {
            try {
                _debounceService.Debounce(scope, signature, requestor);
                execution();
            }
            catch (DebounceException ex) {
            }
        }

        /// <summary>
        /// Generates a unique signature with the specified <paramref name="params"/>. Simply joins all params, by '|'
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public string GenerateUniqueSignature(params string[] @params)
        {
            return string.Join("|", @params);
        }

        #endregion Public Methods
    }
}
