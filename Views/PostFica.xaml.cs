using Microsoft.Maui.Controls;
using BLOGSOCIALUDLA.Models;
using System.Collections.ObjectModel;
using BLOGSOCIALUDLA.Data;
using BLOGSOCIALUDLA.ViewModels;

namespace BLOGSOCIALUDLA.Views
{
    public partial class PostFica : ContentPage
    {
        public ObservableCollection<Post> Posts { get; set; }

        public PostFica()
        {
            InitializeComponent();
            BindingContext = new PostFicaViewModel(App.BlogService);
        }
    }
}