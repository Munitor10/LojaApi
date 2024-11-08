using Dapper;
using LijaApi.Controllers;
using LojaApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace LojaApi.Repositorys
{
    public class CarrinhoRepositorys
    {

        private readonly string _connectionString;

        public CarrinhoRepositorys(string connectionString)
        {
            _connectionString = connectionString;
        }


        private readonly ProdutosRepositorys _produtosRepositorys;


        public CarrinhoRepositorys(string connectionString, ProdutosRepositorys produtosRepositorys)
        {
            _connectionString = connectionString;
            _produtosRepositorys = produtosRepositorys;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);



        public async Task<int> RegistrarProduto(Produtos produtos)
        {
            using (var conn = Connection)
            {
                var sql = "INSERT INTO Carrinho (UsuarioId, Dercricao, Preco, QuantidadeEstoque) VALUES (@Nome, @Dercricao, @Preco, @QuantidadeEstoque);SELECT LAST_INSERT_ID();";
                return await conn.ExecuteScalarAsync<int>(sql, produtos);
            }
        }

        public async Task<int> RegistraritemCarrinho(Carrinho carrinho)
        {
            using (var conn = Connection)
            {
              //bool disponivel = await _produtosRepositorys.VerificarDisponibilidadeProduto(carrinho.ProdutoId);

              //  if (!disponivel)
              //  {
              //      throw new InvalidOperationException("Produto não está disponível para empréstimo.");
              //  }

                var sql = "INSERT INTO Carrinho (UsuarioId, Dercricao, Preco, QuantidadeEstoque) VALUES (@Nome, @Dercricao, @Preco, @QuantidadeEstoque);SELECT LAST_INSERT_ID();";
                 return await conn.ExecuteScalarAsync<int>(sql, carrinho);
                   
                
            }
        }


        public async Task<int> ExcluirItem(int id)
        {
            using (var conn = Connection)
            {
                var sql = "DELETE FROM Carrinho WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Carrinho>> ListarItens()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM db_aulas_2024.Carrinho";
                return await conn.QueryAsync<Carrinho>(sql);

            }
        }

        public async Task<int> AtualizarLivroDB(Carrinho carrinho)
        {
            using (var conn = Connection)
            {
                var sql = "UPDATE Carrinho SET UsuarioId = @UsuarioId, ProdutoId = @ProdutoId, Quantidade = @Quantidade, WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, carrinho);
            }
        }

        public async Task<bool> VerificarDisponibilidadeProduto(int produtoId)
        {
            using (var conn = Connection)
            {
                var sql = "SELECT COUNT(*) FROM Carrinho WHERE Id = @ProdutoId AND Disponivel = TRUE";
                var count = await conn.ExecuteScalarAsync<int>(sql, new { ProdutoId = produtoId });

                return count > 0;
            }
        }
    }
}
