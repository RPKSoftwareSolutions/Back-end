using System.ComponentModel.DataAnnotations;

namespace TKD.DomainModel.AuthenticateModels
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
