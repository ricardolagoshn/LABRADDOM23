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
    public partial class PageEstudiantes : ContentPage
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


        public PageEstudiantes()
        {
            InitializeComponent();
        }

        private async void btningresar_Clicked(object sender, EventArgs e)
        {
            var estudiante = new Models.Estudiantes
            {
                nombres = nombres.Text,
                apellidos = apellidos.Text,
                fechanac = fecha.Date,
                id_carrera = id_carrera.SelectedItem.ToString(),
                telefono = telefono.Text,
                foto = GetimageBytes()
            };

            if (photo != null)
            {
                if (await App.Database.AddEstudiante(estudiante) > 0)
                {
                    await DisplayAlert("Aviso", "Estudiante ingresado con exito", "OK");
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
                foto.Source = ImageSource.FromStream(()=> { return photo.GetStream(); });
            }
        }
    }
}