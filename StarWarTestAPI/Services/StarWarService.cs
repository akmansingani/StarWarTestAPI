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

        public ResponseHandler getCharacterMostAppeared()
        {
            try
            {
                // finds movie character who appeared most

                var characterName = (from t1 in _dbContext.films_characters
                                     join t2 in _dbContext.people on t1.people_id equals t2.id
                                     group new { t1, t2 } by new { t1.people_id, t2.name } into t3
                                     orderby t3.Count() descending, t3.FirstOrDefault().t2.name
                                     select t3.FirstOrDefault().t2.name).FirstOrDefault();


                return new ResponseHandler
                {
                    status = "success",
                    response = characterName
                };

            }
            catch (Exception ex)
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
