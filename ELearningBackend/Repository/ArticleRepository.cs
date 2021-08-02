using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class ArticleRepository:Repository<Article>,IArticleRepository
    {
        public ArticleRepository(ApplicationDBContext context):base(context)
        {

        }

        public async Task<Article> GetArticleByIdAsync(int ArticleId)
        {
            return await context.Articles.Where(a=>a.Id==ArticleId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Article>> GetSomeArticleAsync()
        {
            return await context.Articles.Take(3).ToListAsync();
        }
    }
}
