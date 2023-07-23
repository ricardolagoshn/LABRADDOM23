using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LABRADDOM23.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCreateAlumn : ContentPage
	{
        Plugin.Media.Abstractions.MediaFile photo = null;

        public byte[] GetimageBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }

            }

            return null;
        }


        public String GetimageBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();
                    
                    String Base64 = Convert.ToBase64String(fotobyte);
                    return Base64;
                }

            }
            return null;
        }

        public PageCreateAlumn ()
		{
			InitializeComponent ();
		}

        private async void btningresar_Clicked(object sender, EventArgs e)
        {
            var alumn = new Models.Alumnos
            {
                nombres = nombres.Text,
                apellidos = apellidos.Text,
                direccion = direccion.Text, 
                telefono = telefono.Text,
                foto = GetimageBase64()
            };

            if (photo != null)
            {
                Models.Message msg = await Controllers.AlumnController.CreateAlumn(alumn);

                if (msg != null)
                {
                    await DisplayAlert("Aviso", msg.message.ToString(), "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error..", "OK");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Favor tome una foto primero", "OK");
            }

        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "APP",
                Name = "Foto.jpg",
                SaveToAlbum = true

            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}