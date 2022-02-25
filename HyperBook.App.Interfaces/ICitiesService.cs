using HyperBook.App.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Interfaces
{
    public interface ICitiesService
    {
        /// <summary>
        /// Returns a list of cities with information about them
        /// </summary>
        /// <returns>Returns a list of CityWithInfoResponse object</returns>
        IEnumerable<CityWithInfoResponse> GetCitiesWithInfo();


        /// <summary>
        /// Returns a collection of pod schedules
        /// </summary>
        /// <param name="cityId">City From</param>
        /// <param name="cityDestinationId">City To</param>
        /// <returns>A collection of PodScheduleResponse objects</returns>
        /// [ApiExplorerSettings(GroupName = "HyperBook")]
        IEnumerable<PodScheduleResponse> GetPodSchedule(int cityId, int cityDestinationId);
    }
}
