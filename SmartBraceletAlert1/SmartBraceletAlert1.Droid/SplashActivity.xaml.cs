using SmartBraceletAlert1.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;






namespace SmartBraceletAlert1.Droid
{
    public partial class SplashActivity : TemplatedPage
    {
        bool delayForSplash = true;

        public SplashActivity()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (delayForSplash)
                // delay for a few seconds on the splash screen
                await Task.Delay(3000);
            /*
            // if a data partition phrase has not yet been set
            if (string.IsNullOrWhiteSpace(Settings.DataPartitionPhrase))
            {
                // modally push a new SetupPage wrapped in a NavigationPage
                var navPage = new NavigationPage(new SetupPage())
                {
                    BarBackgroundColor = Color.FromHex("547799")
                };

                navPage.BarTextColor = Color.White;

                await Navigation.PushModalAsync(navPage);

                delayForSplash = false;
            }
            else
            {
                // create a new NavigationPage, with a new AcquaintanceListPage set as the Root
                var navPage = new NavigationPage(
                    new AcquaintanceListPage()
                    {
                        Title = "Acquaintances",
                        BindingContext = new AcquaintanceListViewModel()
                    });

                navPage.BarTextColor = Color.White;

                // set the MainPage of the app to the navPage
                
                Application.Current.MainPage = navPage;*/

        
        }
    }
}












/*
namespace SmartBraceletAlert1.Droid
{
    public partial class SplashActivity : TemplatedPage
    {
        public SplashActivity()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(500); //Let's wait awhile...
            System.Threading.Thread.CurrentThread.Abort();
        }

    }
}

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

namespace SmartBraceletAlert1.Droid
{

    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            setContentView(R.layout.SplashActivity);
            System.Threading.Thread.Sleep(500); //Let's wait awhile...
            this.StartActivity(typeof(MainActivity));
        }
    }
*/