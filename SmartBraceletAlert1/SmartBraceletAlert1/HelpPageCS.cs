using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class HelpPageCS : ContentPage
    {




        public HelpPageCS()
        {
            Title = "Help Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Help list data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }






    }
}
