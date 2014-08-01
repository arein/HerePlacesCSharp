C# Here Places REST API Wrapper
===============

This Repository allows you to easily integrate the [Here Places REST API](https://developer.here.com/rest-apis/documentation/places/topics/overview.html) into your C# apps.

Platforms
===============
The API was tested on Windows Phone 8 and Windows Phone 8.1. It is built using the [async programming model](http://msdn.microsoft.com/en-us/library/vstudio/hh191443.aspx).

Account
===============
In order to use the Here Places API you need a [Nokia Developer Account](https://developer.nokia.com/Profile/Join.xhtml) and you to get [Here credentials](https://developer.here.com/myapps/create) for your app.

Installation
===============

In the Package Manager type Install-Package HerePlacesCSharp 

Or download the source and build the project yourself.

Usage
===============

``` c#
PlacesService service = new PlacesService("my app id", "my app token");

try
{
    List<Place> places = await service.ListPlacesAroundLocation(new GeoCoordinate(40.75874,-73.978674)); // Random Place in NY

    if (places.Count > 0)
    {
        System.Diagnostics.Debug.WriteLine(string.Format("Title: {0}, Distance from the provided coordinate: {1}", places[0].Title, places[0].Distance));
    }
    else
    {
		// No places found for the coordinate
    }
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e.Message); // An error occured e.g. no internet
}
```

Contributing
===============
You're invited to contribute to the repo. There are a few tasks that could be done:
* Add support for further Platforms
* Add further options e.g. limit the category type or specify the number of results

Apps Using this Library
===============
* [Track My Life] (https://tml.me)