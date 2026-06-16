using AgendaContatos.Models;
using Microsoft.Data.SqlClient;

namespace AgendaContatos.Models
{
    public class ContatoRepositorio
    {
        // String de conexão com o banco de dados
        // Server = nome do servidor, Database = nome do banco,
        // User Id e Password = usuário limitado que criamos no SSMS
        private readonly string _conexao =
            "Server=localhost\\SQLEXPRESS;Database=AgendaContatos;User Id=agenda_user;Password=Agenda@123;TrustServerCertificate=True;";

        // Retorna todos os contatos do banco usando a VIEW que criamos
        // A view já faz o JOIN entre Contato e Endereco automaticamente
        public List<Contato> ListarTodos()
        {
            var contatos = new List<Contato>();

            // "using" garante que a conexão será fechada automaticamente ao final
            using var con = new SqlConnection(_conexao);
            con.Open();

            // Consultamos pela view em vez da tabela direta
            // assim já vem com os dados de endereço junto
            var cmd = new SqlCommand("SELECT * FROM vw_Contatos", con);
            var reader = cmd.ExecuteReader();

            // Lê linha por linha do resultado e monta os objetos
            while (reader.Read())
            {
                Contato c = CriarContato(reader);
                contatos.Add(c);
            }

            return contatos;
        }

        public void Adicionar(Contato c)
        {
            using var con = new SqlConnection(_conexao);
            con.Open();

            // Precisamos inserir o endereço PRIMEIRO porque a tabela Contato
            // tem uma chave estrangeira (EnderecoId) que aponta para Endereco
            int enderecoId = 0;
            if (c.Endereco != null)
            {
                var cmdEnd = new SqlCommand(@"
                    INSERT INTO Endereco (Rua, Cidade, Estado)
                    VALUES (@Rua, @Cidade, @Estado);
                    SELECT SCOPE_IDENTITY();", con);
                // SCOPE_IDENTITY() retorna o Id gerado automaticamente
                // pelo IDENTITY da tabela após o INSERT

                cmdEnd.Parameters.AddWithValue("@Rua", c.Endereco.Rua ?? "");
                cmdEnd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade ?? "");
                cmdEnd.Parameters.AddWithValue("@Estado", c.Endereco.Estado ?? "");

                enderecoId = Convert.ToInt32(cmdEnd.ExecuteScalar());
                // ExecuteScalar() executa o comando e retorna o primeiro valor
                // da primeira linha — no caso o Id gerado
            }

            // Agora insere o contato com o EnderecoId que acabamos de obter
            var cmd = new SqlCommand(@"
                INSERT INTO Contato (Nome, Telefone, Email, Tipo, Favorito, EnderecoId, Apelido, Empresa, Cargo)
                VALUES (@Nome, @Telefone, @Email, @Tipo, @Favorito, @EnderecoId, @Apelido, @Empresa, @Cargo);
                SELECT SCOPE_IDENTITY();", con);

            // Parameters.AddWithValue evita SQL Injection
            // em vez de concatenar strings direto no SQL
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@Email", c.Email ?? "");
            cmd.Parameters.AddWithValue("@Tipo", c.GetTipo()); // "Pessoal" ou "Profissional"
            cmd.Parameters.AddWithValue("@Favorito", c.Favorito ? 1 : 0);
            cmd.Parameters.AddWithValue("@EnderecoId", enderecoId > 0 ? enderecoId : DBNull.Value);
            // DBNull.Value é o equivalente ao NULL do SQL — usado quando não há endereço

            // Campos específicos de cada tipo — se não for o tipo, salva vazio
            cmd.Parameters.AddWithValue("@Apelido", c is ContatoPessoal cp ? cp.Apelido ?? "" : "");
            cmd.Parameters.AddWithValue("@Empresa", c is ContatoProfissional cpr ? cpr.Empresa ?? "" : "");
            cmd.Parameters.AddWithValue("@Cargo", c is ContatoProfissional cpr2 ? cpr2.Cargo ?? "" : "");

            // Atualiza o Id do objeto com o Id gerado pelo banco
            c.Id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Atualizar(Contato c)
        {
            using var con = new SqlConnection(_conexao);
            con.Open();

            // Atualiza o endereço se ele já existe no banco
            if (c.Endereco != null && c.Endereco.Id > 0)
            {
                var cmdEnd = new SqlCommand(@"
                    UPDATE Endereco
                    SET Rua = @Rua, Cidade = @Cidade, Estado = @Estado
                    WHERE Id = @Id", con);

                cmdEnd.Parameters.AddWithValue("@Rua", c.Endereco.Rua ?? "");
                cmdEnd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade ?? "");
                cmdEnd.Parameters.AddWithValue("@Estado", c.Endereco.Estado ?? "");
                cmdEnd.Parameters.AddWithValue("@Id", c.Endereco.Id);
                cmdEnd.ExecuteNonQuery();
                // ExecuteNonQuery() executa o comando sem retornar dados
                // usado para INSERT, UPDATE e DELETE
            }

            var cmd = new SqlCommand(@"
                UPDATE Contato
                SET Nome = @Nome, Telefone = @Telefone, Email = @Email,
                    Tipo = @Tipo, Favorito = @Favorito,
                    Apelido = @Apelido, Empresa = @Empresa, Cargo = @Cargo
                WHERE Id = @Id", con);

            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@Email", c.Email ?? "");
            cmd.Parameters.AddWithValue("@Tipo", c.GetTipo());
            cmd.Parameters.AddWithValue("@Favorito", c.Favorito ? 1 : 0);
            cmd.Parameters.AddWithValue("@Apelido", c is ContatoPessoal cp ? cp.Apelido ?? "" : "");
            cmd.Parameters.AddWithValue("@Empresa", c is ContatoProfissional cpr ? cpr.Empresa ?? "" : "");
            cmd.Parameters.AddWithValue("@Cargo", c is ContatoProfissional cpr2 ? cpr2.Cargo ?? "" : "");
            cmd.Parameters.AddWithValue("@Id", c.Id);

            cmd.ExecuteNonQuery();
        }

        public void Remover(int id)
        {
            using var con = new SqlConnection(_conexao);
            con.Open();

            // Precisamos pegar o EnderecoId ANTES de deletar o contato
            // porque depois não conseguimos mais saber qual endereço deletar
            var cmdBusca = new SqlCommand("SELECT EnderecoId FROM Contato WHERE Id = @Id", con);
            cmdBusca.Parameters.AddWithValue("@Id", id);
            var enderecoId = cmdBusca.ExecuteScalar();

            // Deleta o contato primeiro por causa da chave estrangeira
            // não podemos deletar o endereço enquanto o contato ainda o referencia
            var cmd = new SqlCommand("DELETE FROM Contato WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();

            // Agora sim podemos deletar o endereço vinculado
            if (enderecoId != null && enderecoId != DBNull.Value)
            {
                var cmdEnd = new SqlCommand("DELETE FROM Endereco WHERE Id = @Id", con);
                cmdEnd.Parameters.AddWithValue("@Id", enderecoId);
                cmdEnd.ExecuteNonQuery();
            }
        }

        public Contato? Buscar(int id)
        {
            using var con = new SqlConnection(_conexao);
            con.Open();

            var cmd = new SqlCommand("SELECT * FROM vw_Contatos WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
                return CriarContato(reader);

            return null;
        }

        // Método auxiliar que monta um objeto Contato a partir de uma linha
        // retornada pelo banco de dados (SqlDataReader)
        private Contato CriarContato(SqlDataReader reader)
        {
            // Lê o tipo para saber qual subclasse instanciar
            string tipo = reader["Tipo"].ToString() ?? "";

            Contato c;
            if (tipo == "Pessoal")
            {
                // Polimorfismo: cria ContatoPessoal com seu campo específico
                c = new ContatoPessoal
                {
                    Apelido = reader["Apelido"].ToString()
                };
            }
            else
            {
                // Polimorfismo: cria ContatoProfissional com seus campos específicos
                c = new ContatoProfissional
                {
                    Empresa = reader["Empresa"].ToString(),
                    Cargo = reader["Cargo"].ToString()
                };
            }

            // Preenche os campos comuns da classe base Contato
            c.Id = Convert.ToInt32(reader["Id"]);
            c.Nome = reader["Nome"].ToString() ?? "";
            c.Telefone = reader["Telefone"].ToString() ?? "";
            c.Email = reader["Email"].ToString() ?? "";
            c.Favorito = Convert.ToBoolean(reader["Favorito"]);

            // Monta o objeto Endereco com os dados que vieram do JOIN da view
            c.Endereco = new Endereco
            {
                Id = reader["EnderecoId"] != DBNull.Value ? Convert.ToInt32(reader["EnderecoId"]) : 0,
                Cidade = reader["Cidade"].ToString() ?? "",
                Estado = reader["Estado"].ToString() ?? "",
                Rua = reader["Rua"].ToString() ?? ""
            };

            return c;
        }
    }
}