using Microsoft.Maui.Controls;
using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.ViewModels;
using BLOGSOCIALUDLA.Services;

namespace BLOGSOCIALUDLA.Views
{
    public partial class PostFica : ContentPage
    {
        public PostFica()
        {
            InitializeComponent();
            BindingContext = new PostFicaViewModel(App.BlogService);
        }
    }
}
