JarvisWeather Console Application (Windows)
===========================================

A lightweight Windows console application that fetches the weather from [Forecast.io](http://forecast.io) and outputs the current conditions and forecast to the console.

Author: [Phil Hawthorne](http://philhawthorne.com)

About this Application
----------------------

This application takes command line arguments, and then returns a weather forecast summary which can be read out over a text-to-speech system. For more information, please see [my blog](http://philhawthorne.com/j-a-r-v-i-s-inspired-weather-wake-up-announcement-for-castleos/)

Using this Application
----------------------

Download and extract the JarvisWeather.zip file from the compiled folder to your computer. Extract the zip file somewhere easy to remember on your Computer.

From Command Prompt navigate the extracted folder, and execute JarvisWeather.exe with the following command line paramaters:

1. A [forecast.io API Key](https://developer.forecast.io/) (they're free!) 
2. The name of your location (ie the name of your city)
3. Your locations Latitude (use Google for this)
4. Your locations Longitude (use Google for this)

**Note:** In version 1.1 the temperature unit (Celcius or Fahrenheit) will be chosen based on the location.


##### Example

To get the weather for Melbourne, Australia use the following command
	
	JarvisWeather.exe <API_KEY> -37.8131 144.9633 

The weather for New York would be
	
	JarvisWeather.exe <API_KEY> 40.7128 -74.0059 


Using with CastleOS
-------------------
[CastleOS](http://castleos.com/) is a Windows based Home Automation controller. You can use JarvisWeather.exe in combination with the C# scripts located in the castleos folder of this repository. With these scripts, you can have the weather read back to you automatically each morning via Text to Speech (TTS).

For more info on how to use these scripts with CastleOS, be sure to check out [my blog post](http://philhawthorne.com/j-a-r-v-i-s-inspired-weather-wake-up-announcement-for-castleos/)

Special Thanks
--------------

Eric Hillen on the [CastleOS Forums](http://castleos.com/forum/topic457-help-with-my-morning-wake-up-weather-script.aspx) for the initial idea.

[f0xy's C# Forecast.io Library](https://github.com/f0xy/forecast.io-csharp)