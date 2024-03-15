using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;
using Core.DTOs;

namespace Application.Core.DTOs.privilege
{
    public class ScreensDto 
    {
        public long ScreenId { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsFinal { get; set; }

        public long? ScreenParrentId { get; set; }

    }
}
