using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace project1.services
{
    class PreferenceService
    {
        public void DegreeSwitch(bool toggled)
        {
            if (toggled == true)
            {
                Preferences.Set("MyWeatherUnit", "imperial");
            }
            else
            {
                Preferences.Set("MyWeatherUnit", "metric");
            }
        }

        public Color SetTheme(string theme)
        {
            switch (theme)
            {
                case "Light":
                    return Color.AntiqueWhite;

                case "Dark":
                    return Color.DarkSlateGray;
            }
            return Color.AntiqueWhite;
        }

        public void LightDarkTheme(bool toggled)
        {
            if (toggled == true)
            {
                Preferences.Set("MyAppTheme", "Dark");
                string themeString = Preferences.Get("MyAppTheme", "Dark");
                SetTheme(themeString);
            }
            else
            {
                Preferences.Set("MyAppTheme", "Light");
                string themeString = Preferences.Get("MyAppTheme", "Light");
                SetTheme(themeString);
            }
        }
    }
}
