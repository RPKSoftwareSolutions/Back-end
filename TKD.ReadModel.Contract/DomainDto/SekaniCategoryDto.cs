using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public byte[] Image { get; set; }
        public DateTime UpdateTime { get; set; }


    }
}
