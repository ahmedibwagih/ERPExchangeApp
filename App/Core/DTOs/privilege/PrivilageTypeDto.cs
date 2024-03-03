using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Core.DTOs.privilege
{
    public class PrivilageTypeDto : EntityDto
    {
        public string Name { get; set; }

        public long ScreensId { get; set; }

    }
}
