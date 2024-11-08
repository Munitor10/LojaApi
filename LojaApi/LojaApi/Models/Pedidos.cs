namespace LijaApi.Controllers
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateOnly DataPedido { get; set; }
        public string StatusPedidos { get; set; }
        public int ValorTotal { get; set; }
    }
}
