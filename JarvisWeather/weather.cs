using System;
using ForecastIO;

public class MyProgram
{
    public static void Main(string[] args)
    {
        MyScript script = new MyScript();
        if (args == null || args.Length < 1 || args[0] == null || args[1] == null)
        {
            return;
        }
        script.setCity(args[1]);
        float Lat = float.Parse(args[2]);
        float Long = float.Parse(args[3]);
        script.setKey(args[0]);
        script.setLat(Lat);
        script.setLong(Long);

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
    string city = "";

    string api_key;
    float Lat;
    float Long;

    public void setCity(string mycity)
    {
        city = mycity;
    }

    public void setLat(float lat)
    {
        Lat = lat;
    }

    public void setLong(float Long1)
    {
        Long = Long1;
    }

    public void setKey(string Key)
    {
        api_key = Key;
    }

    public void Main(string args)
    {

    }

    public void getWeather()
    {
        var request = new ForecastIORequest(api_key, Lat, Long, Unit.auto);
        ForecastIOResponse response = request.Get();

        Temperature = Math.Round(response.currently.temperature).ToString();
        Condition = response.currently.summary;
        Town = city;
        TFCond = response.daily.data[0].summary;
        TFHigh = Math.Round(response.daily.data[0].temperatureMax).ToString();
        TFLow = Math.Round(response.daily.data[0].temperatureMin).ToString();

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