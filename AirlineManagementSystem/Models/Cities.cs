//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlineManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cities
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Airport Name")]
        public string Airport_Name { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> CreatedOnDate { get; set; }
        public Nullable<System.DateTime> LastModifiedOnDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastModifiedByUserId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}