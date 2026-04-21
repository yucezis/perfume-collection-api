
namespace Perfume.Exceptions
{
    public abstract class AppException : Exception
    {
        public abstract int StatusCode { get; }
        public abstract string Title { get; }

        protected AppException(string Message) : base(Message) { } 
    }
}
