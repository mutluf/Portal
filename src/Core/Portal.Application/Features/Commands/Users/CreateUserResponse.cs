namespace Portal.Application.Features.Commands.Users
{
    public class CreateUserResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
