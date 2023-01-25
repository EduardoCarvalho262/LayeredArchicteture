using BusinessLayer.Enums;

namespace BusinessLayer.Dto;

public class UsuarioDto
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public Cargos Cargo { get; set; }
}