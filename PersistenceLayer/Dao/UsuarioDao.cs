using PersistenceLayer.Enums;

namespace PersistenceLayer.Dao;

public class UsuarioDao
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public Cargos Cargo { get; set; }
}