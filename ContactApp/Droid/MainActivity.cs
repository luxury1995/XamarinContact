using Android.App;
using Android.Content;
using Android.Content.PM;
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
        ContentResolver _resolver = Application.Context.ContentResolver;
        private ObservableCollection<Contact> Contacts { get; set; }

        public Task<ObservableCollection<Contact>> GetContacts()
        {
            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri,
                ContactsContract.Contacts.InterfaceConsts.NameRawContactId
              };
            //Query(uri,projection,selection,selectionarg,sortorder
            var cursor = _resolver.Query(uri, projection, null, null, null);

            var contactList = new List<Contact>();

            if (cursor.MoveToFirst())
            {
                do
                {
                    Contact contact = new Contact();
                    contact.Id = cursor.GetString(cursor.GetColumnIndex(projection[3]));
                    contact.FirstName = cursor.GetString(cursor.GetColumnIndex(projection[1]));
                    contact.PhotoUrl = cursor.GetString(cursor.GetColumnIndex(projection[2]));
                    var cursorChild = _resolver.Query(  ContactsContract.Data.ContentUri, null,ContactsContract.Contacts.InterfaceConsts.NameRawContactId+ " = ?",new string[] { contact.Id }, null);
                    if(cursorChild !=null && cursorChild.MoveToFirst()){
                        do
                        {
                            //return many type of data 
                            var dataType = cursorChild.GetString(cursorChild.GetColumnIndex(ContactsContract.DataColumns.Mimetype));
                            switch(dataType){
                                case ContactsContract.CommonDataKinds.Organization.ContentItemType:
                                    var company = cursorChild.GetString(cursorChild.GetColumnIndex(ContactsContract.CommonDataKinds.Organization.Company));
                                    contact.Company = company;
                                    break;
                            }
                        } while (cursorChild.MoveToNext());
                    }


                    contactList.Add(contact);
                } while (cursor.MoveToNext());
                cursor.Close();
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
