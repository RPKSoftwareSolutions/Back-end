using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.DomainModel.AuthenticateModels
{
    public class ClientScope
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Scope { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        
    }
}
