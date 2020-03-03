using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string stringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, EstudiosDomain EstudioAtualizado)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "UPDATE Estudios SET NomeEstudio = @Nome WHERE IdEstudio = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", EstudioAtualizado.NomeEstudio);
                    cmd.Parameters.AddWithValue("@ID", EstudioAtualizado.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudiosDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT NomeEstudio FROM Estudios WHERE IdEstudio = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@ID", id);

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    if (rdr.Read())
                    {
                        // Instancia um objeto 
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };
                        return estudio;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@Nome)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.NomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "DELETE FROM Estudios WHERE IdEstudio = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> Listar()
        {
            // Cria uma lista estúdios onde serão armazenados os dados
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT Estudios.NomeEstudio, NomeJogo FROM Jogos RIGHT JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto 
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // Adiciona o estúdio criado à lista de estúdios
                        estudios.Add(estudio);
                    }
                }
            }

            // Retorna a lista de estúdios
            return estudios;
        }
    }
}
