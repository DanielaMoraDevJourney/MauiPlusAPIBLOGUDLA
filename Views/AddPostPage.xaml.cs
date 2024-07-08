
using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using Microsoft.Maui.Controls;
using System;

namespace BLOGSOCIALUDLA.Views
{
    public partial class AddPostPage : ContentPage
    {
        private readonly BlogService _blogService;

        public event EventHandler<BlogFicaDto> PostAgregadoFica;
        public event EventHandler<BlogNodoDto> PostAgregadoNodo;

        public AddPostPage(BlogService blogService)
        {
            InitializeComponent();
            _blogService = blogService;
        }

        private async void ClickAñadirPost(object sender, EventArgs e)
        {
            string titulo = TituloPost.Text;
            string contenido = ContenidoPost.Text;
            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(contenido))
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
                return;
            }

            var newPostFica = new BlogFicaDto
            {
                Titulo = titulo,
                Contenido = contenido,
            };

            await _blogService.CreateBlogFicaAsync(newPostFica);

            PostAgregadoFica?.Invoke(this, newPostFica);

            await DisplayAlert("Post añadido", "Tu post ha sido añadido exitosamente.", "OK");
            await Navigation.PopAsync();
        }
    }
}
