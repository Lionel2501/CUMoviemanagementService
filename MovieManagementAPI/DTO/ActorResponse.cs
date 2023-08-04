using MovieManagement.Domain.Entities;

namespace MovieManagement.API.DTO
{
    public class ActorResponse
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        //public string Movies { get; set; }

        public List<string>? Movies { get; set; }

        //public Biography? Biography { get; set; }
    }
}
