namespace Windows_service.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company_Profile_Approved
    {
        [Key]
        public int ProfileID { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public string website { get; set; }

        public string Address { get; set; }

        public bool? Isprocessed { get; set; }
    }
}
