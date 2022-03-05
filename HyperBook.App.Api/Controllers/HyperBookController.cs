using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using HyperBook.App.Interfaces;
using System.ComponentModel.DataAnnotations;
using HyperBook.App.Models.PutModels;

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

        private IItineraryService _itineraryService { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public HyperBookController(ICitiesService citiesService, IUsersService userService, IItineraryService itineraryService)
        {
            _citiesService = citiesService;
            _usersService = userService;
            _itineraryService = itineraryService;
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
        [HttpGet("GetAccountInfo")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAccountInfo([Required] Guid userId)
        {
            try
            {
                //Returns a 200
                return Ok(_usersService.GetAccountInfo(userId));
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
        /// Gets the list of trips for a user.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>A collection of PodScheduleResponse objects</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetTrips")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTrips(Guid userId)
        {
            try
            {
                //Returns a 200
                return Ok(_itineraryService.GetTrips(userId));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }



        /// <summary>
        /// Gets the list trip statuses
        /// </summary>
        /// <returns>A collection of PodScheduleResponse objects</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetStatus")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetStatus()
        {
            try
            {
                //Returns a 200
                return Ok(_itineraryService.GetStatus());
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Gets the destinations from a particular city
        /// </summary>
        /// <param name="cityId">Id of the Departure city</param>
        /// <returns>A collection of DestinationResponse  objects</returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpGet("GetDestinations")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetDestinations([Required]int cityId)
        {
            try
            {
                //Returns a 200
                return Ok(_itineraryService.GetDestinations(cityId));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Updates an existing User
        /// </summary>
        /// <param name="user">User Object</param>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpPut("UpdateUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser([Required] UserUpdateModel user)
        {
            try
            {
                //Returns a 204
                _usersService.UpdateUser(user);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }



        /// <summary>
        /// Updates the Status of a Trip Record.
        /// </summary>
        /// <param name="tripUpdateModel"></param>
        /// <remarks>
        /// Ref Status
        /// 1	Pending
        /// 2	Booked
        /// 3	Cancelled
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpPut("UpdateTripStatus")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTripStatus([Required] UpdateTripModel tripUpdateModel)
        {
            try
            {
                //Return a 204
                _itineraryService.UpdateTripStatus(tripUpdateModel.TripId, tripUpdateModel.RefStatusId);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = "HyperBook")]
        [HttpDelete("DeleteTrip")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTrip([Required] int tripId)
        {
            try
            {
                //Returns a 201
                _itineraryService.DeleteTrip(tripId);
                return Ok();
            }
            catch (Exception ex)
            {
                //returns a 500
                return StatusCode(500, ex.Message);
            }
        }

    }
}
