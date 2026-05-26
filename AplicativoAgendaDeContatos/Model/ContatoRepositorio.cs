using AgendaContatos.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AgendaContatos.Models
{
    public class ContatoRepositorio
    {
        private readonly string _caminho = "contatos.json";
        private List<Contato> _contatos = new List<Contato>();

        private readonly JsonSerializerOptions _opcoes = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ContatoConverter() }
        };

        public ContatoRepositorio() => Carregar();

        public List<Contato> ListarTodos() => _contatos;

        public void Adicionar(Contato c)
        {
            c.Id = _contatos.Count > 0 ? _contatos.Max(x => x.Id) + 1 : 1;
            _contatos.Add(c);
            Salvar();
        }

        public void Atualizar(Contato atualizado)
        {
            int i = _contatos.FindIndex(c => c.Id == atualizado.Id);
            if (i >= 0) { _contatos[i] = atualizado; Salvar(); }
        }

        public void Remover(int id)
        {
            _contatos.RemoveAll(c => c.Id == id);
            Salvar();
        }

        public Contato? Buscar(int id) =>
            _contatos.FirstOrDefault(c => c.Id == id);

        private void Salvar()
        {
            string json = JsonSerializer.Serialize(_contatos, _opcoes);
            File.WriteAllText(_caminho, json);
        }

        private void Carregar()
        {
            if (!File.Exists(_caminho)) return;
            string json = File.ReadAllText(_caminho);
            _contatos = JsonSerializer.Deserialize<List<Contato>>(json, _opcoes)
                        ?? new List<Contato>();
        }
    }

    public class ContatoConverter : JsonConverter<Contato>
    {
        public override Contato? Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            string tipo = doc.RootElement.GetProperty("Tipo").GetString() ?? "";

            return tipo switch
            {
                "Pessoal" => JsonSerializer.Deserialize<ContatoPessoal>(doc.RootElement.GetRawText()),
                "Profissional" => JsonSerializer.Deserialize<ContatoProfissional>(doc.RootElement.GetRawText()),
                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer,
            Contato value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("Tipo", value.GetTipo());

            var innerOptions = new JsonSerializerOptions { WriteIndented = false };
            JsonDocument doc;

            if (value is ContatoPessoal p)
                doc = JsonSerializer.SerializeToDocument(p, innerOptions);
            else
                doc = JsonSerializer.SerializeToDocument((ContatoProfissional)value, innerOptions);

            foreach (var prop in doc.RootElement.EnumerateObject())
                prop.WriteTo(writer);

            writer.WriteEndObject();
        }
    }
}