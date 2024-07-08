using BLOGSOCIALUDLA.Data;
using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using BLOGSOCIALUDLA.Views;
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Net.Http;

namespace BLOGSOCIALUDLA
{
    public partial class App : Application
    {
        static SQLiteData? _bancoDatos;
        public static BlogService BlogService { get; private set; }
        public static CommentService CommentService { get; private set; }

        public App()
        {
            InitializeComponent();

            // Inicializar servicios HTTP
            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7036") };
            BlogService = new BlogService(httpClient);
            CommentService = new CommentService(httpClient);

            var navPage = new NavigationPage(new InicioSesion());
            navPage.Background = Colors.DarkRed;
            navPage.BarTextColor = Colors.DarkRed;

            MainPage = new AppShell();
        }

        public static SQLiteData BancoDatos
        {
            get
            {
                if (_bancoDatos == null)
                {
                    _bancoDatos = new SQLiteData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Datos.db"));
                }
                return _bancoDatos;
            }
        }

        public static User Usuario { get; set; }
    }
}
