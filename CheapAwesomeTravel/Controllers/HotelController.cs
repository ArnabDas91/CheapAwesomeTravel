using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheapAwesomeTravel.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CheapAwesomeTravel.Repositories;

namespace CheapAwesomeTravel.Controllers
{
    public class HotelController : Controller
    {
        private readonly IConfiguration _configuration;
        IConsumeCheapTravelAPI _consumeCheapTravelAPI;
        public HotelController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(Tour tour)
        {
            List<HotelDetails> lstHotelDetails = new List<HotelDetails>();
            HotelDetails hotelDetails = new HotelDetails();
            tour.Code = _configuration.GetValue<string>("ApiKey"); ;
            _consumeCheapTravelAPI = new ConsumeCheapTravelAPI("http://" + Request.Host.Host + ":" + Request.Host.Port + "/api/");
            try
            {
                var HotelsList = await _consumeCheapTravelAPI.ConsumeService(tour.DestinationId, tour.Nights, tour.Code);
                List<CheapAwesomeTravel.Models.Hotels> lstHotels = HotelsList.Select(s => new CheapAwesomeTravel.Models.Hotels
                {
                    Hotel = new CheapAwesomeTravel.Models.Hotel
                    {
                        geoId = s.Hotel.geoId,
                        name = s.Hotel.name,
                        propertyID = s.Hotel.propertyID,
                        rating = s.Hotel.rating
                    },
                    Rates=s.Rates.Select(item =>new CheapAwesomeTravel.Models.Rates
                    {
                        boardType = item.boardType,
                        rateType = item.rateType,
                        value = item.value
                    }).ToList()
                }).ToList();
                lstHotelDetails = Utility.GetHotelDetails(lstHotels, tour.Nights);
                return View("Hotels", lstHotelDetails);
            }
            catch (Exception ex)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ErrorMessage = "Some Error Occurred. Please Try After Some Time";
                Utility.WriteLogFile(ex.Message.ToString());
                return View("Error", errorViewModel);
            }
        }
    }
}