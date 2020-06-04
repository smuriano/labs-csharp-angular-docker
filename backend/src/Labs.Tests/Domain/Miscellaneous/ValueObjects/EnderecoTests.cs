using System;
using Labs.Domain.Miscellaneous.ValueObjects;
using Labs.Tests.Helpers;
using Xunit;

namespace MavveErp.Domain.Tests.Miscellaneous.ValueObjects
{
  public class EnderecoTests
  {
    private string _cep;
    private string _logradouro;
    private string _numero;
    private string _complemento;
    private string _bairro;
    private string _cidade;
    private string _estado;
    public EnderecoTests()
    {
      _cep = "15115000";
      _logradouro = "Av Deolinda Scabora Damasio";
      _numero = "496";
      _complemento = "Casa";
      _bairro = "Borboleta 2";
      _cidade = "Bady Bassitt";
      _estado = "SP";
    }

    [Fact]
    public void NotShouldReturnMessageWhenAddressInformedButDetailNotInformed()
    {
      var endereco = new Endereco(_cep, _logradouro, _numero, "", _bairro, _cidade, _estado);
      Console.WriteLine(endereco);

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
      Assert.Equal(1, endereco.ValidationResult.Errors.Count);
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
  }
}
