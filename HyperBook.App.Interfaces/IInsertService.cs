using HyperBook.App.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Interfaces
{
    public interface IInsertService
    {

        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="userModel"></param>
        string AddUser(UserModel userModel);


        /// <summary>
        /// Add a City
        /// </summary>
        /// <param name="cityModel"></param>
        /// <returns></returns>
        string AddCity(CityModel cityModel);


        /// <summary>
        /// Add a Pod Schedule
        /// </summary>
        /// <param name="podSchedule"></param>
        /// <returns></returns>
        string AddPodSchedule(PodScheduleModel podSchedule);


        /// <summary>
        /// Add Ref Status
        /// </summary>
        /// <param name="refStatus"></param>
        /// <returns></returns>
        string AddRefStatus(RefStatusModel refStatus);


        /// <summary>
        /// Add a new trip
        /// </summary>
        /// <param name="tripModel"></param>
        /// <returns></returns>
        string AddTrip(TripModel tripModel);
    }
}
