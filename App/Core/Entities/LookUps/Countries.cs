using Core.Other;
using Dynamo.Core.Entities.Base;

namespace Core.Entities.LookUps
{
    public class Countries : Entity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public RiskRateEnum RiskRate { get; set; }
        public ActiveEnum IsActve { get; set; }
    }
}
