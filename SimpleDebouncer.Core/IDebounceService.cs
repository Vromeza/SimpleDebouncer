using System;

namespace SimpleDebouncer.Core
{
    public interface IDebounceService
    {
        /// <summary>
        /// Uses the debounce mechanism for the given <paramref name="scope"/>, <paramref name="signature"/> and <paramref name="requestor"/>.
        /// Throws a <see cref="DebounceException"/> on debounce.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="signature"></param>
        /// <param name="requestor"></param>
        /// <exception cref="DebounceException">Thrown when a debounce occurs, meaning execution should stop</exception>
        void Debounce(string scope, string signature, string requestor);
    }
}
