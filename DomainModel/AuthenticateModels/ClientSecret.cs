using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityServer4.Models;
using Client = TKD.DomainModel.AuthenticateModels.Client;

namespace TKD.Domain.AuthenticateModels
{
    public class ClientSecret: Secret
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

    }
}
