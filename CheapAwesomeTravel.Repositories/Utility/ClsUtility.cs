using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheapAwesomeTravel.Repositories.Utility
{
    public class ClsUtility
    {
        public static void WriteJSONFile(string inputstring)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string filepath = path + "\\wwwroot\\Log\\";
            string filename = "JSON_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
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
    }
}
