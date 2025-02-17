using MauiAppMinhasCompras.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        // Conexão assíncrona com o banco de dados SQLite
        readonly SQLiteAsyncConnection _conn;

        // Construtor que recebe o caminho do banco de dados
        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            // Cria a tabela Produto caso ainda não exista
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // Método para inserir um novo produto na tabela
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        // Método para atualizar um produto existente
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "update Produto set Descricao=?, " +
                "Quantidade=?, Preco=? where id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        // Método para excluir um produto pelo ID
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Método para obter todos os produtos cadastrados
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Método para buscar produtos com base na descrição (filtro de texto)
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
