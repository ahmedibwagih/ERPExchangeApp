using Core.DTOs;
using Core.Other;
using Dynamo.Core.Entities.Base;

namespace Application.Core.DTOs.LookUps
{
    public class JobsDto : EntityDto
    {
        public string? Name { get; set; }
        public RiskRateEnum RiskRate { get; set; }
        public ActiveEnum IsActve { get; set; }
    }
}
