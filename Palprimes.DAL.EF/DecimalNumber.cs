//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palprimes.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DecimalNumber
    {
        public int Id { get; set; }
        public System.Guid UniqueId { get; set; }
        public string Value { get; set; }
        public bool IsPrime { get; set; }
        public bool IsPalindrom { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
