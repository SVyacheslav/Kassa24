namespace Kassa24.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table_Operator")]
    public partial class Table_Operator
    {
        [Key]
        public int OperatorId { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public double Tax { get; set; }
    }
}
