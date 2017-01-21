using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SmartBraceletAlert1;
using SmartBraceletAlert1.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using System.Json;

[assembly: ExportRenderer(typeof(FBLoginPage), typeof(FBLoginPageRenderer))]


namespace SmartBraceletAlert1.Droid
{
    public class FBLoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            LoginToFacebook(false);
        }

        void LoginToFacebook(bool allowCancel)
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: App.AppId,
                scope: App.ExtendedPermissions,
                authorizeUrl: new Uri(App.AuthorizeUrl),
                redirectUrl: new Uri(App.RedirectUrl));

            auth.AllowCancel = allowCancel;

            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.Completed += async (s, eargs) =>
            {
                if (!eargs.IsAuthenticated)
                {
                    return;
                }
                else
                {

                    var token = eargs.Account.Properties["access_token"];


                    // Now that we're logged in, make a OAuth2 request to get the user's info.
                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=id,name,picture,email"), null, eargs.Account);
                    var result = await request.GetResponseAsync();

                    string resultText = result.GetResponseText();
                    var obj = JsonValue.Parse(resultText);
                    Console.WriteLine(token + " -=- " + resultText);

                    App.FacebookId = obj["id"];
                    App.FacebookName = obj["name"];
                    App.EmailAddress = obj["email"];
                    App.ProfilePic = obj["picture"]["data"]["url"];
                    // On Android: store the account
                    AccountStore.Create(Context).Save(eargs.Account, "Facebook");


                    await App.Current.MainPage.Navigation.PopModalAsync();
                    App.IsLoggedIn = true;
                    ((App)App.Current).SaveProfile();
                    ((App)App.Current).PresentMainPage();
                }
            };


            var intent = auth.GetUI(activity);
            activity.StartActivity(intent);
        }
    }
}