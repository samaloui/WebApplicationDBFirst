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
    
    public partial class InternalContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InternalContext()
        {
            this.IsmsScopes = new HashSet<IsmsScope>();
        }
    
        public int internalContextId { get; set; }
        public string governanceDes { get; set; }
        public string organizationalStructureDes { get; set; }
        public string rolesDes { get; set; }
        public string policiesObjectivesStrategyDes { get; set; }
        public string capabilitiesDes { get; set; }
        public string internalStakeholdersDes { get; set; }
        public string organizationCultureDes { get; set; }
        public string standardsDes { get; set; }
        public string contractualRelationDes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsmsScope> IsmsScopes { get; set; }
    }
}
