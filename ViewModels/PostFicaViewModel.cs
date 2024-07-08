using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using BLOGSOCIALUDLA.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BLOGSOCIALUDLA.ViewModels
{
    public class PostFicaViewModel : INotifyPropertyChanged
    {
        private readonly BlogService _blogService;
        public ObservableCollection<BlogFicaDto> Posts { get; set; }
        public ICommand AddPostCommand { get; }
        public ICommand PostSelectedCommand { get; }
        public ICommand BackCommand { get; }
        private BlogFicaDto _selectedPost;

        public event PropertyChangedEventHandler PropertyChanged;

        public BlogFicaDto SelectedPost
        {
            get => _selectedPost;
            set
            {
                if (_selectedPost != value)
                {
                    _selectedPost = value;
                    OnPropertyChanged();
                    PostSelectedCommand.Execute(_selectedPost);
                }
            }
        }

        public PostFicaViewModel(BlogService blogService)
        {
            _blogService = blogService;
            Posts = new ObservableCollection<BlogFicaDto>();
            AddPostCommand = new Command(async () => await OnAddPost());
            PostSelectedCommand = new Command<BlogFicaDto>(async (post) => await OnPostSelected(post));
            BackCommand = new Command(async () => await OnBack());
            LoadPosts();
        }

        private async Task LoadPosts()
        {
            var posts = await _blogService.GetBlogFicaAsync();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }
        }

        private async Task OnAddPost()
        {
            var nuevaPage = new AddPostPage(_blogService, true);
            nuevaPage.PostAgregadoFica += NuevaPage_PostAgregado;
            await Application.Current.MainPage.Navigation.PushAsync(nuevaPage);
        }

        private void NuevaPage_PostAgregado(object sender, BlogFicaDto e)
        {
            Posts.Add(e);
        }

        private async Task OnPostSelected(BlogFicaDto selectedPost)
        {
            if (selectedPost != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PostSeleccionado(selectedPost));
            }
        }

        private async Task OnBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
