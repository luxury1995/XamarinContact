using System;
using ContactApp.Enum;
using ContactApp.EventArg;
using Xamarin.Forms;

namespace ContactApp.Views.PartialView
{
    public partial class Item1 : ContentView
    {
        public event EventHandler<PhoneCellArgs> OnItem1Tap;
        public Item1()
        {
            InitializeComponent();
            ButtonCall.BindingContext = this;
            ButtonMessage.BindingContext = this;
            ButtonMessage.Source = ImageSource.FromResource("ContactApp.Drawable.message.png");
            ButtonCall.Source = ImageSource.FromResource("ContactApp.Drawable.call_ic.png");
            TapGestureRecognizer _callTap = new TapGestureRecognizer();
            TapGestureRecognizer _messageTap = new TapGestureRecognizer();
            _messageTap.Tapped += _messageTap_Tapped;
            _callTap.Tapped += _callTap_Tapped;;
            ButtonCall.GestureRecognizers.Add(_callTap);
            ButtonMessage.GestureRecognizers.Add(_messageTap);
        }

        void _callTap_Tapped(object sender, EventArgs e)
        {
            OnItem1Tap?.Invoke(this, new PhoneCellArgs(PhoneNumber.Text, EnumEvent.Call));
        }

        void _messageTap_Tapped(object sender, EventArgs e)
        {
            OnItem1Tap?.Invoke(this, new PhoneCellArgs(PhoneNumber.Text, EnumEvent.Message));
        }
    }
}
