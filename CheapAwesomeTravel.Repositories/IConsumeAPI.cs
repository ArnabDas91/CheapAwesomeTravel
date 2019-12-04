using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CheapAwesomeTravel.Repositories.Classes;

namespace CheapAwesomeTravel.Repositories
{
    public interface IConsumeAPI
    {
        Task<List<Hotels>> GetHotelsFromApi(int destinationid, int nights, string code);
    }
}
