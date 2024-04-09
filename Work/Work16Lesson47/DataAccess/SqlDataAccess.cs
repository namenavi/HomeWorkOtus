﻿using Dapper;
using Npgsql;
using System.Data;

namespace Work16Lesson47.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _config;
        public SqlDataAccess(string config)
        {
            _config = config;
        }
        public async Task<IEnumerable<T>> LoadWithQuery<T, U>(
            string query,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config);

            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task<IEnumerable<T>> LoadWithJoin<T, T2, U>(
            string query,
            U parameters,
            Func<T, T2, T> splitFunc,
            string splitOn,
            string connectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config);

            return await connection.QueryAsync(query, splitFunc, parameters, splitOn: splitOn);
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config);

            return await connection.QueryAsync<T>(storedProcedure, parameters);// commandType: CommandType.StoredProcedure
        }

        public async Task SaveData<T>(string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config);

            await connection.ExecuteAsync(storedProcedure, parameters);

        }

    }
}
