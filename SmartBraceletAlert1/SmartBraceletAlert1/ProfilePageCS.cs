using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class ProfilePageCS : ContentPage
    {
        public ProfilePageCS()
        {
            Title = "Profile Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Profile data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
