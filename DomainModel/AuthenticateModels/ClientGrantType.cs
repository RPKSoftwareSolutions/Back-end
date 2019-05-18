using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.AuthenticateModels
{
    public class ClientGrantType
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string GrantType { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }


    }
}
