using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.ViewModels;
using Microsoft.Maui.Controls;

namespace BLOGSOCIALUDLA.Views
{
    public partial class PostSeleccionado : ContentPage
    {
        public PostSeleccionado(BlogFicaDto postFica)
        {
            InitializeComponent();
            BindingContext = new PostSeleccionadoViewModel(postFica, App.BlogService, App.CommentService);
        }

        public PostSeleccionado(BlogNodoDto postNodo)
        {
            InitializeComponent();
            BindingContext = new PostSeleccionadoViewModel(postNodo, App.BlogService, App.CommentService);
        }
    }
}
