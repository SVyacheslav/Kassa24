namespace Kassa24.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Prefix
    {
        [Key]
        public int PrefixId { get; set; }

        public string Prefix { get; set; }

        public int OperatorId { get; set; }
        
    }
}
