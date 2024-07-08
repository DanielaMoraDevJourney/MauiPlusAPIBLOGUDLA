using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using Microsoft.Maui.Controls;
using System;

namespace BLOGSOCIALUDLA.Views
{
    public partial class AddPostPage : ContentPage
    {
        private readonly BlogService _blogService;
        private readonly bool _isFica;

        public event EventHandler<BlogFicaDto> PostAgregadoFica;
        public event EventHandler<BlogNodoDto> PostAgregadoNodo;

        public AddPostPage(BlogService blogService, bool isFica)
        {
            InitializeComponent();
            _blogService = blogService;
            _isFica = isFica;
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

            if (_isFica)
            {
                var newPostFica = new BlogFicaDto
                {
                    Titulo = titulo,
                    Contenido = contenido
                };

                await _blogService.CreateBlogFicaAsync(newPostFica);
                PostAgregadoFica?.Invoke(this, newPostFica);
            }
            else
            {
                var newPostNodo = new BlogNodoDto
                {
                    Titulo = titulo,
                    Contenido = contenido
                };

                await _blogService.CreateBlogNodoAsync(newPostNodo);
                PostAgregadoNodo?.Invoke(this, newPostNodo);
            }

            await DisplayAlert("Post añadido", "Tu post ha sido añadido exitosamente.", "OK");
            await Navigation.PopAsync();
        }
    }
}
