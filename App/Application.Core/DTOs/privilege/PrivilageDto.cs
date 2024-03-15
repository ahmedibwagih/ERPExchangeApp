using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Entities.privilege;

namespace Application.Core.DTOs.privilege
{
    public class PrivilageDto : EntityDto
    {
        public long ScreensId { get; set; }
        public long PrivilageTypeId { get; set; }
        public long JobId { get; set; }
        public int State { get; set; }

    }
}
