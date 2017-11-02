using System.Windows.Input;
using AppContact.ViewModels;
using ContactApp.Models;
using ContactApp.Services;
using Plugin.Media;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class NewPeoplePageViewModel : ViewModelBase
    {
        private Contact _contact;
        private string _imagecontact;
        public string ImageContact 
        {
            get => _imagecontact;
            set => SetProperty(ref _imagecontact, value);
        }
        public ICommand TapCommand { get; set; }

        public IDataService IDataService;
        public Contact Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }
        public ICommand SaveCommand => new DelegateCommand(SaveData);
        public NewPeoplePageViewModel(INavigationService navigationService, IDataService iDataService) : base(navigationService)
        {
            IDataService = iDataService;
            Contact = new Contact();
            TapCommand = new DelegateCommand(ChooseImage);
        }
        async private void ChooseImage()
        {
            await CrossMedia.Current.Initialize();
            //Check if device not support gallery
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Gallery", "No Gallery available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions{ });
            if (file == null)
                return;
            //return path of image and add to contact 
            ImageContact = file.Path;
            Contact.PhotoUrl = ImageContact;
        }
        private void SaveData()
        {
            //After addnew return back to people list
            IDataService.AddContact(Contact);
            _navigationService.GoBackAsync();
        }
    }
}
