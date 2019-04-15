using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniRootDto
    {

        public int Id { get; set; }

        public int SekaniLevelId { get; set; }

        public int SekaniCategoryId { get; set; }

        public int SekaniFormId { get; set; }

        public string RootWord { get; set; }

        public bool IsNull { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
