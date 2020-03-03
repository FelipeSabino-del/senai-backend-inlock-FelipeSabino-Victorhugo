using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, JogosDomain JogoAtualizado)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "UPDATE Jogos SET NomeJogo = @Nome, Descricao = @Descricao, DataLancamento = @Data, Valor = @$ WHERE IdEstudio = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@Data", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@$", JogoAtualizado.Valor);
                    cmd.Parameters.AddWithValue("@ID", JogoAtualizado.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT NomeJogo, Descricao, DataLancamento, Valor, Estudios.NomeEstudio INNER JOIN Estudios ON Estudios.IdEstudio = Jogo.IdEstudio FROM Jogos WHERE Idjogo = @ID";

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
                        JogosDomain jogo = new JogosDomain();
                        // Atribui às propriedades os valores das colunas da tabela do banco
                        jogo.IdJogo = Convert.ToInt32(rdr["IdEstudio"]);
                        jogo.NomeJogo = rdr["NomeJogo"].ToString();
                        jogo.Descricao = rdr["Descricao"].ToString();
                        jogo.DataLancamento = DateTime.Parse(rdr["DataLancamento"].ToString());
                        jogo.Valor = Convert.ToSingle(rdr["Valor"]);
                        jogo.Estudio.NomeEstudio = rdr["Estudios.NomeEstudio"].ToString();
                        return jogo;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @Data, @Valor, @IdEstudio)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

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
                string queryInsert = "DELETE FROM Jogos WHERE IdJogo = @ID";

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

        public List<JogosDomain> Listar()
        {
            // Cria uma lista estúdios onde serão armazenados os dados
            List<JogosDomain> jogos = new List<JogosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT NomeJogo, Descricao, DataLancamento, Valor, Estudios.NomeEstudio FROM Jogos INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio";

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
                        JogosDomain jogo = new JogosDomain();
                        // Atribui às propriedades os valores das colunas da tabela do banco
                        jogo.IdJogo = Convert.ToInt32(rdr["IdEstudio"]);
                        jogo.NomeJogo = rdr["NomeJogo"].ToString();
                        jogo.Descricao = rdr["Descricao"].ToString();
                        jogo.DataLancamento = DateTime.Parse(rdr["DataLancamento"].ToString());
                        jogo.Valor = Convert.ToSingle(rdr["Valor"]);
                        jogo.Estudio.NomeEstudio = rdr["Estudios.NomeEstudio"].ToString();

                        // Adiciona o estúdio criado à lista de estúdios
                        jogos.Add(jogo);
                    }
                    // Retorna a lista de estúdios
                    return jogos;
                }
            }

        }
    }
}

