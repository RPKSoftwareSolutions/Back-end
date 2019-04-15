using System;

namespace TKD.ReadModel.Contract.DomainDto
{
    public class SekaniRootImageDto
    {
        public int Id { get; set; }

        public int SekaniRootId { get; set; }

        public byte[] Content { get; set; }

        public string Format { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }


    }
}
