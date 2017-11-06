using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.iOS;
using ContactApp.Models;
using ContactApp.Services;
using Contacts;
using Foundation;
using UIKit;

namespace ContactApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            Xamarin.Forms.DependencyService.Register<ContactService>();
           
            return base.FinishedLaunching(app, options);
        }

    }
}
