using System;
using System.Linq;
using ProbeProblem.Models;

namespace ProbeProblem.DAL
{
    public static class ProbeProblemDatabase
    {
        private static ArticleDbContext _instance;
        public static ArticleDbContext Instance
        {
            get { return _instance; }
        }

        public static bool ArticleModelsExists(int id)
        {
            return Instance.ArticleDB.Count(e => e.Id == id) > 0;
        }

        public static void Init()
        {
            _instance = new ArticleDbContext();
        }
        public static void Release()
        {
            _instance.Dispose();
        }

    }
}