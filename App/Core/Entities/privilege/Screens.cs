using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Core.Entities.privilege
{
    public class Screens 
    {
        [Key]
        [Column(Order = 0)]
        public long ScreenId { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsFinal { get; set; }

        public long? ScreenParrentId { get; set; }
        //[ForeignKey("OrderId")]
        //public Order Order { get; set; }

    }
}
