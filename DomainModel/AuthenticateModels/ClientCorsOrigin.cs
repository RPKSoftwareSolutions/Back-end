using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Domain.AuthenticateModels
{
    public class ClientCorsOrigin
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Origin { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

    }
}
