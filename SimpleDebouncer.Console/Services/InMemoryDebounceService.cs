using SimpleDebouncer.Console.Models;
using SimpleDebouncer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDebouncer.Console.Services
{
    public class InMemoryDebounceService : IDebounceService
    {
        private List<DebounceEntry> _debounceEntries = new List<DebounceEntry>();
        public void Debounce(string scope, string signature, string requestor)
        {
            if (_debounceEntries.Any(d => d.Scope == scope && d.Signature == signature)) {
                throw new DebounceException($"Debounce exception for {scope} and {signature}");
            }
            _debounceEntries.Add(new DebounceEntry()
            {
                Id = Guid.NewGuid().ToString(),
                Requestor = requestor,
                Scope = scope,
                Signature = signature
            });
        }
    }
}
