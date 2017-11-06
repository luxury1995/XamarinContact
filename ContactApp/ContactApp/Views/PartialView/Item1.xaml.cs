using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContactApp.Views.PartialView
{
    public partial class Item1 : StackLayout
    {
        public Item1()
        {
            InitializeComponent();
            ButtonChat.Source = ImageSource.FromResource("ContactApp.Drawable.message.png");
            ButtonCall.Source = ImageSource.FromResource("ContactApp.Drawable.call_ic.png");
        }
    }
}
