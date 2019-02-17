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
        [HttpGet]
        [Route("GameCollections")]
       
        public async Task<IActionResult> GetGameCollections(int? gameCollectionId)
        {
            try
            {
              return Ok(await GamesCollection.GetGameCollections(gameCollectionId));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
         
        }
       
        [HttpGet, Authorize]
        [Route("GameDetails")]
        public async Task<IActionResult> GetGameDetails(int? gameId)
        {
            try
            {
                return Ok( await GamesCollection.GetGameDetails(gameId));

            }
            catch
            {
                return BadRequest();
            }
        }
           
    }
}
