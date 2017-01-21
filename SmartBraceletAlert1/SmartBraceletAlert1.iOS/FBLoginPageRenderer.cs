using SmartBraceletAlert1;
using SmartBraceletAlert1.iOS;
using System;
using System.Json;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FBLoginPage), typeof(FBLoginPageRenderer))]

namespace SmartBraceletAlert1.iOS
{
    public class FBLoginPageRenderer : PageRenderer
    {
        private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var auth = new OAuth2Authenticator(
                clientId: App.AppId,
                scope: App.ExtendedPermissions,
                authorizeUrl: new Uri(App.AuthorizeUrl),
                redirectUrl: new Uri(App.RedirectUrl));

            auth.AllowCancel = false;

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
                    //AccountStore.Create().Save(eargs.Account, "Facebook");



                    await App.Current.MainPage.Navigation.PopModalAsync();
                    App.IsLoggedIn = true;
                    ((App)App.Current).SaveProfile();
                    ((App)App.Current).PresentMainPage();
                }
            };

            UIViewController vc = auth.GetUI();

            ViewController.AddChildViewController(vc);
            ViewController.View.Add(vc.View);

            vc.ChildViewControllers[0].NavigationItem.LeftBarButtonItem = new UIBarButtonItem(
                UIBarButtonSystemItem.Cancel, async (o, eargs) => await App.Current.MainPage.Navigation.PopModalAsync()
            );
        }
    }
}