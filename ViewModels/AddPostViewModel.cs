using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BLOGSOCIALUDLA.ViewModels
{
    public class AddPostViewModel : INotifyPropertyChanged
    {
        private readonly BlogService _blogService;
        private readonly bool _isFica;

        public AddPostViewModel(BlogService blogService, bool isFica)
        {
            _blogService = blogService;
            _isFica = isFica;

            if (_isFica)
            {
                NuevoPostFica = new BlogFicaDto();
            }
            else
            {
                NuevoPostNodo = new BlogNodoDto();
            }
        }

        public BlogFicaDto NuevoPostFica { get; set; }
        public BlogNodoDto NuevoPostNodo { get; set; }

        public async Task AñadirPost()
        {
            if (_isFica)
            {
                await _blogService.CreateBlogFicaAsync(NuevoPostFica);
            }
            else
            {
                await _blogService.CreateBlogNodoAsync(NuevoPostNodo);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
