using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContactApp.Views.PartialView
{
    public partial class Item2 : StackLayout
    {
        public Item2()
        {
            InitializeComponent();
            ButtonMessage.Source = ImageSource.FromResource("ContactApp.Drawable.message.png");
        }
    }
}
