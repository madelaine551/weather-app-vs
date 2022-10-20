using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using project1.services;
using Xamarin.Essentials;

namespace project1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        APIService api = new APIService();

        PreferenceService preference = new PreferenceService();

        string unit;
        public MainPage()
        {
            InitializeComponent();

            BackgroundColor = preference.SetTheme(Preferences.Get("MyAppTheme","Light"));

            DefaultCityPerth();
        }

        public async void DefaultCityPerth()
        {
            unit = Preferences.Get("MyWeatherUnit", "metric");

            string condition = await api.GetCondition("Perth");
            if (condition == "Clouds")
            {
                BackgroundImageSource = "clouds.jpg";
            }
            else if (condition == "Rain")
            {
                BackgroundImageSource = "rain.jpg";
            }
            else
            {
                //clear
                BackgroundImageSource = "clear.jpeg";
            }

            cityImg.Source = "Perth.jpg";
            currentTemperature.Text = "Current Temperature: " + await api.GetCurrentTemp("Perth", unit);
            cityDetails.Text = await api.GetCityDetails("Perth");
            minTemp.Text = await api.GetMinTemp("Perth", unit);
            maxTemp.Text = await api.GetMaxTemp("Perth", unit);
            humidity.Text = "Humidity: " + await api.GetHumidity("Perth");
            windSpeed.Text = "Wind Speed: " + await api.GetWindSpeed("Perth", unit);
            pressure.Text = "Pressure: " + await api.GetPressure("Perth");

        }

        public async void UpdateCity(string city)
        {
            unit = Preferences.Get("MyWeatherUnit", "metric");

            string condition = await api.GetCondition(city);
            if (condition == "Clouds")
            {
                BackgroundImageSource = "clouds.jpg";
            }
            else if (condition == "Rain")
            {
                BackgroundImageSource = "rain.jpg";
            }
            else
            {
                //clear
                BackgroundImageSource = "clear.jpeg";
            }

            cityImg.Source = ImageSource.FromFile($"{city}.jpg");
            currentTemperature.Text = "Current Temperature: " + await api.GetCurrentTemp(city, unit);
            cityDetails.Text = await api.GetCityDetails(city);
            minTemp.Text = await api.GetMinTemp(city, unit);
            maxTemp.Text = await api.GetMaxTemp(city, unit);
            humidity.Text = "Humidity: " + await api.GetHumidity(city);
            windSpeed.Text = "Wind Speed: " + await api.GetWindSpeed(city, unit);
            pressure.Text = "Pressure: " + await api.GetPressure(city);

        }

        private async void homeButton_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            await Navigation.PushModalAsync(mainPage);
        }

        private async void locationsButton_Clicked(object sender, EventArgs e)
        {
            locationsPage locationsPage = new locationsPage();
            await Navigation.PushModalAsync(locationsPage);
        }

        private async void favouritesButton_Clicked(object sender, EventArgs e)
        {
            favouritesPage favouritesPage = new favouritesPage();
            await Navigation.PushModalAsync(favouritesPage);
        }

        private async void settingsButton_Clicked(object sender, EventArgs e)
        {
            settingsPage settingsPage = new settingsPage();
            await Navigation.PushModalAsync(settingsPage);
        }
    }
}
