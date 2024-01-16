using ClienteBlazorWASM.Helper;
using ClienteBlazorWASM.Model;
using ClienteBlazorWASM.Modelos;
using ClienteBlazorWASM.Servicios.IServicio;
using Newtonsoft.Json;
using System.Text;

namespace ClienteBlazorWASM.Servicios
{
    public class PostServicio : IPostServicio
    {
        private readonly HttpClient _http;
        public PostServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<Post> ActualizarPost(int idPost, Post post)
        {
            var content = JsonConvert.SerializeObject(post);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync($"{Inicializar.UrlBaseApi}api/posts/{idPost}", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Post>(contentTemp);
                return result;
            }
            else
            {
                var content2 = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ModeloError>(content2);
                throw new Exception(error.ErrorMessage);
            }
        }

        public async Task<Post> Crear(Post post)
        {
            var content = JsonConvert.SerializeObject(post);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync($"{Inicializar.UrlBaseApi}api/posts",bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Post>(contentTemp);
                return result;
            }
            else
            {
                var content2 = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ModeloError>(content2);
                throw new Exception(error.ErrorMessage);
            }
        }

        public  async Task<bool> EliminarPost(int idPost)
        {
            var response = await _http.GetAsync($"{Inicializar.UrlBaseApi}api/BorrarPost/{idPost}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var content2 = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ModeloError>(content2);
                throw new Exception(error.ErrorMessage);
            }
        }
        public async Task<Post> GetPost(int idPost)
        {
            var response = await _http.GetAsync($"{Inicializar.UrlBaseApi}api/post/{idPost}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<Post>(content);
                return post;
            }
            var content2 = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ModeloError>(content2);
            throw new Exception(error.ErrorMessage);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _http.GetAsync($"{Inicializar.UrlBaseApi}api/posts");
            var content = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(content);
            return posts;
        }

        public Task<string> subidaImagen(MultipartFormDataContent content)
        {
            throw new NotImplementedException();
        }
    }
}
