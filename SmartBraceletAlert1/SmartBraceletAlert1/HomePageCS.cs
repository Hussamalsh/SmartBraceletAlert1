using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class HomePageCS : ContentPage
    {




        public HomePageCS()
        {
            Title = "Home Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Home data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }






    }
}
