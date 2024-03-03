using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System;

namespace Application.Core.DTOs.privilege
{
    public class PrivilageType : Entity
    {
        public string Name { get; set; }   
        [ForeignKey("ScreensId")]
        public Screens Screens { get; set; }

    }
}
