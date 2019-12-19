using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StarWarTestAPI.DBContext;
using StarWarTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarTestAPI.Services
{
    public class StarWarService : IStarWarService
    {
        private readonly MyDBContext _dbContext;

        private IHttpContextAccessor _context;


        public StarWarService(MyDBContext dbContext, IHttpContextAccessor context)
        {
            _dbContext = dbContext;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ResponseHandler getMovieTitleOpeningCrawl()
        {
            try
            {
                // finds movie title with longest opening crawl

                var movies = (from f in _dbContext.films
                             orderby f.opening_crawl.Max()
                             select f.title).FirstOrDefault();

                return new ResponseHandler
                {
                    status = "success",
                    response = movies
                };

            }
            catch(Exception ex)
            {
                return new ResponseHandler
                {
                    status = "error",
                    response = "Please try later!"
                };
            }
        }

       
    }
}
