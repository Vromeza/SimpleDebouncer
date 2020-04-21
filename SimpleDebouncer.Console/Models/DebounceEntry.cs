using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDebouncer.Console.Models
{
    public class DebounceEntry
    {
        public string Id { get; set; }
        public string Scope { get; set; }
        public string Signature { get; set; }
        public string Requestor { get; set; }
    }
}
