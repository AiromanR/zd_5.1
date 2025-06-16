using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_rogov
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Welcome()) { BarBackgroundColor = Color.Gray };
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
