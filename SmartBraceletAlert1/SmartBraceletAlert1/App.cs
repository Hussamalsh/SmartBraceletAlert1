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

        public static string EVENT_LAUNCH_LOGIN_PAGE = "EVENT_LAUNCH_LOGIN_PAGE";
        public static string EVENT_LAUNCH_MAIN_PAGE = "EVENT_LAUNCH_MAIN_PAGE";

        public static IAuthenticate Authenticator { get; private set; } //initialize the interface with a platform-specific implementation
        public static App Current;

        public void ShowMainPage()
        {
            MainPage = new MainPageCS();
        }


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
            Current = this;
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

            //MainPage = new MainPageCS();
            MainPage = new LoginPage(Current);
            // The root page of your application
            //MainPage = new NavigationPage(new LoginPage(Current));

            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_LOGIN_PAGE, SetLoginPageAsRootPage);
            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_MAIN_PAGE, SetMainPageAsRootPage);
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


        private void SetLoginPageAsRootPage(object sender)
        {
            MainPage = new LoginPage(Current);
        }

        private void SetMainPageAsRootPage(object sender)
        {
            MainPage = new MainPageCS();
        }



    }
}
