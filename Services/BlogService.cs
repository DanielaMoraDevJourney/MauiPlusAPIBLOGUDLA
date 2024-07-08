using BLOGSOCIALUDLA.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BLOGSOCIALUDLA.Services
{
    public class BlogService
    {
        private readonly HttpClient _httpClient;

        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BlogFicaDto>> GetBlogFicaAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogFicaDto>>("api/fica/blogs");
        }

        public async Task<IEnumerable<BlogNodoDto>> GetBlogNodoAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogNodoDto>>("api/nodo/blogs");
        }

        public async Task<BlogFicaDto> GetBlogFicaByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<BlogFicaDto>($"api/fica/blogs/{id}");
        }

        public async Task<BlogNodoDto> GetBlogNodoByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<BlogNodoDto>($"api/nodo/blogs/{id}");
        }

        public async Task CreateBlogFicaAsync(BlogFicaDto blogFicaDto)
        {
            await _httpClient.PostAsJsonAsync("api/fica/blogs", blogFicaDto);
        }

        public async Task CreateBlogNodoAsync(BlogNodoDto blogNodoDto)
        {
            await _httpClient.PostAsJsonAsync("api/nodo/blogs", blogNodoDto);
        }

        public async Task UpdateBlogFicaAsync(Guid id, BlogFicaDto blogFicaDto)
        {
            await _httpClient.PutAsJsonAsync($"api/fica/blogs/{id}", blogFicaDto);
        }

        public async Task UpdateBlogNodoAsync(Guid id, BlogNodoDto blogNodoDto)
        {
            await _httpClient.PutAsJsonAsync($"api/nodo/blogs/{id}", blogNodoDto);
        }

        public async Task DeleteBlogFicaAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/fica/blogs/{id}");
        }

        public async Task DeleteBlogNodoAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/nodo/blogs/{id}");
        }
    }
}
