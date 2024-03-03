using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Application.Core.DTOs.privilege
{
    public class Privilage : Entity
    {
     
        [ForeignKey("ScreensId")]
        public Screens Screens { get; set; }
        [ForeignKey("PrivilageTypeId")]
        public PrivilageType PrivilageType { get; set; }
        //[ForeignKey("PrivilageTypeId")]
        //public Role PrivilageType { get; set; }

    }
}
