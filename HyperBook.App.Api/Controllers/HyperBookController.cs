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

        private IStateService _stateService { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public HyperBookController(ICitiesService citiesService, IUsersService userService, IStateService stateService)
        {
            _citiesService = citiesService;
            _usersService = userService;
            _stateService = stateService;
        }
        #endregion



        /// <summary>
        /// Returns a list of cities with information about them
        /// </summary>
        /// <returns>Returns a list of CityWithInfoResponse object</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetCitiesWithInfo")]
        [Produces("application/json")]
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
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>UserId, FirstName, LastName, EmailAddress</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("Login")]
        [Produces("application/json")]
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
        /// <param name="userId">GUID</param>
        /// <returns>UserId, Email, FirstName, LastName, Street, City, State, Zip, Phone</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetUserName")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserName([Required] Guid userId)
        {
            try
            {
                //Returns a 200
                return Ok(_usersService.GetUserName(userId));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Returns a collection of pod schedules
        /// </summary>
        /// <param name="cityId">City From</param>
        /// <param name="cityDestinationId">City To</param>
        /// <returns>A collection of PodScheduleResponse objects</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetPodSchedules")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPodSchedules([Required] int cityId,[Required] int cityDestinationId)
        {
            try
            {
                //Returns a 200
                return Ok(_citiesService.GetPodSchedule(cityId, cityDestinationId));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Returns a list of all states
        /// </summary>
        /// <returns>A collection of StateResponse Object</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetStates")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetStates()
        {
            try
            {
                //Returns a 200
                return Ok(_stateService.GetStates());
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }

    }
}
