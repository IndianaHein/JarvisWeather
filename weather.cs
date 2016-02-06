using System;
using System.Xml;

public class MyProgram
{
    public static void Main(string[] args)
    {
        MyScript script = new MyScript();
        if (args == null || args.Length < 1 || args[0] == null || args[1] == null)
        {
            return;
        }

        script.setCity(args[0]);
        script.setUnits(args[1]);

        script.getWeather();

    }
}

public class MyScript
{
    string Temperature = "";
    string Condition = "";
    string Town = "";
    string TFCond = "";
    string TFHigh = "";
    string TFLow = "";

    string units = "c";
    string city = "";

    public void setUnits(string unit)
    {
        units = unit;
    }

    public void setCity(string cityid)
    {
        city = cityid;
    }

    public void Main(string args)
    {

    }

    public void getWeather()
    {
        XmlDocument wData = new XmlDocument();
        wData.Load("http://weather.yahooapis.com/forecastrss?w=" + city + "&u=" + units);

        XmlNamespaceManager manager = new XmlNamespaceManager(wData.NameTable);
        manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

        XmlNode channel = wData.SelectSingleNode("rss").SelectSingleNode("channel");
        XmlNodeList node = wData.SelectNodes("/rss/channel/item/yweather:forecastr", manager);

        XmlNode item = channel.SelectSingleNode("item");

        //Current Temperature
        Temperature = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;
        Condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;

        Town = channel.SelectSingleNode("yweather:location", manager).Attributes["city"].Value;

        TFCond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["text"].Value;

        TFHigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;

        TFLow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;

        //Should we say Good Morning, Afternoon or Evening?
        TimeSpan morning_end = new TimeSpan(12, 00, 0); //10am
        TimeSpan afternoon_end = new TimeSpan(18, 00, 0); //7pm
        TimeSpan now = DateTime.Now.TimeOfDay;
        string greeting = "Good Morning";
        if (now > afternoon_end)
            greeting = "Good Evening";
        else if (now > morning_end)
            greeting = "Good Afternoon";


        Console.WriteLine(greeting + ". The current weather in " + Town + " is " + Condition + " at " + Temperature + " degrees. Today is expected to be " + TFCond + " with a top of " + TFHigh + ", and a low of " + TFLow);
        return;
    }
}