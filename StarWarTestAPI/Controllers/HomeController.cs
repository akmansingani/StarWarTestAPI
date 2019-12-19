using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarTestAPI.Models;
using StarWarTestAPI.Services;

namespace StarWarTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private IStarWarService _starService;

        public HomeController(IStarWarService starService)
        {
            _starService = starService;
        }

        [HttpGet]
        public string startApi()
        {
            return "working";
        }

        [HttpGet("getTitleOpenCrawl")]
        public ActionResult GetMovieTitleOpeningCrawl()
        {
            ResponseHandler resp = _starService.getMovieTitleOpeningCrawl();

            if (resp.status == "error")
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }

        [HttpGet("getCharacterMostAppeared")]
        public ActionResult GetCharacterMostAppeared()
        {
            ResponseHandler resp = _starService.getCharacterMostAppeared();

            if (resp.status == "error")
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }

    }
}