using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {
        bool authenticated = false;
 

        public  LoginPage()
        {
            Title = "Login";
            InitializeComponent();
            
        }


        ICommand _doFacebookLogin;
        public ICommand DoFacebookLogin
        {
            get
            {
                _doFacebookLogin = _doFacebookLogin ?? new Command(async () => await FacebookLogin());
                return _doFacebookLogin;
            }
        }


        protected async Task FacebookLogin()
        {
            await LoadingLoginNoCancel("Accessing Facebook ...");
            await App.Current.MainPage.Navigation.PushModalAsync(new FBLoginPage());
        }


        async Task LoadingLoginNoCancel(string msg, int time = 500)
        {
            //using (UserDialogs.Instance.Loading(msg, null, null, true, MaskType.Black))
               // await Task.Delay(TimeSpan.FromMilliseconds(time));
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            /* try
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
             }*/


            await FacebookLogin();



        }




    }
}
