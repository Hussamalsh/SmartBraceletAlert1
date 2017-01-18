using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public partial class LoginPage : ContentPage
    {
        bool authenticated = false;

        App mCurrent;
        public  LoginPage(App Current)
        {
            InitializeComponent();
            mCurrent = Current;
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {

                if (App.Authenticator != null)
                {
                    authenticated = await App.Authenticator.AuthenticateAsync();
                }

                if (authenticated)
                {
                    //Navigation.InsertPageBefore(new MainPageCS(), this);
                    //await Navigation.PopAsync();
                    //MainPage = new NavigationPage(new LoginPage());
                    //mCurrent.ShowMainPage();
                    MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_MAIN_PAGE);

                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {
                    messageLabel.Text = "Authentication cancelled by the user";
                }
            }
            catch (Exception)
            {
                messageLabel.Text = "Authentication failed";
            }
        }




    }
}
