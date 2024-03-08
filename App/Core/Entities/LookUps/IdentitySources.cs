using Core.Entities.privilege;
using Core.Other;
using Dynamo.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.LookUps
{
    public class IdentitySources : Entity
    {

        public long CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Countries Country { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public RiskRateEnum RiskRate { get; set; }

        public ActiveEnum IsActve { get; set; }
    }
}
