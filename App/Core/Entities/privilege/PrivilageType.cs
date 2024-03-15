using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Core.Entities.privilege
{
    public class PrivilageType 
    {

        [Key]
        [Column(Order = 0)]
        public long PrivilageTypeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public long ScreensId { get; set; }
        [ForeignKey("ScreensId")]
        public Screens Screens { get; set; }

    }
}
