using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDebouncer.Core
{
    /// <summary>
    /// Custom exception used in debouncing mechanism when a specific task is debounced. See <see cref="IDebounceService"/>
    /// </summary>
    public class DebounceException : Exception
    {
        public DebounceException() { }
        public DebounceException(string message) : base(message) { }
    }
}
