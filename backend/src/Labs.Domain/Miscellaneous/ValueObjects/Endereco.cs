using FluentValidation;
using Labs.Shared.ValueObjects;

namespace Labs.Domain.Miscellaneous.ValueObjects
{
  public class Endereco : ValueObject
  {
    public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string estado)
    {
      Cep = cep;
      Logradouro = logradouro;
      Numero = numero;
      Complemento = complemento;
      Bairro = bairro;
      Cidade = cidade;
      Estado = estado;

      Validate(this, new EnderecoValidation());
    }

    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }

    public override string ToString()
    {
      return $"{Logradouro}, {Numero} - {Complemento}, {Bairro}, {Cidade}, {Estado}";
    }
  }
  public class EnderecoValidation : AbstractValidator<Endereco>
  {
    public EnderecoValidation()
    {
      RuleFor(a => a.Cep)
        .NotEmpty().When(a => !string.IsNullOrEmpty(a.Logradouro)).WithMessage("Cep é obrigatório");

      RuleFor(a => a.Cep)
        .MinimumLength(8).WithMessage("Cep deve ter no mínimo 5 caracteres");

      RuleFor(a => a.Logradouro)
        .NotEmpty().When(a => !string.IsNullOrEmpty(a.Cep)).WithMessage("Endereço é obrigatório");

      When(a => !string.IsNullOrEmpty(a.Logradouro), () =>
      {
        RuleFor(a => a.Numero)
          .NotEmpty().WithMessage("Número é obrigatório");

        RuleFor(a => a.Bairro)
          .NotEmpty().WithMessage("Bairro é obrigatório");

        RuleFor(a => a.Cidade)
          .NotEmpty().WithMessage("Cidade é obrigatório");
      });

      When(a => !string.IsNullOrEmpty(a.Cidade), () =>
      {
        RuleFor(a => a.Estado)
          .NotEmpty().WithMessage("Estado é obrigatório");
      });
    }
  }
}