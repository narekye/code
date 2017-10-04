using System.ComponentModel.DataAnnotations;

namespace sharp.AuthorizationServer.Api.Models
{
    public class AudienceModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}