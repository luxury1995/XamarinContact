using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ContactApp.Services;
using ContactApp.Droid;
using ContactApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Android.Provider;
using System.Collections.Generic;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace ContactApp.Droid
{
    [Activity(Label = "ContactApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ContactService
    {
        private ObservableCollection<Contact> Contacts { get; set; }

        public Task<ObservableCollection<Contact>> GetContacts()
        {
            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri
              };
            var cursor = Application.Context.ContentResolver.Query(uri, projection, null, null, null);


            string id = cursor.GetString(
                cursor.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.NameRawContactId));
            var contactList = new List<Contact>();

            if (cursor.MoveToFirst())
            {
                do
                {
                    Contact contact = new Contact();
                    contact.FirstName = cursor.GetString(cursor.GetColumnIndex(projection[1]));
                    contact.PhotoUrl = cursor.GetString(cursor.GetColumnIndex(projection[2]));
                    var cursorOrg = Application.Context.ContentResolver.Query(uri, null,
                                            ContactsContract.Data.InterfaceConsts.NameRawContactId + " = ?",
                                            new string[] { id }, null);
                    contactList.Add(contact);
                } while (cursor.MoveToNext());
            }
            Contacts = new ObservableCollection<Contact>(contactList);
            return Task.FromResult(Contacts);
        }

        public string HelloAndroid()
        {
            return "Hello Android";
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
