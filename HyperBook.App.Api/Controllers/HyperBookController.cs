using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using HyperBook.App.Interfaces;
using System.ComponentModel.DataAnnotations;

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

        private IUsersService _usersService { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public HyperBookController(ICitiesService citiesService, IUsersService userService)
        {
            _citiesService = citiesService;
            _usersService = userService;
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


        /// <summary>
        /// Logs the user in to the application
        /// </summary>        
        /// <returns>UserId</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([Required]string email, [Required]string password)
        {
            try
            {
                //Returns a 200
                return Ok(_usersService.Login(email, password));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Returns User Info
        /// </summary>        
        /// <returns>UserId</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUser([Required] int userId)
        {
            try
            {
                //Returns a 200
                return Ok(_usersService.GetUser(userId));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }

    }
}
