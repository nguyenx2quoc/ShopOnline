//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACCOUNTADMIN
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public int SDT { get; set; }
        public string Account { get; set; }
    
        public virtual ACCOUNT ACCOUNT1 { get; set; }
    }
}
