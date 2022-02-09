using System;
using System.Collections;
using System.Collections.Generic;
using HyperBook.App.Models.ResponseModels;

namespace HyperBook.App.Interfaces
{
    public interface IStateService
    {

        /// <summary>
        /// Returns a list of all states
        /// </summary>
        /// <returns>A collection of StateResponse Object</returns>
        public IEnumerable<StateResponse> GetStates();
    }
}
