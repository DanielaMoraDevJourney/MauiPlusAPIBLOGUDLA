using BLOGSOCIALUDLA.Services;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLOGSOCIALUDLA.Models;

namespace BLOGSOCIALUDLA.ViewModels
{
    public class AddPostViewModel : INotifyPropertyChanged
    {
        private readonly BlogService _blogService;
        public BlogFicaDto NuevoPost { get; set; }

        public AddPostViewModel(BlogService blogService)
        {
            _blogService = blogService;
            NuevoPost = new BlogFicaDto();
        }

        public async Task AñadirPost()
        {
            await _blogService.CreateBlogFicaAsync(NuevoPost); // Cambié el método a CreateBlogFicaAsync
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
