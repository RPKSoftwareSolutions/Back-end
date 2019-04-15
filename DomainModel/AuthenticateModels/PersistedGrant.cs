using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKD.DomainModel.AuthenticateModels
{
    public class PersistedGrant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(430)]
        //public int Id { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string ClientId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public string Data { get; set; }
    }
}
