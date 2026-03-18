namespace EventosAPI.Interfaces
{
    /// <summary>
    /// Interface genérica para persistência em CSV.
    /// Demonstra uso de Generics (T) e programação orientada a contratos.
    /// Cada Service que lida com CSV implementa esta interface.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade a ser persistida.</typeparam>
    public interface ICsvPersistivel<T> where T : class
    {
        List<T> LerTodos();
        T? BuscarPorId(int id);
        void Salvar(T item);
        void Atualizar(T item);
        void Remover(int id);
    }
}
