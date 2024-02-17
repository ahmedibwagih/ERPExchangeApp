namespace Dynamo.Core.Other
{
    public class DynamoSession
    {
        private string typeId;
        private string typeIdLong;
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string TypeId 
        {
            get
            {
                return typeId;
            }
            set
            {
                typeId = value;
            }
        }

        public long TypeIdLong
        {
            get
            {
                if (!string.IsNullOrEmpty(typeId))
                    return long.Parse(typeId);
                else
                    return -1;

            }
        }


        public string UserType { get; set; }
        public static string Lang { get; set; }
        public string Roles { get; set; }
       
    }
}
