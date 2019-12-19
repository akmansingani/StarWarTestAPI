using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StarWarTestAPI.Models;
using StarWarTestAPI.Services;

namespace StarWarUnitTest.Services
{
    public class StarWarTestService : IStarWarService
    {
        private readonly List<FilmModel> _films;

        private readonly List<Films_CharacterModels> _films_characters;

        private readonly List<PersonModel> _people;

        public StarWarTestService()
        {
            // films data
            _films = new List<FilmModel>{
                new FilmModel()
                {
                    id = 1,
                    created = DateTime.Now,
                    director = "George Lucas",
                    edited = DateTime.Now,
                    episode_id = 4,
                    opening_crawl = @"It is a period of civil war.
                                        Rebel spaceships, striking
                                        from a hidden base, have won
                                        their first victory against
                                        the evil Galactic Empire.

                                        During the battle, Rebel
                                        spies managed to steal secret
                                        plans to the Empire's
                                        ultimate weapon, the DEATH
                                        STAR, an armored space
                                        station with enough power
                                        to destroy an entire planet.

                                        Pursued by the Empire's
                                        sinister agents, Princess
                                        Leia races home aboard her
                                        starship, custodian of the
                                        stolen plans that can save her
                                        people and restore
                                        freedom to the galaxy....",
                    producer = "Gary Kurtz, Rick McCallum",
                    release_date = DateTime.Now,
                    title = "A New Hope"
                },
                new FilmModel()
                {
                    id = 2,
                    created = DateTime.Now,
                    director = "Irvin Kershner",
                    edited = DateTime.Now,
                    episode_id = 4,
                    opening_crawl = @"It is a dark time for the
                                        Rebellion. Although the Death
                                        Star has been destroyed,
                                        Imperial troops have driven the
                                        Rebel forces from their hidden
                                        base and pursued them across
                                        the galaxy.

                                        Evading the dreaded Imperial
                                        Starfleet, a group of freedom
                                        fighters led by Luke Skywalker
                                        has established a new secret
                                        base on the remote ice world
                                        of Hoth.

                                        The evil lord Darth Vader,
                                        obsessed with finding young
                                        Skywalker, has dispatched
                                        thousands of remote probes into
                                        the far reaches of space....",
                    producer = "Gary Kurtz, Rick McCallum",
                    release_date = DateTime.Now,
                    title = "The Empire Strikes Back"
                }
            };

            // films character data
            _films_characters = new List<Films_CharacterModels>()
            {
                new Films_CharacterModels
                {
                    film_id = 1,
                    people_id = 1
                },
                new Films_CharacterModels
                {
                    film_id = 2,
                    people_id = 2
                },
                new Films_CharacterModels
                {
                    film_id = 3,
                    people_id = 1
                }
            };

            // people data
            _people = new List<PersonModel>()
            {
                new PersonModel
                {
                    id = 1,
                    birth_year = "19BBY",
                    created = DateTime.Now,
                    edited = DateTime.Now,
                    eye_color = "blue",
                    gender = "male",
                    hair_color = "blond",
                    height = "172",
                    homeworld = 1,
                    mass = "1",
                    name = "Luke Skywalker",
                    skin_color = "fair"
                },
                new PersonModel
                {
                    id = 2,
                    birth_year = "112BBY",
                    created = DateTime.Now,
                    edited = DateTime.Now,
                    eye_color = "yellow",
                    gender = "male",
                    hair_color = "blond",
                    height = "172",
                    homeworld = 1,
                    mass = "1",
                    name = "C-3PO",
                    skin_color = "gold"
                }
            };
        }

        public ResponseHandler getMovieTitleOpeningCrawl()
        {
            try
            {
                // finds movie title with longest opening crawl

                var queryList = _films.AsQueryable();

                var movies = (from f in queryList
                              orderby f.opening_crawl.Max()
                              select f.title).First();

                return new ResponseHandler
                {
                    status = "success",
                    response = movies
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

        public ResponseHandler getCharacterMostAppeared()
        {
            try
            {
                // finds movie character who appeared most

                var films_characters = _films_characters.AsQueryable();
                var people = _people.AsQueryable();

                var characterName = (from t1 in _films_characters
                                     join t2 in people on t1.people_id equals t2.id
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
