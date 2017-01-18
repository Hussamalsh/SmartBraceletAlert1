using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public class MasterPageCS : ContentPage
    {

        public ListView ListView { get { return listView; } }

        ListView listView;


        public MasterPageCS()
        {

            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "contacts.png",
                TargetType = typeof(HomePageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Skydare",
                IconSource = "todo.png",
                TargetType = typeof(AboutPageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Profile",
                IconSource = "reminders.png",
                TargetType = typeof(ProfilePageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Setting",
                IconSource = "Setting.png",
                TargetType = typeof(SettingPageCS)
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = "Help",
                IconSource = "Help.png",
                TargetType = typeof(HelpPageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "about.png",
                TargetType = typeof(AbouttPageCS)
            });


            listView = new ListView
            {
                ItemsSource = masterPageItems,

                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),

                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            Padding = new Thickness(0, 40, 0, 0);
            Icon = "hamburger.png";
            Title = "Smart Bracelet Alert App";

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {
                             listView
                           }

            };


        }






    }
}
