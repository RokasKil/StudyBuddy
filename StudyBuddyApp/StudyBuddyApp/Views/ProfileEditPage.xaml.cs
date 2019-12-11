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
using StudyBuddyShared.UserSystem;
using UserUpdater = StudyBuddyShared.UserSystem.UserUpdater;
using StudyBuddyShared.SystemManager;

namespace StudyBuddyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        ProfileEditViewModel viewModel;
        Image selectedImage;
        LocalUser localUser;
        bool photoFromCamera;
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
                var userUpdater = UserSystemManager.UserUpdater();
                userUpdater.Result +=
                    (status, firstName, lastName) =>
                    {
                        Device.BeginInvokeOnMainThread(() => //Grįžtama į main Thread !! SVARBU
                        {
                            if (status == UserUpdateStatus.Success) //Pavyko
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
                    };
                userUpdater.Update(entryFirstName.Text, entryLastName.Text);
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
            string action = await DisplayActionSheet("Iš kur norite įkelti nuotrauką?", "Atšaukti", null, "Iš telefono", "Nusifotografuoti dabar");
            if(action == null)
            {
                return;
            }
            photoFromCamera = action.Equals("Nusifotografuoti dabar");
            /*if you want to take a picture use StoreCameraMediaOptions instead of PickMediaOptions*/
            var cameraMediaOptions = new StoreCameraMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            //if you want to take a picture use TakePhotoAsync instead of PickPhotoAsync

            var selectedImageFile =
                photoFromCamera ? await CrossMedia.Current.TakePhotoAsync(cameraMediaOptions) : await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectedImageFile == null)
            {
                await DisplayAlert("Klaida", "Nepasirinkta nuotrauka, bandykite dar kartą", "Tęsti");
                return;
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            if (selectedImage != null)
            {
                LoadingIndicator.IsRunning = true;
                var base64String = Convert.ToBase64String(ReadFully(selectedImageFile.GetStream()));
                var profilePictureUpdater = UserSystemManager.UserProfilePictureUpdater();

                profilePictureUpdater.Result +=
                (status, pictureLocation) =>
                {
                    Device.BeginInvokeOnMainThread(() => //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == PictureUpdateStatus.Success) //Pavyko
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
                };
                profilePictureUpdater.Upload(base64String);
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