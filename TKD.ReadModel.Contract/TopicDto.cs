﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TKD.ReadModel.Contract
{
    
    public class TopicDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime UpdateTime { get; set; }

        

    }
}
