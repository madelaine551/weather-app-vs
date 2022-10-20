using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using project1.models;
using project1.services;
using Xamarin.Essentials;

namespace project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class favouritesPage : ContentPage
    {
       
        PreferenceService preference = new PreferenceService();

        FileService favServices = new FileService("favourites.txt", "MyFolder");
        public favouritesPage()
        {
            InitializeComponent();

            BackgroundColor = preference.SetTheme(Preferences.Get("MyAppTheme", "Light"));

            InitialiseUI();

        }

        private async void InitialiseUI()
        {
            List<CityModel> cities = new List<CityModel>();

            if(await favServices.ReadJSON() != null)
            {
                cities.AddRange(await favServices.ReadJSON());
            }

            foreach (CityModel city in cities)
            {
                Label cityLabel = new Label()
                {
                    Text = city.City,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                favouriteCollection.Children.Add(cityLabel);
            }

            foreach (CityModel city in cities)
            {
                favouritePicker.Items.Add(city.City);
            }

        }

        private async void unfavouriteButton_Clicked(object sender, EventArgs e)
        {

            if ((string)favouritePicker.SelectedItem == null)
            {
                await DisplayAlert("Null Value", "Please pick a city.", "OK");
            }
            else
            {
                if(await favServices.ReadJSON() == null)
                {
                    List<CityModel> setDefault = new List<CityModel>() { new CityModel("Perth", true) };
                    await favServices.WriteJSON(setDefault);
                }
                string favCity= (string)favouritePicker.SelectedItem;
                
                List<CityModel> cities = await favServices.ReadJSON();

                cities.RemoveAll(city => city.City==favCity);

                await favServices.WriteJSON(cities);

                await DisplayAlert("Unfavourite", "The city has been removed.\n Please refresh the page.", "OK");
            }

            
            
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