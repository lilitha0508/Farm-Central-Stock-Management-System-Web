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
    
    public partial class Product
    {
        public int prod_Id { get; set; }
        public int catagory_id { get; set; }
        public int farmer_id { get; set; }
        public string prod_name { get; set; }
    
        public virtual Farmer Farmer { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}