using System;
using System.Collections.Generic;
using System.Linq;
using ProbeProblem.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProbeProblem.DAL
{
    public class ArticleModelsDAL
    {
        public async Task<ArticleModels> GetArticleModelsById(int id)
        {
            var result = await ProbeProblemDatabase.Instance.ArticleDB.FindAsync(id);
            return result;
        }

        public async Task SaveArticleModels(ArticleModels articleModels)
        {

            ProbeProblemDatabase.Instance.Entry(articleModels).State = EntityState.Modified;

            try
            {
                await ProbeProblemDatabase.Instance.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // This is a specific problem, let's flag it
                if (!ProbeProblemDatabase.ArticleModelsExists(articleModels.Id))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    throw;
                }
            }

        }

        public async Task CreateArticleModels(ArticleModels articleModels)
        {
            ProbeProblemDatabase.Instance.ArticleDB.Add(articleModels);
            await ProbeProblemDatabase.Instance.SaveChangesAsync();
        }

        public async Task DeleteArticleModels(ArticleModels articleModels)
        {
            ProbeProblemDatabase.Instance.ArticleDB.Remove(articleModels);
            await ProbeProblemDatabase.Instance.SaveChangesAsync();
        }

    }
}