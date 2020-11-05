using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;
using AppTCC.Services;
using AppTCC.Models;

namespace AppTCC.Views
{
    public partial class MapsPage : ContentPage
    {
        private SellingPointService _sellingPointService = new SellingPointService();
        List<Place> placesList = new List<Place>();

        public MapsPage()
        {
            InitializeComponent();

            Task.Delay(2000);
            UpdateMap();
        }        

        private async void UpdateMap()
        {
            try
            {
                List<SellingPoints> sellingPoints = await _sellingPointService.GetSellingPoints();
                
                foreach (var place in sellingPoints)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.Name,
                        Address = place.Vicinity,
                        Location = new Location() { lat = (float)place.Latitude, lng = (float)place.Longitude },
                        Position = new Position((double)place.Latitude, (double)place.Longitude)
                    });
                }

                Place currentLocation = await GetLastLocation();

                placesList.Add(currentLocation);

                MyMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(currentLocation.Location.lat, currentLocation.Location.lng), Distance.FromKilometers(100)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }

        public async Task<Place> GetLastLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Place place = new Place()
                    {
                        PlaceName = "Você está aqui!",
                        Address = "Endereço",
                        Location = new Location()
                        {
                            lat = Convert.ToSingle(location.Latitude),
                            lng = Convert.ToSingle(location.Longitude)
                        },
                        Position = new Position(location.Latitude, location.Longitude)
                    };

                    return place;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível pegar localização atual: " + ex.Message);
            }

            return null;        
        }
    }
}