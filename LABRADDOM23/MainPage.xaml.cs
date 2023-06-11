using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LABRADDOM23
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Bienvendido a labrad " + nombre.Text + " " + apellido.Text,"OK");

        }
    }
}
