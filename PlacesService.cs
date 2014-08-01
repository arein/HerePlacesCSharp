using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlacesApi.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PlacesApi
{
    public class PlacesService
    {
        private static string baseUrl = "http://places.nlp.nokia.com/places/v1/discover/around";
        private string appId;
        private string appToken;

        public PlacesService(string appId, string appToken)
        {
            this.appId = appId;
            this.appToken = appToken;
        }

        public async Task<List<Place>> ListPlacesAroundLocation(GeoCoordinate coordinate)
        {
            var rawPlaces = await this.GetRawPlaces(coordinate);
            Response response = JsonConvert.DeserializeObject<Response>(rawPlaces);

            return (from Place p in response.Results.Places
                    orderby p.Distance ascending
                    where p.Position != null
                    select p).ToList(); // Order By Distance
        }

        private Task<string> GetRawPlaces(GeoCoordinate coordinate)
        {
            var tcs = new TaskCompletionSource<string>();

            var client = new WebClient();
            client.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    tcs.SetResult(e.Result);
                }
                else
                {
                    tcs.SetException(e.Error);
                }
            };

            client.DownloadStringAsync(this.GetPlaceQuery(coordinate));

            return tcs.Task;
        }

        private Uri GetPlaceQuery(GeoCoordinate coordinate)
        {
            return new Uri(string.Format("{0}?app_id={1}&app_code={2}&at={3},{4};u=100&size=100&tf=plain",
                baseUrl,
                appId,
                appToken,
                coordinate.Latitude.ToString(CultureInfo.InvariantCulture),
                coordinate.Longitude.ToString(CultureInfo.InvariantCulture)));
        }
    }
}
