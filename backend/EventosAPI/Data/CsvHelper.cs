using System.Reflection;

namespace EventosAPI.Data
{
    /// <summary>
    /// Classe utilitária genérica para leitura e escrita de arquivos CSV.
    /// Demonstra uso de Generics, Reflection e Tratamento de Exceções.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade a ser serializada/desserializada.</typeparam>
    public static class CsvHelper<T> where T : class, new()
    {
        private static readonly string Separador = ";";

        /// <summary>
        /// Lê todos os registros de um arquivo CSV e converte para List T.
        /// Usa Reflection para mapear colunas do CSV às propriedades do objeto.
        /// </summary>
        public static List<T> LerCsv(string caminhoArquivo)
        {
            var lista = new List<T>();

            try
            {
                if (!File.Exists(caminhoArquivo))
                    return lista;

                var linhas = File.ReadAllLines(caminhoArquivo);
                if (linhas.Length < 2) // precisa de header + pelo menos 1 registro
                    return lista;

                var headers = linhas[0].Split(Separador);
                var propriedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                for (int i = 1; i < linhas.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(linhas[i]))
                        continue;

                    var valores = linhas[i].Split(Separador);
                    var obj = new T();

                    for (int j = 0; j < headers.Length && j < valores.Length; j++)
                    {
                        var prop = propriedades.FirstOrDefault(p =>
                            p.Name.Equals(headers[j].Trim(), StringComparison.OrdinalIgnoreCase));

                        if (prop != null && prop.CanWrite)
                        {
                            try
                            {
                                var valor = ConverterValor(valores[j].Trim(), prop.PropertyType);
                                prop.SetValue(obj, valor);
                            }
                            catch (Exception)
                            {
                                // Se falhar a conversão de um campo, ignora e continua
                            }
                        }
                    }

                    lista.Add(obj);
                }
            }
            catch (IOException ex)
            {
                throw new IOException($"Erro ao ler arquivo CSV '{caminhoArquivo}': {ex.Message}", ex);
            }

            return lista;
        }

        /// <summary>
        /// Escreve uma lista de objetos em arquivo CSV (sobrescreve o arquivo).
        /// </summary>
        public static void EscreverCsv(string caminhoArquivo, List<T> itens)
        {
            try
            {
                var diretorio = Path.GetDirectoryName(caminhoArquivo);
                if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                var propriedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite)
                    .ToArray();

                var linhas = new List<string>
                {
                    // Header
                    string.Join(Separador, propriedades.Select(p => p.Name))
                };

                // Dados
                foreach (var item in itens)
                {
                    var valores = propriedades.Select(p =>
                    {
                        var val = p.GetValue(item);
                        if (val is DateTime dt)
                            return dt.ToString("yyyy-MM-dd HH:mm:ss");
                        if (val is bool b)
                            return b.ToString().ToLower();
                        if (val is List<string> lista)
                            return string.Join("|", lista);
                        return val?.ToString() ?? "";
                    });
                    linhas.Add(string.Join(Separador, valores));
                }

                File.WriteAllLines(caminhoArquivo, linhas);
            }
            catch (IOException ex)
            {
                throw new IOException($"Erro ao escrever arquivo CSV '{caminhoArquivo}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adiciona um único registro ao final do arquivo CSV.
        /// </summary>
        public static void AdicionarRegistro(string caminhoArquivo, T item)
        {
            var itens = LerCsv(caminhoArquivo);
            itens.Add(item);
            EscreverCsv(caminhoArquivo, itens);
        }

        /// <summary>
        /// Converte string do CSV para o tipo correto da propriedade.
        /// Suporta int, string, bool, DateTime, enums e List de string.
        /// </summary>
        private static object? ConverterValor(string valor, Type tipo)
        {
            if (string.IsNullOrEmpty(valor))
                return tipo.IsValueType ? Activator.CreateInstance(tipo) : null;

            // Nullable types
            var tipoBase = Nullable.GetUnderlyingType(tipo) ?? tipo;

            if (tipoBase == typeof(int))
                return int.Parse(valor);
            if (tipoBase == typeof(bool))
                return bool.Parse(valor);
            if (tipoBase == typeof(DateTime))
                return DateTime.Parse(valor);
            if (tipoBase == typeof(double))
                return double.Parse(valor);
            if (tipoBase.IsEnum)
                return Enum.Parse(tipoBase, valor, ignoreCase: true);
            if (tipoBase == typeof(List<string>))
                return valor.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            return valor;
        }
    }
}
