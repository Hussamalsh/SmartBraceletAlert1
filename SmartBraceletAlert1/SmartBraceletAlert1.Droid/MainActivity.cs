using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Android.Webkit;
using Xamarin.Auth;
using System.Collections.Generic;
using System.Linq;

namespace SmartBraceletAlert1.Droid
{
    [Activity(Label = "SmartBraceletAlert1", Icon = "@drawable/icon", Theme = "@style/MainTheme", /*MainLauncher = true,*/ ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , IAuthenticate
    {
        public async Task<bool> AuthenticateAsync()
        {
            bool success = false;
            try
            {
                if (user == null)
                {
                    // The authentication provider could also be Facebook, Twitter, or Microsoft
                    user = await SBAManager.DefaultManager.CurrentClient.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                    if (user != null)
                    {
                        CreateAndShowDialog(string.Format("You are now logged in - {0}", user.UserId), "Logged in!");
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Authentication failed");
            }
            return success;
        }

        public async Task<bool> LogoutAsync()
        {
            bool success = false;
            try
            {
                if (user != null)
                {
                    CookieManager.Instance.RemoveAllCookie();
                    await SBAManager.DefaultManager.CurrentClient.LogoutAsync();
                    CreateAndShowDialog(string.Format("You are now logged out - {0}", user.UserId), "Logged out!");
                }
                user = null;
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Logout failed");
            }

            return success;
        }

        MobileServiceUser user;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            //App.Init((IAuthenticate)this);
            // On Android:
            var accounts = AccountStore.Create(this).FindAccountsForService("Facebook");
            var account = accounts.FirstOrDefault();
            if(account != null)
                App.IsLoggedIn = true;
            // IEnumerable<Account> accounts = AccountStore.Create(this).FindAccountsForService("Facebook");
            // var account = accounts.FirstOrDefault();


            LoadApplication(new App());
        }

        void CreateAndShowDialog(string message, string title)
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.SetNeutralButton("OK", (sender, args) => {
            });
            builder.Create().Show();
        }


    }
}

