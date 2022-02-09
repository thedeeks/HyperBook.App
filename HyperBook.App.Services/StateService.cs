using HyperBook.App.Data;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HyperBook.App.Services
{
    public class StateService : IStateService
    {

        /// <summary>
        /// HyperBook Context
        /// </summary>
        private HyperBookContext _hyperbookContext { get; set; }

        public StateService(HyperBookContext hyperbookContext)
        {
            _hyperbookContext = hyperbookContext;
        }


        /// <summary>
        /// Returns a list of all states
        /// </summary>
        /// <returns>A collection of StateResponse Object</returns>
        public IEnumerable<StateResponse> GetStates()
        {
            //Get all states
            var states = _hyperbookContext.States;
            //Map the properies to the response object
            IEnumerable<StateResponse> listOfStates = from state in states
                                                      select new StateResponse
                                                      {
                                                          Id = state.Id,
                                                          Name = state.Name,
                                                          Abbreviation = state.Abbreviation
                                                      };
            //Return the list of states
            return listOfStates;
        }
    }
}
