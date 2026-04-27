using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.services.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers
{
    [ApiController]
    [Route("api/cat-fact/")]
    public class CatFactController : ControllerBase
    {
        private readonly ICatFactService _catFactService;
        
        public CatFactController(ICatFactService catFactService)
        {
            _catFactService = catFactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatFact()
        {
            try
            {
                var response = await _catFactService.GetRandomCatFact();
                if (response != null)
                {   
                    return Ok(response);
                }
                else return BadRequest("Ups! There Is no random cat fact!");
            }
            catch(Exception)
            {
                return Problem("Something went wrong!");
            }
        }
    }
}