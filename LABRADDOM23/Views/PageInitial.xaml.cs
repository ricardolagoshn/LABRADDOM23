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
    public partial class PageInitial : ContentPage
    {
        public PageInitial()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listestudiantes.ItemsSource = await App.Database.ObtenerListaEstudiante();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pageestu = new Views.PageEstudiantes();
            Navigation.PushAsync(pageestu);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var pageestu = new Views.PageCreateAlumn();
            Navigation.PushAsync(pageestu);
        }
    }
}