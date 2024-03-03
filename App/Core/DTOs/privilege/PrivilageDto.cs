using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;
using Core.DTOs;
using Core.Entities.privilege;

namespace Core.DTOs.privilege
{
    public class PrivilageDto : EntityDto
    {

        public long ScreensId { get; set; }
        public long PrivilageTypeId { get; set; }
        public string RoleId { get; set; }
        public PrivilageStateEnum State { get; set; }

    }
}
