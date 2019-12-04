using CheapAwesomeTravel.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeTravel.Repositories
{
    public interface IConsumeCheapTravelAPI
    {
        Task<List<Hotels>> ConsumeService(int destinationid, int nights, string code);
    }
}
