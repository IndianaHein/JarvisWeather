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

        Location ID
        -----------
        Your Yahoo Weather Location ID. You should use a tool like http://woeid.rosselliot.co.nz/

        Some common place IDs:
        New York USA          = 2459115
        San Francisco USA     = 2487956
        London UK             = 44418
        Melbourne Australia   = 1103816
        Berlin Germany        = 638242
        Amsterdam Netherlands = 727232
        */
        string location_id = "1103816";

        /*
        Weather Unit
        ------------
        Set to c for Celcius, or f for Fahrenheit
        */
        string unit = "c";


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
            p.StartInfo.Arguments = location_id + " " + unit;

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