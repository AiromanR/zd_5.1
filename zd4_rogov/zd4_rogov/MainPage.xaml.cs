using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace zd4_rogov
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(string username)
        {
            InitializeComponent();
            BarBackgroundColor = Color.Blue;
            Title = $"Привет, {username}!";
            this.Resources.Add(StyleSheet.FromResource("styles.css", IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly));
        }
    }
}
