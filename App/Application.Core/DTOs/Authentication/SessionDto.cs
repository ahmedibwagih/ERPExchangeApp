
using Core.Other;

namespace Application.Core.DTOs.Authentication
{
    public class SessionDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public long JobId { get; set; }
        //public long WalletId { get; set; }

        //public UserTypeEnum UserType { get; set; }

    }
}
