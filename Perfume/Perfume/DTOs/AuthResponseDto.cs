namespace Perfume.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<string> Roles { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
