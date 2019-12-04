using CheapAwesomeTravel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeTravel
{
    public class Utility
    {
        public static void WriteLogFile(string inputstring)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string filepath = path + "\\wwwroot\\ErrorLog\\";
            string filename = "ErrorLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            try
            {
                StreamWriter sw = new StreamWriter(filepath + filename);
                sw.WriteLine(inputstring);
                sw.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }

        public static List<HotelDetails> GetHotelDetails(List<Hotels> lstHotels, int Nights)
        {
            List<HotelDetails> lstHotelDetails = new List<HotelDetails>();
            HotelDetails hotelDetails = new HotelDetails();
            try
            {
                if (lstHotels != null && lstHotels.Count > 0)
                {
                    for (int i = 0; i < lstHotels.Count; i++)
                    {
                        for (int j = 0; j < lstHotels[i].Rates.Count; j++)
                        {
                            hotelDetails = new HotelDetails();
                            hotelDetails.HotelName = lstHotels[i].Hotel.name;
                            hotelDetails.RateType = lstHotels[i].Rates[j].rateType;
                            hotelDetails.BoardType = lstHotels[i].Rates[j].boardType;
                            hotelDetails.Nights = Nights;
                            if (lstHotels[i].Rates[j].rateType == "PerNight")
                            {
                                hotelDetails.Price = lstHotels[i].Rates[j].value * Nights;
                            }
                            else
                            {
                                hotelDetails.Price = lstHotels[i].Rates[j].value;
                            }
                            lstHotelDetails.Add(hotelDetails);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogFile(ex.Message.ToString());
            }
            return lstHotelDetails;
        }
    }
}
