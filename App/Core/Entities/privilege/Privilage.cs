using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;
using Core.Entities.LookUps;

namespace Core.Entities.privilege
{
    public class Privilage : Entity
    {

        public long ScreensId { get; set; }
        [ForeignKey("ScreensId")]
        public Screens Screens { get; set; }

        public long PrivilageTypeId { get; set; }
        [ForeignKey("PrivilageTypeId")]
        public PrivilageType PrivilageType { get; set; }


        public long JobId { get; set; }
        [ForeignKey("JobId")]
        public Jobs Jobs { get; set; }

        public PrivilageStateEnum  State { get; set; }
        //[ForeignKey("PrivilageTypeId")]
        //public Role PrivilageType { get; set; }

    }
}
