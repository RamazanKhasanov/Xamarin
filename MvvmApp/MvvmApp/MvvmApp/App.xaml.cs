using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmApp.Views;
using System.IO;

namespace MvvmApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
         
            MainPage = new NavigationPage(new FlowersListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
