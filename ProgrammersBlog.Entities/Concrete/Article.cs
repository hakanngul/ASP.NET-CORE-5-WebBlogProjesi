﻿using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; } // resim yolu image source
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; }
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}