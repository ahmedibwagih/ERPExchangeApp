namespace Dynamo.Core.Other
{
    public class DynamoException : Exception
    {
        public string ErrorMessage;
        public DynamoException(string errorMessage) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
