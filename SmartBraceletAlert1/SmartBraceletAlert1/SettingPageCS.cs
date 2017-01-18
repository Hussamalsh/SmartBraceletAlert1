using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class SettingPageCS : ContentPage
    {




        public SettingPageCS()
        {
            Title = "Inställningar";
            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot

                {
                    
                    new TableSection("Här ändrar du inställningarna för Smart Band Alert")
                    {
                        new SwitchCell
                        {
                            Text = "Aktivt armband:"
                        },
                        new SwitchCell
                        {
                            Text = "Ta emot push-notifikationer:"
                        },
                        new SwitchCell
                        {
                            Text = "Ljud-larm vid aktivering:"
                        }
                }

            }
            };
            Button batteryButton = new Button
            {
                Text = "Batteristatus",
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Content = new StackLayout
            {
                Children =
                {
                   batteryButton,
                   tableView
                }
            };

        }






    }
}
