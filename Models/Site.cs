//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationDBFirst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Site
    {
        public int siteId { get; set; }
        public string siteName { get; set; }
        public string siteDes { get; set; }
        public Nullable<int> ismsId { get; set; }
    
        public virtual IsmsScope IsmsScope { get; set; }
    }
}
