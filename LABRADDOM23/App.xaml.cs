using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LABRADDOM23.Models;
using LABRADDOM23.Controllers;
using System.IO;

namespace LABRADDOM23
{
    public partial class App : Application
    {

        static DataBase database;

        public static DataBase Database
        {
            get
            {
                var dbpath = String.Empty;
                var namedb = String.Empty;
                var fullpath = String.Empty;

                dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                namedb = "DBEstudiantes.db3";
                fullpath = Path.Combine(dbpath, namedb);

                if (database == null) 
                  {
                    database = new DataBase(fullpath);
                  } 

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageEstudiantes());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
