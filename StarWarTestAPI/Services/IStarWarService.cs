using StarWarTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarTestAPI.Services
{
    public interface IStarWarService
    {
        ResponseHandler getMovieTitleOpeningCrawl();

    }
}
