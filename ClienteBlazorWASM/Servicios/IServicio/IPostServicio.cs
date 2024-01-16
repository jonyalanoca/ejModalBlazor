using ClienteBlazorWASM.Modelos;

namespace ClienteBlazorWASM.Servicios.IServicio
{
    public interface IPostServicio
    {
        public Task<IEnumerable<Post>> GetPosts();
        public Task<Post> GetPost(int idPost);

        public Task<Post> Crear(Post post);
        public Task<Post> ActualizarPost(int idPost, Post post);
        public Task<bool> EliminarPost(int idPost);
        public Task<string> subidaImagen(MultipartFormDataContent content);





    }
}
