using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using System.IO;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;

namespace StudyBuddyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        ProfileEditViewModel viewModel;
        Image selectedImage;
        LocalUser localUser;
        public ProfileEditPage()
        {
            InitializeComponent();
        }

        public ProfileEditPage(ProfileEditViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            selectedImage = new Image();
            localUser = LocalUserManager.LocalUser;
        }

        private void buttonSaveEdit_Clicked(object sender, EventArgs e)
        {

            if (entryFirstName.Text != null || entryLastName.Text != null)
            {
                LoadingIndicator.IsRunning = true;
                if (entryFirstName.Text == null) entryFirstName.Text = localUser.FirstName;
                if (entryLastName.Text == null) entryLastName.Text = localUser.LastName;
                new UserUpdater(localUser,
                    (status, firstName, lastName) =>
                    {
                        Device.BeginInvokeOnMainThread(() => //Grįžtama į main Thread !! SVARBU
                        {
                            if (status == UserUpdater.GetStatus.Success) //Pavyko
                            {
                                localUser.FirstName = firstName;
                                localUser.LastName = lastName;
                                localUser.OnUpdateHandler?.Invoke(localUser);
                                DependencyService.Get<IToast>().LongToast("Pakeitimai išsaugoti");
                            }
                            else //Ne
                            {
                                Application.Current.MainPage.DisplayAlert("Klaida", "woops, kažkas netaip", "tęsti");
                            }
                            LoadingIndicator.IsRunning = false;
                        });
                    }).get(entryFirstName.Text, entryLastName.Text);
            }
        }

        /*if you want to take a picture use this
         * if(!CrossMedia.Current.isTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
         */
        private async void buttonChangeProfilePicture_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize(); //Initialize plugin

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "Ok");
                return;
            }
            /*if you want to take a picture use StoreCameraMediaOptions instead of PickMediaOptions*/
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            //if you want to take a picture use TakePhotoAsync instead of PickPhotoAsync
            
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectedImageFile == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again", "Ok");
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            if (selectedImage != null)
            {
                LoadingIndicator.IsRunning = true;
                var base64String = Convert.ToBase64String(ReadFully(selectedImageFile.GetStream()));

                new ProfilePictureUpdater(localUser,
                (status, pictureLocation) =>
                {
                    Device.BeginInvokeOnMainThread(() => //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == ProfilePictureUpdater.GetStatus.Success) //Pavyko
                        {
                            localUser.ProfilePictureLocation = pictureLocation;
                            ProfilePicture.Source = pictureLocation;
                            localUser.OnUpdateHandler?.Invoke(localUser);
                            DependencyService.Get<IToast>().LongToast("Nuotrauka įkelta");
                        }
                        else //Ne
                        {
                            Console.WriteLine(status);
                            DisplayAlert("Nepavyko įkelti pic:(", "oof", "OK");
                        }
                        LoadingIndicator.IsRunning = false;

                    });
                }
                ).get(base64String);
            }
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}