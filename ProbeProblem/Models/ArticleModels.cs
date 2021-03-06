﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProbeProblem.Models
{
    public class ArticleModels
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class ArticleDbContext : DbContext
    {
        public DbSet<ArticleModels> ArticleDB { get; set; }
    }
}