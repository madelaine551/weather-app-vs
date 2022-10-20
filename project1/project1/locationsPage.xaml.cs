using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using project1.services;
using project1.models;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class locationsPage : ContentPage
    {
        readonly MainPage main = new MainPage();

        readonly PreferenceService preference = new PreferenceService();

        FileService services = new FileService("locations.txt", "MyFolder");

        FileService favServices = new FileService("favourites.txt", "MyFolder");

        public locationsPage()
        {
            InitializeComponent();

            BackgroundColor = preference.SetTheme(Preferences.Get("MyAppTheme", "Light"));

            InitialiseUI();

            locationPicker.Items.Add("London");
            locationPicker.Items.Add("Paris");
            locationPicker.Items.Add("Berlin");
            locationPicker.Items.Add("Rome");
        }

        private async void InitialiseUI()
        {
            List<CityModel> cities = new List<CityModel>();
            if (await services.ReadJSON() != null)
            {
                cities.AddRange(await services.ReadJSON());
            }

            foreach (CityModel city in cities)
            {
                Label cityLabel = new Label()
                {
                    Text = city.City,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                locationCollection.Children.Add(cityLabel);
            }

        }

        private async void favouriteButton_Clicked(object sender, EventArgs e)
        {
            if ((string)locationPicker.SelectedItem == null)
            {
                await DisplayAlert("Null Value", "Please pick a city.", "OK");
            }
            else
            {
                if (await favServices.ReadJSON() == null)
                {
                    List<CityModel> setDefault = new List<CityModel>() { new CityModel("Perth", true)};
                    await favServices.WriteJSON(setDefault);
                }

                string favCity = (string)locationPicker.SelectedItem;
                List<CityModel> favcities = await favServices.ReadJSON();

                favcities.Add(new CityModel(favCity, true));

                await favServices.WriteJSON(favcities);

                await DisplayAlert("Favourite City", "The favourite city has been added successfully", "OK");

                await Navigation.PushModalAsync(main);
                main.UpdateCity(favCity);
            }
            
        }

        private async void addNewLocation_Clicked(object sender, EventArgs e)
        {

            if ((string)locationPicker.SelectedItem == null)
            {
                await DisplayAlert("Null Value", "Please pick a city.", "OK");
            }
            else
            {
                if (await services.ReadJSON() == null)
                {
                    List<CityModel> setDefault = new List<CityModel>() { new CityModel("Perth", true) };
                    await services.WriteJSON(setDefault);
                }

                string newCity = (string)locationPicker.SelectedItem;
                List<CityModel> cities = await services.ReadJSON();
                cities.Add(new CityModel(newCity, false));

                await services.WriteJSON(cities);

                await DisplayAlert("Add New Location", "The new city has been added successfully.", "OK");

                await Navigation.PushModalAsync(main);
                main.UpdateCity(newCity);
            }
            
        }

        private async void removeLocation_Clicked(object sender, EventArgs e)
        {
            if ((string)locationPicker.SelectedItem == null)
            {
                await DisplayAlert("Null Value", "Please pick a city.", "OK");
            }
            else
            {
                string newCity = (string)locationPicker.SelectedItem;

                List<CityModel> cities = await services.ReadJSON();
                cities.RemoveAll(city => city.City == newCity);

                await services.WriteJSON(cities);

                await DisplayAlert("Remove Location", "The city has been removed successfully.\n Please refresh the page.", "OK");
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