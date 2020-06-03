using Labs.Domain.Miscellaneous.ValueObjects;
using Xunit;

namespace MavveErp.Domain.Tests.Miscellaneous.ValueObjects
{
  public class EnderecoTests
  {
    readonly string _cep = "15115000";
    readonly string _logradouro = "Av Deolinda Scabora Damasio";
    readonly string _numero = "496";
    readonly string _complemento = "Casa";
    readonly string _bairro = "Borboleta 2";
    readonly string _cidade = "Bady Bassitt";
    readonly string _estado = "SP";

    [Fact]
    public void ShouldReturnMessageWhenPostalCodeNotinformed()
    {
      var endereco = new Endereco("", _logradouro, _numero, _complemento, _bairro, _cidade, _estado);

      Assert.False(endereco.IsValid);
      Assert.Equal(2, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Cep", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Cep é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenAddressNotInformed()
    {
      var endereco = new Endereco(_cep, "", _numero, _complemento, _bairro, _cidade, _estado);

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Logradouro", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Endereço é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenAddressNumberNotinformed()
    {
      var endereco = new Endereco(_cep, _logradouro, "", _complemento, _bairro, _cidade, _estado);

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Numero", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Número é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenNeighborhoodNotinformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, "", _cidade, _estado);

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Bairro", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Bairro é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenCityNotInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, _bairro, "", _estado);

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Cidade", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Cidade é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenZipCodeAndCityCityNotInformedButAddressIsInformed()

    {
      var endereco = new Endereco("", _logradouro, _numero, _complemento, _bairro, "", _estado);


      Assert.False(endereco.IsValid);
      Assert.Equal(3, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Cep", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Cep é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
      Assert.Equal("Cidade", endereco.ValidationResult.Errors[2].PropertyName);
      Assert.Equal("Cidade é obrigatório", endereco.ValidationResult.Errors[2].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenStateNotInformedButCityIsInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, _bairro, _cidade, "");

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Estado", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Estado é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenStateAndCountryNotInformedButCityIsInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, _bairro, _cidade, "");

      Assert.False(endereco.IsValid);
      Assert.Equal(2, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Estado", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Estado é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShouldReturnMessageWhenCityStateAndCountryNotInformedButAddressIsInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, _bairro, "", "");

      Assert.False(endereco.IsValid);
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
      Assert.Equal("Cidade", endereco.ValidationResult.Errors[0].PropertyName);
      Assert.Equal("Cidade é obrigatório", endereco.ValidationResult.Errors[0].ErrorMessage);
    }


    [Fact]
    public void NotShouldReturnMessageWhenAddressInformedButDetailNotInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, "", _bairro, _cidade, _estado);

      Assert.True(endereco.IsValid);
      Assert.Equal(0, endereco.ValidationResult.Errors.Count);
    }

    [Fact]
    public void NotShouldReturnMessageWhenAddressIsValid()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, _complemento, _bairro, _cidade, _estado);

      Assert.True(endereco.IsValid);
      Assert.Equal(0, endereco.ValidationResult.Errors.Count);
    }
  }
}
