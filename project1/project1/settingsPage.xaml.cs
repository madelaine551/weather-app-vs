using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using project1.services;

namespace project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class settingsPage : ContentPage
    {
        PreferenceService preference = new PreferenceService();

        public settingsPage()
        {
            InitializeComponent();

            BackgroundColor = preference.SetTheme(Preferences.Get("MyAppTheme", "Light"));
        }

        private void degreesSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (degreesSwitch.IsToggled == true)
            {
                preference.DegreeSwitch(degreesSwitch.IsToggled);
            }
            else
            {
                preference.DegreeSwitch(degreesSwitch.IsToggled);
            }
        }

        private void lightSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (lightSwitch.IsToggled == true)
            {
                preference.LightDarkTheme(lightSwitch.IsToggled);
            }
            else{
                preference.LightDarkTheme(lightSwitch.IsToggled);
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