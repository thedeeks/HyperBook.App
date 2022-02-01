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
        public IEnumerable<CityWithInfoResponse> GetCitiesWithInfo();
    }
}
