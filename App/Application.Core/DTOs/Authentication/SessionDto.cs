
using Core.Other;

namespace Application.Core.DTOs.Authentication
{
    public class SessionDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        //public bool? IsAdmin { get; set; }
        public long ProfileId { get; set; }
        public long WalletId { get; set; }

        public UserTypeEnum UserType { get; set; }
        //public string[] Permissions { get; set; }

    }
}
