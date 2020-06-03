using System;
using FluentValidation;
using Labs.Domain.Miscellaneous.ValueObjects;
using Labs.Shared.Entities;

namespace Labs.Domain.Pacientes.Entities
{
  public class Paciente : Entity
  {
    protected Paciente() { }

    public Paciente(string nome, string cpf, string rg, DateTime dataNascimento, string sexo, Endereco endereco, string celular)
    {
      Nome = nome;
      CPF = cpf;
      RG = rg;
      DataNascimento = dataNascimento;
      Sexo = sexo;
      Endereco = endereco;
      Celular = celular;

      Validate(this, new PacienteValidator());
    }

    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public string RG { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Sexo { get; private set; }
    public Endereco Endereco { get; private set; }
    public string Celular { get; private set; }
  }

  public class PacienteValidator : AbstractValidator<Paciente>
  {
    public PacienteValidator() { }
  }
}