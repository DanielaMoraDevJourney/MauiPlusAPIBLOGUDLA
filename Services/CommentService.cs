using BLOGSOCIALUDLA.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BLOGSOCIALUDLA.Services
{
    public class CommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByBlogIdAsync(Guid blogId)
        {
            var response = await _httpClient.GetAsync($"/api/comments/byBlog/{blogId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CommentDto>>();
        }

        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/comments", commentDto);
            response.EnsureSuccessStatusCode();
        }
    }

}