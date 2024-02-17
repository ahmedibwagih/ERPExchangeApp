using System.ComponentModel.DataAnnotations;
using Dynamo.Core.Entities.Base;

namespace Dynamo.Core.Entities
{
    public class Permission : Entity
    {
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }
    }
}
