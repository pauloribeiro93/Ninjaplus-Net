

using System;
using System.IO;
using Npgsql;

namespace NinjaPlus.Lib
{
    public static class Database
    {
        private static NpgsqlConnection Connection()
        {
            var connectionString = "Host=pgdb;Username=postgres;Password=qaninja;Database=ninjaplus";
            //Botei um S a menos no usuario. 

            var connection = new NpgsqlConnection(connectionString); //Todas as instruções para conectar no banco
            connection.Open(); //Abre conexão para começar os trabalhos

            return connection;
        }
        public static void InsertMovies()
        {
            var dataSql = Environment.CurrentDirectory + "\\Data\\data.sql";
            var query = File.ReadAllText(dataSql);

            var command = new NpgsqlCommand(query, Connection());
            command.ExecuteReader();

        }

        public static void RemoveByTitle(string title) //Class static, metodo tbm deve ser
        {
            var query = $"DELETE FROM public.movies WHERE title = '{title}';"; //Interpolação de Stings.

            var command = new NpgsqlCommand(query, Connection());
            command.ExecuteReader();

            Connection().Close(); //Sempre fechar a conexão

        }
    }

}