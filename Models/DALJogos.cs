using Campeonato.Entidades;
using Campeonato.Entidades.Enum;
using Campeonato.Infra;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Campeonato.Models
{
    public class DALJogos
    {

        private MySqlConnection conexao;

        public DALJogos()
        {
            conexao = DALConexao.CriaConexao();
        }

        public List<Jogos> GetJogos()
        {

            List<Jogos> lista = new List<Jogos>();

            try
            {

                conexao.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = conexao;
                    cmd.CommandText = @"SELECT 
                        tbl_jogo.Id,
                        tbl_jogo.FaseId,
                        tbl_jogo.Data_Hora, 
                        tbl_jogo.Time_1Id, tbl_jogo.Goleiro_1Id, tbl_jogo.Resultado_1, 
                        tbl_jogo.Time_2Id, tbl_jogo.Goleiro_2Id, tbl_jogo.Resultado_2,

                        tbl_fase.Categoria AS Fase_Categoria,
                        tbl_fase.Nome AS Fase_Nome,

                        time_1.Nome AS Time_1_Nome, time_1.Escudo AS Time_1_Escudo,
                        time_2.Nome AS Time_2_Nome, time_2.Escudo AS Time_2_Escudo,

                        goleiro_1.Nome AS Goleiro_1_Nome,
                        goleiro_2.Nome AS Goleiro_2_Nome

                        FROM tbl_jogo

                        INNER JOIN tbl_fase ON tbl_fase.Id = tbl_jogo.FaseId
                        INNER JOIN tbl_time AS time_1 ON time_1.Id = tbl_jogo.Time_1Id
                        INNER JOIN tbl_time AS time_2 ON time_2.Id = tbl_jogo.Time_2Id
                        INNER JOIN tbl_goleiro AS goleiro_1 ON goleiro_1.Id = tbl_jogo.Goleiro_1Id
                        INNER JOIN tbl_goleiro AS goleiro_2 ON goleiro_2.Id = tbl_jogo.Goleiro_2Id

                        ORDER BY tbl_jogo.Data_Hora ASC, tbl_fase.Categoria ASC;";

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        Jogos reg = new Jogos();

                        reg.Id = Convert.ToInt32(reader["Id"]);

                        reg.Fase = new Fases() {
                            Id          = Convert.ToInt32(reader["FaseId"]),
                            Categoria   = (Categoria)Convert.ToInt32(reader["Fase_Categoria"]),
                            Nome        = reader["Fase_Nome"].ToString()
                        };

                        reg.Data_Hora = Convert.ToDateTime(reader["Data_Hora"]);

                        reg.Time_1 = new Times() {
                            Id = Convert.ToInt32(reader["Time_1Id"]),
                            Categoria = (Categoria)Convert.ToInt32(reader["Fase_Categoria"]),
                            Nome = reader["Time_1_Nome"].ToString(),
                            Escudo = reader["Time_1_Escudo"].ToString()
                        };

                        reg.Goleiro_1 = new Goleiros() {
                            Nome = reader["Goleiro_1_Nome"].ToString()
                        };

                        reg.Resultado_1 = reader["Resultado_1"] == null ? 0 : Convert.ToInt32(reader["Resultado_1"]);
                        
                        reg.Time_2 = new Times()
                        {
                            Id = Convert.ToInt32(reader["Time_2Id"]),
                            Categoria = (Categoria)Convert.ToInt32(reader["Fase_Categoria"]),
                            Nome = reader["Time_2_Nome"].ToString(),
                            Escudo = reader["Time_2_Escudo"].ToString()
                        };

                        reg.Goleiro_2 = new Goleiros()
                        {
                            Nome = reader["Goleiro_2_Nome"].ToString()
                        };

                        reg.Resultado_2 = reader["Resultado_2"] == null ? 0 : Convert.ToInt32(reader["Resultado_2"]);

                        lista.Add(reg);

                    }

                }

                conexao.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Listagem dos Jogos... " + ex.Message);
            }

            return lista;

        }

    }
}
