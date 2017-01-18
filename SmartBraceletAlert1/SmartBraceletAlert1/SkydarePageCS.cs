using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class AboutPageCS : ContentPage
    {




        public AboutPageCS()
        {
            Title = "Skydare Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Skydare list data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }






    }
}
