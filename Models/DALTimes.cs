using Campeonato.Entidades;
using Campeonato.Entidades.Enum;
using Campeonato.Infra;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Campeonato.Models
{
    public class DALTimes
    {

        private MySqlConnection conexao;

        public DALTimes()
        {
            conexao = DALConexao.CriaConexao();
        }


        public Times GetTime(int id)
        {

            Times time = new Times();

            try
            {

                conexao.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = @"SELECT * FROM tbl_time WHERE  tbl_time.id = @id_time LIMIT 1;";
                    cmd.Parameters.AddWithValue("@id_time", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        time.Id = Convert.ToInt32(reader["Id"]);
                        time.Categoria = (Categoria)Convert.ToInt32(reader["Categoria"]);
                        time.Nome = reader["Nome"].ToString();
                        time.Escudo = reader["Escudo"].ToString();

                    }

                }

                conexao.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro no retorno do Time... " + ex.Message);
            }

            return time;

        }


        public List<Times> GetTimes()
        {

            List<Times> lista = new List<Times>();

            try
            {

                conexao.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = @"SELECT * FROM tbl_time ORDER BY tbl_time.Categoria ASC, tbl_time.id ASC;";

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        Times reg = new Times()
                        {

                            Id = Convert.ToInt32(reader["Id"]),
                            Categoria = (Categoria)Convert.ToInt32(reader["Categoria"]),
                            Nome = reader["Nome"].ToString(),
                            Escudo = reader["Escudo"].ToString()

                        };

                        lista.Add(reg);

                    }

                }

                conexao.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro na Listagem dos Times... " + ex.Message);
            }

            return lista;

        }

    }
}
