using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class SkyddarePageCS : ContentPage
    {
        Label resultsLabel;
        SearchBar searchBar;



        public SkyddarePageCS()
        {
            Title = "Skyddare";

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
            /*
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
            };*/
            Switch sw = new Switch
            {
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            Label lb = new Label
            {
                Text = " Alla användare av den här applikationen:",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            



            Content = new StackLayout
            {
                
                Children =
                {
                    new StackLayout {
                        Padding = new Thickness(10,15,10,0),
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                        lb, sw
                        }
                    },
                    searchBar
                }
            };

        }






    }
}
