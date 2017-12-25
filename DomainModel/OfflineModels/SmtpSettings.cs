﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.OfflineModels
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SenderAddress { get; set; }
        public int Port { get; set; }
    }
}
