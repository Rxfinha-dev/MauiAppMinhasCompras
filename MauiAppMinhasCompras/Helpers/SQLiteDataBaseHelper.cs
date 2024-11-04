﻿using MauiAppMinhasCompras.Models;
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
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "update Produto set Descricao=?," + 
                "Quantidade=?, Preco= ? where id=?";

            return _conn.QueryAsync<Produto>
           (
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
           );
        }




















    }
}
