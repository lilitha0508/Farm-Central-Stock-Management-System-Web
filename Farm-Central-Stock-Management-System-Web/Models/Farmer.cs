//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farm_Central_Stock_Management_System_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Farmer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Farmer()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int farmer_Id { get; set; }
        public string farmer_name { get; set; }
        public string farmer_surname { get; set; }
        public string farmer_adress { get; set; }
        public string farmer_contact { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}