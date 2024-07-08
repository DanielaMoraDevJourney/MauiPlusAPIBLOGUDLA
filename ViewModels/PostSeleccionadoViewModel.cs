using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BLOGSOCIALUDLA.ViewModels
{
    public class PostSeleccionadoViewModel : INotifyPropertyChanged
    {
        private readonly CommentService _commentService;
        private readonly BlogService _blogService;
        private BlogFicaDto _postFica;
        private BlogNodoDto _postNodo;

        public ObservableCollection<CommentDto> Comments { get; set; }
        public ICommand EnviarComentarioCommand { get; }

        public string Titulo => _postFica?.Titulo ?? _postNodo?.Titulo;
        public string Contenido => _postFica?.Contenido ?? _postNodo?.Contenido;

        public PostSeleccionadoViewModel(BlogFicaDto postFica, BlogService blogService, CommentService commentService)
        {
            _postFica = postFica;
            _blogService = blogService;
            _commentService = commentService;
            Comments = new ObservableCollection<CommentDto>();
            EnviarComentarioCommand = new Command(async () => await EnviarComentario());
            LoadComments();
        }

        public PostSeleccionadoViewModel(BlogNodoDto postNodo, BlogService blogService, CommentService commentService)
        {
            _postNodo = postNodo;
            _blogService = blogService;
            _commentService = commentService;
            Comments = new ObservableCollection<CommentDto>();
            EnviarComentarioCommand = new Command(async () => await EnviarComentario());
            LoadComments();
        }

        private async Task LoadComments()
        {
            Guid blogId;

            if (_postFica != null)
            {
                blogId = _postFica.Id;
            }
            else if (_postNodo != null)
            {
                blogId = _postNodo.Id;
            }
            else
            {
                return; // No hay ID válido, no cargar comentarios
            }

            var comments = await _commentService.GetCommentsByBlogIdAsync(blogId);
            Comments.Clear();
            foreach (var comment in comments)
            {
                Comments.Add(comment);
            }
        }

        private string _nuevoComentario;
        public string NuevoComentario
        {
            get => _nuevoComentario;
            set
            {
                _nuevoComentario = value;
                OnPropertyChanged();
            }
        }

        private async Task EnviarComentario()
        {
            if (!string.IsNullOrWhiteSpace(NuevoComentario))
            {
                Guid blogId;

                if (_postFica != null)
                {
                    blogId = _postFica.Id;
                }
                else if (_postNodo != null)
                {
                    blogId = _postNodo.Id;
                }
                else
                {
                    return; // No hay ID válido, no enviar comentario
                }

                var nuevoComentario = new CommentDto
                {
                    Contenido = NuevoComentario,
                    Fecha = DateTime.Now,
                    BlogFicaId = _postFica?.Id,
                    BlogNodoId = _postNodo?.Id
                };

                await _commentService.CreateCommentAsync(nuevoComentario);
                Comments.Add(nuevoComentario);
                NuevoComentario = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
