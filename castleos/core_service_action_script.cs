using System;
using CastleOSCoreService;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
    	The place where you saved JarvisWeather.exe. Default location is set to the CastleOS Core scripts folder

    	Leave the @ at the beginning of the file path!
		*/
		string script_location = @"C:\ProgramData\CastleOS\CastleOS Core Service\Scripts\JarvisWeather.exe";


		/*
		Sonos speaker name
		------------------
		The sonos speaker you would like the announcment output to. Use "all" for all speakers connected to CastleOS
		*/
		string speaker = 'main bedroom';


		/*
		-----------------------------------------
		END SETTINGS - DONT CHANGE ANYTHING BELOW
		-----------------------------------------
		*/
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

		    foreach (KeyValuePair<string, string> pair in ScriptingAPI.GetSonosDevices())
        	{
           
            	if (pair.Key.ToLower().Contains(speaker.ToLower()))
            	{
                ScriptingAPI.Speak(output, pair.Value);
            	}            
        	}
    	}
        catch (Exception ex)
        {
            ScriptingAPI.Speak(ex.Message, "all");
        }
    }
}