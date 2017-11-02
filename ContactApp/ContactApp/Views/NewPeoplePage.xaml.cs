using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPeoplePage : ContentPage
    {
        public NewPeoplePage()
        {
            InitializeComponent();
            ImageButton.Source = ImageSource.FromResource("ContactApp.Drawable.icon-image-128.png");
        }
    }
}
