JarvisWeather Console Application (Windows)
===========================================

A lightweight Windows console application that fetches the weather from [Yahoo! Weather](http://weather.yahoo.com) and outputs the current conditions and forcast to the console.

Author: [Phil Hawthorne](http://philhawthorne.com)

Special thanks to Eric Hillen on the [CastleOS Forums](http://castleos.com/forum/topic457-help-with-my-morning-wake-up-weather-script.aspx) for the initial code.

Using this Application
----------------------

Save the JarvisWeather.exe file from the compiled folder to your computer. You can use this application by opening Command Prompt on your computer.

From Commnand Prompt, execute JarvisWeather.exe with two command line paramaters

1. Your locations Yahoo! Weather ID. Use a free tool like http://woeid.rosselliot.co.nz to find this out
2. Either `c` for temperatures in Celcius, or `f` for Fahrenheit.



##### Example

To get the weather for Melbourne, Australia in Celcius use the following command
	
	JarvisWeather.exe 1103816 c

The weather for New York in Fahrenheit would be
	
	JarvisWeather.exe 2459115 f


Using with CastleOS
-------------------
[CastleOS](http://castleos.com/) is a Windows based Home Automation controller. You can use JarvisWeather.exe in combination with the C# scripts located in the castleos folder of this repository. With these scripts, you can have the weather read back to you automatically each morning via Text to Speech (TTS).

For more info on how to use these scripts with CastleOS, be sure to check out [my blog post](http://philhawthorne.com/j-a-r-v-i-s-inspired-weather-wake-up-announcement-for-castleos/)
