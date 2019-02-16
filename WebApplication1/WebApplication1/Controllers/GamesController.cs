using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.BAL;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GamesController : ControllerBase
    {
        // GET: api/Games
        [HttpGet, Authorize]
        [Route("GameCollections")]
       
        public IActionResult GetGameCollections(string gameCollectionId)
        {
            try
            {
              return Ok(GamesCollection.GetGameCollections(gameCollectionId));

            }
            catch
            {
                return BadRequest();
            }
         
        }
        [HttpGet]
        [Route("GameDetails")]
        public IActionResult GetGameDetails(string gameId)
        {
            try
            {
                return Ok(GamesCollection.GetGameDetails(gameId));

            }
            catch
            {
                return BadRequest();
            }
        }
           
    }
}
