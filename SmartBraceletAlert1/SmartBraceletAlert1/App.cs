using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBraceletAlert1
{


    public class App : Application
    {
        public static IAuthenticate Authenticator { get; private set; } //initialize the interface with a platform-specific implementation

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        bool authenticated = false;

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Refresh items only when authenticated.
            if (authenticated == true)
            {
                // Set syncItems to true in order to synchronize the data
                // on startup when running in offline mode.
                await RefreshItems(true, syncItems: false);

                // Hide the Sign-in button.
                this.loginButton.IsVisible = false;
            }
        }*/


        public App()
        {
            // The root page of your application
            /*  var content = new ContentPage
              {
                  Title = "SmartBraceletAlert1",
                  Content = new StackLayout
                  {
                      VerticalOptions = LayoutOptions.Center,
                      Children = {
                          new Label {
                              HorizontalTextAlignment = TextAlignment.Center,
                              Text = "Welcome to Xamarin Forms!"
                          }
                      }
                  }
              };*/

            checklogin();

           MainPage = new MainPageCS();
           

            // The root page of your application
            //MainPage = new NavigationPage(new LoginPage());
        }



        async void checklogin()
        {



            try
            {

                if (App.Authenticator != null)
                {
                    authenticated = await App.Authenticator.AuthenticateAsync();
                }

                if (!authenticated)
                {
                    MainPage = new LoginPage();
                    //Navigation.InsertPageBefore(new MainPageCS(), this);
                    //await Navigation.PopAsync();
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {

                    //messageLabel.Text = "Authentication cancelled by the user";
                }
            }
            catch (Exception)
            {
                //messageLabel.Text = "Authentication failed";
            }




        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
