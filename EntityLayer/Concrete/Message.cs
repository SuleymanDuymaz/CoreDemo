﻿using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message : BaseEntity
    {
      
        public string MessageSender { get; set; }
        public string MessageReciever { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public bool MessageStatus { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
