using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using HyperBook.App.Models.PostModels;
using HyperBook.App.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperBook.App.Api.Controllers
{
    /// <summary>
    /// HyperBook Insert API
    /// </summary>
    [Route("api/[controller]", Name = "HyperBook Insert")]
    [ApiController]
    public class InsertController : ControllerBase
    {

        #region services
        private IInsertService _insertService { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="insertService"></param>
        public InsertController(IInsertService insertService)
        {
            _insertService = insertService;
        }
        #endregion

        /// <summary>
        /// Insert a User
        /// </summary>
        /// <param name="userModel">        
        /// </param>
        /// <remarks>
        /// email: string(254),
        /// password: string(128),
        /// firstName: string(50),
        /// lastName: string(50),
        /// addressLine1: string(250),
        /// addressLine2: string(250),
        /// city: string(50),
        /// state: string(2),
        /// zip: string(5),
        /// phone: string(12)
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook Insert")]
        [HttpPost("AddUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddUser(UserModel userModel)
        {
            try
            {
                //Returns a 201
                return StatusCode(201, _insertService.AddUser(userModel));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }



        /// <summary>
        /// Add a City
        /// </summary>
        /// <param name="cityModel"></param>
        /// <remarks>
        /// name: string(75),
        /// longitude: float,
        /// latitude: float,
        /// state: string(2) ***Expecting the numeric State Id***,
        /// timezone: string(75)
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook Insert")]
        [HttpPost("AddCity")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCity(CityModel cityModel)
        {
            try
            {
                //Returns a 201
                return StatusCode(201, _insertService.AddCity(cityModel));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Add a Pod Schedule
        /// </summary>
        /// <param name="podSchedule"></param>
        /// <remarks>
        /// cityFrom: int,
        /// cityTo: int,
        /// departureTimeGMT: datetime,
        /// arrivalTimeGMT: datetime,
        /// price: decimal
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook Insert")]
        [HttpPost("AddPodSchedule")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddPodSchedule(PodScheduleModel podSchedule)
        {
            try
            {
                //Returns a 201
                return StatusCode(201, _insertService.AddPodSchedule(podSchedule));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Add a Ref Status
        /// </summary>
        /// <param name="refStatus"></param>
        /// <remarks>
        /// description: string(250)
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook Insert")]
        [HttpPost("AddRefStatus")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddRefStatus(RefStatusModel refStatus)
        {
            try
            {
                //Returns a 201
                return StatusCode(201, _insertService.AddRefStatus(refStatus));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Add a new Trip
        /// </summary>
        /// <param name="tripModel"></param>
        /// <remarks>
        /// userId: GUID,
        /// podSchedule: int,
        /// statusId: int ***ref_status***
        /// </remarks>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "HyperBook Insert")]
        [HttpPost("AddTrip")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddTrip(TripModel tripModel)
        {
            try
            {
                //Returns a 201
                return StatusCode(201, _insertService.AddTrip(tripModel));
            }
            catch (Exception ex)
            {
                //Returns a 500
                return StatusCode(500, ex.Message);
            }
        }
    }
}
