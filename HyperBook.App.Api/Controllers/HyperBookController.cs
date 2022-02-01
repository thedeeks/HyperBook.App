using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyperBook.App.Interfaces;

namespace HyperBook.App.Api.Controllers
{
    /// <summary>
    /// HyperBook API
    /// </summary>
    [Route("api/[controller]", Name ="HyperBook")]
    [ApiController]
    public class HyperBookController : ControllerBase
    {
        #region services
        //Services
        private ICitiesService _citiesService { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public HyperBookController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }
        #endregion



        /// <summary>
        /// Returns a list of cities with information about them
        /// </summary>
        /// <returns>Returns a list of CityWithInfoResponse object</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetCitiesWithInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCitiesWithInfo()
        {
            try
            {
                //Returns a 200
                return Ok(_citiesService.GetCitiesWithInfo());
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }            
        }

    }
}
