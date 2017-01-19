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
        Label resultsLabel;
        SearchBar searchBar;



        public AboutPageCS()
        {
            Title = "Skyddare";
            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,

                Root = new TableRoot
                {


                    new TableSection("Här väljer du skyddare")
                    {
                        new SwitchCell
                        {
                            Text = "Alla användare av den här applikationen:"
                        }
                }

            }
            };
            Label resultsLabel;
            resultsLabel = new Label
            {
                Text = "Result will appear here.",
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            searchBar = new SearchBar
            {
                Placeholder = "Sök personer...",
                SearchCommand = new Command(() => { resultsLabel.Text = "Result: " + searchBar.Text + " is what you asked for."; })
            };

            Content = new StackLayout
            {
                Children =
                {
                   tableView,
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "SearchBar",
                        FontSize = 50
                    },
                    searchBar,
                    new ScrollView
                    {
                        Content = resultsLabel,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }






    }
}
