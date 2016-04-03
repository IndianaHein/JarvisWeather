using System;
using CastleOSKinectService; 
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

class MyScript
{
    public void Main(string[] args)
    {        
        /*
        Change the following values for your setup
        ------------------------------------------

        Forecast.io API Key
        -------------------

        Your Forecast.io API Key. They're free! https://developer.forecast.io/
        */
        string api_key = "";


        /*
        Location Name
        -------------

        The name of the location. Ie "Melbourne" or "Work"
        */
        string location_name = "Melbourne";


        /*
        Location Latitude and Longitude
        -------------------------------

        Some common place IDs:
        New York USA          = 40.7128 -74.0059 
        San Francisco USA     = 37.7749 -122.4194
        London UK             = 51.5074 -0.1278
        Melbourne Australia   = -37.8131 144.9633
        Berlin Germany        = 52.5200 13.4050
        Amsterdam Netherlands = 52.3702 4.8952
        */
        string location_lat = "-37.8131";
        string location_long = "144.9633";


        /*
        Jarvis Weather Report Location
        ------------------------------
        The place where you saved JarvisWeather.exe. Default location is set to the CastleOS Kinect scripts folder

        Leave the @ at the beginning of the file path!
        */
        string script_location = @"C:\ProgramData\CastleOS\CastleOS Kinect Service\Scripts\JarvisWeather.exe";
        
        try
        {
            Process p = new Process();
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = script_location;
            p.StartInfo.Arguments = api_key + " " + location_name " " + location_lat + " " + location_long;

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            
            string output = p.StandardOutput.ReadToEnd();

            ScriptingAPI.Speak(output);	
        }
        catch (Exception ex)
        {
            ScriptingAPI.Speak(ex.Message);
        }
    }
}