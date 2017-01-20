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

        public App()
        {
            checklogin();
            MainPage = new MainPageCS();           
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
