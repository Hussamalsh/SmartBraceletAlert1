using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class AbouttPageCS : ContentPage
    {
        public AbouttPageCS()
        {
            Title = "About Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "About data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
