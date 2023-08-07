using MovieManagement.Domain.Entities;

namespace MovieManagement.API.Services.DTO.Model
{
    public class ActorResponse
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<string> Movies { get; set; }

        public string Biography { get; set; }

    }
}
