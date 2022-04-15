namespace Saga.Choreography.Core.Domain
{
    public class Error
    {
        public Error()
        {
        }
        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public Error(int errorCode, string errorMessage)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}