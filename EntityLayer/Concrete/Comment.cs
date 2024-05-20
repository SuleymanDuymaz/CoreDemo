﻿using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment : BaseEntity
    {
        public string  CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string  CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogID { get; set; }
        public int BlogScore { get; set; }
        public Blog Blog { get; set; }

    }
}
