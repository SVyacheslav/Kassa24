namespace Kassa24.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Payments
    {
        [Key]
        public int PaymentsId { get; set; }

        public int OperatorId { get; set; }

        public int PrefixId { get; set; }

        public int Amount { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateUser { get; set; }

        public virtual Table_Operator Table_Operator { get; set; }

    }
}
