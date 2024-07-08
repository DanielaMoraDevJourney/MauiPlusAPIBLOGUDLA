using Microsoft.Maui.Controls;
using BLOGSOCIALUDLA.Models;
using System.Collections.ObjectModel;
using BLOGSOCIALUDLA.Data;
using BLOGSOCIALUDLA.ViewModels;

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