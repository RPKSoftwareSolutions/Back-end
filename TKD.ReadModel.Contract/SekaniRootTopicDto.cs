﻿using System;

namespace TKD.ReadModel.Contract
{
    public class SekaniRootTopicDto
    {
        public int Id { get; set; }
        public int SekaniRootId { get; set; }
        public int TopicId { get; set; }

        public DateTime UpdateTime { get; set; }


    }
}
