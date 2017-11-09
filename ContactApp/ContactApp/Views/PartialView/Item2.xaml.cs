using System;
using Xamarin.Forms;
using ContactApp.EventArg;
using ContactApp.Enum;

namespace ContactApp.Views.PartialView
{
    public partial class Item2 : StackLayout
    {
        public event EventHandler<AddressCellArgs> OnItem2Tap;

        public Item2()
        {
            InitializeComponent();
            ButtonSendEmail.BindingContext = this;
            ButtonSendEmail.Source = ImageSource.FromResource("ContactApp.Drawable.message.png");
            TapGestureRecognizer _emailTap = new TapGestureRecognizer();
            _emailTap.Tapped += _email_tap;
            ButtonSendEmail.GestureRecognizers.Add(_emailTap);
        }

        private void _email_tap(object sender, EventArgs e)
        {
            OnItem2Tap?.Invoke(this, new AddressCellArgs(EmailAdress.Text, EnumEvent.Email));
        }
    }
}
