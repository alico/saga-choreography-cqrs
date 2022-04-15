namespace Saga.Choreography.Core.Domain
{
    public class DomainException : Exception
    {
        public DomainException(int errorCode)
        {
            ErrorList = new List<Error>
            {
                new Error
                {
                    ErrorCode = errorCode
                }
            };
        }

        public DomainException(List<int> errorCodeList)
        {
            if (errorCodeList != null && errorCodeList.Any())
            {
                ErrorList = new List<Error>(errorCodeList.Select(code => new Error
                {
                    ErrorCode = code
                }));
            }
        }

        public DomainException(string errorMessage) : base(errorMessage)
        {
            ErrorList = new List<Error>()
            {
                new Error(errorMessage)
            };
        }

        public DomainException(List<Error> errorList)
        {
            ErrorList = new List<Error>(errorList);
        }

        public DomainException(Error error)
        {
            ErrorList = new List<Error> { error };
        }

        public List<Error> ErrorList { get; }
    }
}