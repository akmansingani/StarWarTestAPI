using Newtonsoft.Json.Linq;
using NUnit.Framework;
using StarWarTestAPI.Controllers;
using StarWarTestAPI.Models;
using StarWarTestAPI.Services;
using StarWarUnitTest.Services;
using Xunit;

namespace StarWarUnitTest
{
    public class StarWarTestClass
    {
        HomeController _controller;
        IStarWarService _service;

        public StarWarTestClass()
        {
            _service = new StarWarTestService();
            _controller = new HomeController(_service);
        }

        [Fact]
        public void Get_Movie_Title_Opening_Crawl_Call_Check()
        {
            ResponseHandler okResult = _service.getMovieTitleOpeningCrawl();

            Xunit.Assert.Equal("success", okResult.status);
        }

        [Fact]
        public void Get_Movie_Title_Opening_Crawl_Check_Response()
        {
            ResponseHandler okResult = _service.getMovieTitleOpeningCrawl();

            Xunit.Assert.Equal("A New Hope", okResult.response);
        }

        [Fact]
        public void Get_Character_Most_Appeared_Check()
        {
            ResponseHandler okResult = _service.getCharacterMostAppeared();

            Xunit.Assert.Equal("success", okResult.status);
        }

        [Fact]
        public void Get_Character_Most_Appeared_Check_Response()
        {
            ResponseHandler okResult = _service.getCharacterMostAppeared();

            Xunit.Assert.Equal("Luke Skywalker", okResult.response);
        }

        [Fact]
        public void Get_Most_Number_Of_Species_Check()
        {
            ResponseHandler okResult = _service.getMostNumberOfSpecies();

            Xunit.Assert.Equal("success", okResult.status);
        }

        [Fact]
        public void Get_Most_Number_Of_Species_Check_Response()
        {
            ResponseHandler okResult = _service.getMostNumberOfSpecies();
            JObject joResponse = JObject.Parse(okResult.response);
            JArray array = (JArray)joResponse["species"];

            Xunit.Assert.Equal("Human", array[0]["speciesname"].ToString());
        }
    }
}