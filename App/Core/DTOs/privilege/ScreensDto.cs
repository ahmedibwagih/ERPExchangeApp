using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Core.DTOs.privilege
{
    public class ScreensDto : EntityDto
    {
        public string Name { get; set; }
        public bool IsFinal { get; set; }
        public long? ScreenParrentId { get; set; }
    }
}
