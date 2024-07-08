using Microsoft.Maui.Controls;
using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.ViewModels;
using BLOGSOCIALUDLA.Services;

namespace BLOGSOCIALUDLA.Views
{
    public partial class PostNodo : ContentPage
    {
        public PostNodo()
        {
            InitializeComponent();
            BindingContext = new PostNodoViewModel(App.BlogService);
        }
    }
}
