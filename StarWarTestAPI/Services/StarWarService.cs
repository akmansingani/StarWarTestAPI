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

        public ResponseHandler getMostNumberOfSpecies()
        {
            try
            {
                // get lists of most number of appeared species in movie
                var speciesList = (from t1 in _dbContext.films_species
                                   join t2 in _dbContext.species on t1.species_id equals t2.id
                                   group new { t1, t2 } by new { t1.species_id, t2.name } into t3
                                   orderby t3.Count() descending, t3.FirstOrDefault().t1.species_id
                                   select new
                                   {
                                       speciesname = t3.FirstOrDefault().t2.name,
                                       speciescount = (from t4 in _dbContext.species_people
                                                       where t4.species_id == t3.FirstOrDefault().t1.species_id
                                                       select t4).Count()
                                   }).Take(5);


                return new ResponseHandler
                {
                    status = "success",
                    response = JsonConvert.SerializeObject(new
                    {
                        species = speciesList,
                    })
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
        public ResponseHandler getPlanetNumberOfPilots()
        {
            try
            {
                // get list of planets with relation to film and starship
               
                var planetlist = (from t1 in _dbContext.films_planets
                                  join t2 in _dbContext.films_starships on t1.film_id equals t2.film_id
                                  select new
                                  {
                                      planetid = t1.planet_id,
                                      filmid = t1.film_id,
                                      starshipid = t2.starship_id
                                  }).GroupBy(x => x.planetid).ToList();

                // get list of people data base on planet list

                var peopleData = from t1 in planetlist
                                 select new {
                                      planetid = t1.Key,
                                      people = (from t in _dbContext.starships_pilots
                                                where t1.Select(g => g.starshipid).Contains(t.starship_id)
                                                select new { id = t.people_id  }
                                                ).Distinct()
                                 };

                var peopleSpeciesList = (from z1 in _dbContext.people
                                        join z2 in _dbContext.species_people on z1.id equals z2.people_id
                                        join z3 in _dbContext.species on z2.species_id equals z3.id
                                        select new
                                        {
                                            people_id = z1.id,
                                            peoplename = z1.name + " - " + z3.name
                                        }).ToList();

                // get final data with people count, species name, people name,planet name
                var taskData = (from t1 in peopleData
                               join t2 in _dbContext.planets on t1.planetid equals t2.id
                               select new
                               {
                                   planet_id = t1.planetid,
                                   planetname = t2.name,
                                   people_count = t1.people.Count(),
                                   people_list = (from z1 in _dbContext.people
                                           join z2 in _dbContext.species_people on z1.id equals z2.people_id
                                           join z3 in _dbContext.species on z2.species_id equals z3.id
                                           join z4 in t1.people on z1.id equals z4.id
                                           select new
                                           {
                                               people_name = z1.name + " - " + z3.name
                                           })
                                   
                               }).OrderByDescending(x => x.people_count).Take(5);

                return new ResponseHandler
                {
                    status = "success",
                    response = JsonConvert.SerializeObject(new
                    {
                        planets = taskData,
                    })
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
