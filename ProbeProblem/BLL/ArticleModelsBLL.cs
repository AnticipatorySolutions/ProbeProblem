using System;
using System.Collections.Generic;
using System.Linq;
using ProbeProblem.DAL;
using ProbeProblem.Models;
using System.Threading.Tasks;

namespace ProbeProblem.BLL
{
    public class ArticleModelsBLL
    {
        public async Task<ArticleModels> GetArticleModelsById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return await new ArticleModelsDAL().GetArticleModelsById(id);
        }

        public async Task SaveArticleModels(ArticleModels articleModels)
        {
            if (articleModels.Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            await new ArticleModelsDAL().SaveArticleModels(articleModels);
        }

        public async Task CreateArticleModels(ArticleModels articleModels)
        {
            await new ArticleModelsDAL().CreateArticleModels(articleModels);
        }

        public async Task<ArticleModels> DeleteArticleModels(int id)
        {
            ArticleModels existingArticleModels = await ProbeProblemDatabase.Instance.ArticleDB.FindAsync(id);
            if (existingArticleModels == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            await new ArticleModelsDAL().DeleteArticleModels(existingArticleModels);
            return existingArticleModels;

        }
    }
}