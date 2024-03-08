using Core.DTOs;
using Core.Other;
using Dynamo.Core.Entities.Base;

namespace Application.Core.DTOs.LookUps
{
    public class TransferPurposesDto : EntityDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int RiskRate { get; set; }
        public int IsActve { get; set; } = 1;
    }
}
