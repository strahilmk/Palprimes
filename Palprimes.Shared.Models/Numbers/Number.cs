using System;

namespace Palprimes.Shared.Models.Numbers
{
    public class Number
    {
        public Guid UniqueId { get; set; }
        public string Value { get; set; }
        public bool IsPrime { get; set; }
        public bool IsPalindrom { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
