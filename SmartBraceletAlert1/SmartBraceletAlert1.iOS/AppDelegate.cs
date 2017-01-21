using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Auth;

namespace SmartBraceletAlert1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ApplyStyling(); //-

            global::Xamarin.Forms.Forms.Init();

            //ImageCircleRenderer.Init(); //-
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UIApplication.SharedApplication.SetStatusBarHidden(false, UIStatusBarAnimation.None);


            IEnumerable<Account> accounts = AccountStore.Create().FindAccountsForService("Facebook");
            var account = accounts.FirstOrDefault();
            if (account != null)
                App.IsLoggedIn = true;


            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }



    static void ApplyStyling()
    {
        //Styling NavigationItem
        UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(122, 204, 200);
        //bar background
        UINavigationBar.Appearance.TintColor = UIColor.White;
        //Tint color of button items
        UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
        {
            Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
            TextColor = UIColor.White
        });

        //Styling Misc Controls
        UISwitch.Appearance.ThumbTintColor = UIColor.FromRGB(228, 95, 86);
        UISwitch.Appearance.TintColor = UIColor.FromRGB(122, 204, 200);
        UISwitch.Appearance.OnTintColor = UIColor.FromRGB(122, 204, 200);

        //Styling Button
        UIButton.Appearance.TintColor = UIColor.FromRGB(228, 95, 86);
        UIButton.Appearance.SetTitleColor(UIColor.FromRGB(228, 95, 86), UIControlState.Normal);
    }



    }





}
