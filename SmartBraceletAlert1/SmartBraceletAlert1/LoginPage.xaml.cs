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
 

        public  LoginPage()
        {
            InitializeComponent();
            
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
                    Application.Current.MainPage = new MainPageCS();
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
