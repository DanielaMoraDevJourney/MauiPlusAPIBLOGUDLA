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
    public class PostNodoViewModel : INotifyPropertyChanged
    {
        private readonly BlogService _blogService;
        public ObservableCollection<BlogNodoDto> Posts { get; set; }
        public ICommand AddPostCommand { get; }
        public ICommand PostSelectedCommand { get; }
        public ICommand BackCommand { get; }
        private BlogNodoDto _selectedPost;

        public event PropertyChangedEventHandler PropertyChanged;

        public BlogNodoDto SelectedPost
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

        public PostNodoViewModel(BlogService blogService)
        {
            _blogService = blogService;
            Posts = new ObservableCollection<BlogNodoDto>();
            AddPostCommand = new Command(async () => await OnAddPost());
            PostSelectedCommand = new Command<BlogNodoDto>(async (post) => await OnPostSelected(post));
            BackCommand = new Command(async () => await OnBack());
            LoadPosts();
        }

        private async Task LoadPosts()
        {
            var posts = await _blogService.GetBlogNodoAsync();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }
        }

        private async Task OnAddPost()
        {
            var nuevaPage = new AddPostPage(_blogService, false);
            nuevaPage.PostAgregadoNodo += NuevaPage_PostAgregado;
            await Application.Current.MainPage.Navigation.PushAsync(nuevaPage);
        }

        private void NuevaPage_PostAgregado(object sender, BlogNodoDto e)
        {
            Posts.Add(e);
        }

        private async Task OnPostSelected(BlogNodoDto selectedPost)
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
