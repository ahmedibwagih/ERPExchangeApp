using Application.Core.DTOs.LookUps;
using Core.DTOs;
using Core.Entities.LookUps;
using Core.Entities.privilege;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Core.DTOs.LookUps
{
    public class IdentitySourcesDto : EntityDto
    {

        public long CountryId { get; set; }


        public string? Name { get; set; }
        public RiskRateEnum RiskRate { get; set; }
        public ActiveEnum IsActve { get; set; }
    }
}
