using System;
using System.Collections.Generic;
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
                telefono = telefono.Text
            };

            if (await App.Database.AddEstudiante(estudiante) > 0)
            {
                await DisplayAlert("Aviso", "Estudiante ingresado con exito", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha ocurrido un error..", "OK");
            }
        }
    }
}