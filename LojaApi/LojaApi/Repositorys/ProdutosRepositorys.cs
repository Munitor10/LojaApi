using Dapper;
using LojaApi.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace LojaApi.Repositorys
{
    public class ProdutosRepositorys
    {
        private readonly string _connectionString;

        public ProdutosRepositorys(string connectionString)
        {
            _connectionString = connectionString;
        }


        private readonly ProdutosRepositorys _produtosRepositorys;


        public ProdutosRepositorys(string connectionString, ProdutosRepositorys produtosRepositorys)
        {
            _connectionString = connectionString;
            _produtosRepositorys = produtosRepositorys;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);


        public async Task<IEnumerable<Produtos>> ListarProdutos()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM Produtos;";

                return await conn.QueryAsync<Produtos>(sql);
            }
        }

        public async Task<int> RegistrarProduto(Produtos produtos)
        {
            using (var conn = Connection)
            {
                var sql = "INSERT INTO Produtos (Nome, Dercricao, Preco, QuantidadeEstoque) VALUES (@Nome, @Dercricao, @Preco, @QuantidadeEstoque);SELECT LAST_INSERT_ID();";
                return await conn.ExecuteScalarAsync<int>(sql, produtos);
            }
        }

        public async Task<int> AtualizarProduto(Produtos produtos)
        {
            using (var conn = Connection)
            {
                var sql = "UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, " +
                          "QuantidadeEstoque = @QuantidadeEstoque";
                return await conn.ExecuteAsync(sql, produtos);
            }
        }


        public async Task<int> ExcluirProduto(int id)
        {
            using (var conn = Connection)
            {
                var sql = "DELETE FROM Produtos WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }

    }
}
