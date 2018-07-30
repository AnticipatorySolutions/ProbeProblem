using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProbeProblem.Models;
using ProbeProblem.BLL;

namespace ProbeProblem.Controllers
{
    public class ArticleModelsController : ApiController
    {

        /* 
         * Why return the whole DB??
        // GET: api/ArticleModels
        public IQueryable<ArticleModels> GetArticleDB()
        {
            return db.ArticleDB;
        }
        */

        public ArticleModelsController() : base()
        {
            DAL.ProbeProblemDatabase.Init();
        }
        // GET: api/ArticleModels/5
        [ResponseType(typeof(ArticleModels))]
        public async Task<IHttpActionResult> GetArticleModels(int id)
        {

            try
            {
                ArticleModels articleModels = await new ArticleModelsBLL().GetArticleModelsById(id);
                if (articleModels == null)
                {
                    return NotFound();
                }
                return Ok(articleModels);
            }
            catch (Exception ex)
            {
                // Logging would go here
                return InternalServerError();
            }
        }

        // PUT: api/ArticleModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticleModels(int id, ArticleModels articleModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articleModels.Id)
            {
                return BadRequest();
            }

            try
            {
                await new ArticleModelsBLL().SaveArticleModels(articleModels);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Logging would go here
                return BadRequest();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Logging would go here
                return BadRequest();
            }

            catch (Exception ex)
            {
                // Logging would go here
                return InternalServerError();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ArticleModels
        [ResponseType(typeof(ArticleModels))]
        public async Task<IHttpActionResult> PostArticleModels(ArticleModels articleModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await new ArticleModelsBLL().CreateArticleModels(articleModels);
            }
            catch (Exception ex)
            {
                // Logging would go here
                return InternalServerError();
            }
            return CreatedAtRoute("DefaultApi", new { id = articleModels.Id }, articleModels);
        }

        // DELETE: api/ArticleModels/5
        [ResponseType(typeof(ArticleModels))]
        public async Task<IHttpActionResult> DeleteArticleModels(int id)
        {
            try
            {
                ArticleModels articleModels = await new ArticleModelsBLL().DeleteArticleModels(id);
                return Ok(articleModels);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Logging here
                return NotFound();
            }
            catch (Exception ex)
            {
                // logging here
                return InternalServerError();
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // in a more complex/enterprisey structure I would have built the repository pattern,
                // but I will settle for this slightly awkward mechanism for the sake of time.
                DAL.ProbeProblemDatabase.Release();
            }
            base.Dispose(disposing);
        }

    }
}