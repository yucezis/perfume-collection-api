using Perfume.Exceptions;

namespace Perfume.Exceptions
{
    public class NotFoundException : AppException
    {
        public override int StatusCode => 404;
        public override string Title => "Kayıt bulunamadı";
        public NotFoundException(string message) : base(message) { }

    }
}
