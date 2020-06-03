using System;
using Labs.Domain.Medicos.Entities;
using Labs.Tests.Helpers;
using Xunit;

namespace Labs.Tests.Domain.Medicos.Entities
{
  public class MedicoTests
  {
    [Fact]
    public void SucessoAoCriarMedico()
    {
      // Arrange
      var nome = TestHelpers.RandomString(60);
      var crm = TestHelpers.RandomString(10);
      var especialidade = TestHelpers.RandomString(30);

      // Act
      var medico = new Medico(nome, crm, especialidade);

      // Assert
      Assert.NotEqual(Guid.Empty, medico.Id);
      Assert.Equal(nome, medico.Nome);
      Assert.Equal(crm, medico.CRM);
      Assert.Equal(especialidade, medico.Especialidade);
    }

    [Fact]
    public void SucessoAoAtualizarMedico()
    {
      // Arrange
      var nome = TestHelpers.RandomString(60);
      var crm = TestHelpers.RandomString(10);
      var especialidade = TestHelpers.RandomString(30);
      var medico = new Medico(nome, crm, especialidade);

      var novoNome = TestHelpers.RandomString(60);
      var novoCRM = TestHelpers.RandomString(10);
      var novaEspecialidade = TestHelpers.RandomString(30);

      // Act
      medico.Update(novoNome, novoCRM, novaEspecialidade);

      // Assert
      Assert.Equal(novoNome, medico.Nome);
      Assert.Equal(novoCRM, medico.CRM);
      Assert.Equal(novaEspecialidade, medico.Especialidade);
    }

    [Fact]
    public void RetornaToStringFormatadoParaMedido()
    {
      // Arrange
      var nome = TestHelpers.RandomString(60);
      var crm = TestHelpers.RandomString(10);
      var especialidade = TestHelpers.RandomString(30);

      // Act
      var medico = new Medico(nome, crm, especialidade);

      // Assert
      Assert.Equal($"{nome} | {crm}", medico.ToString());
    }

    [Theory]
    [InlineData("", "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome é obrigatório")]
    [InlineData(null, "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi", "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome deve ter no máximo 60 caracteres")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "", "abcdefghijklmnopqrstuvwxyzabcd", "CRM é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", null, "abcdefghijklmnopqrstuvwxyzabcd", "CRM é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "12345678901", "abcdefghijklmnopqrstuvwxyzabcd", "CRM deve ter no máximo 10 caracteres")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", "", "Especialidade é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", null, "Especialidade é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", "abcdefghijklmnopqrstuvwxyzabcde", "Especialidade deve ter no máximo 30 caracteres")]
    public void RetornaNotificacaoQuandoTentarCriarMedicoInvalido(string nome, string crm, string especialidade, string message)
    {
      // Arrange

      // Act
      var medico = new Medico(nome, crm, especialidade);

      // Assert
      Assert.False(medico.IsValid);
      Assert.Equal(1, medico.ValidationResult.Errors.Count);
      Assert.Equal(message, medico.ValidationResult.Errors[0].ErrorMessage);
    }

    [Theory]
    [InlineData("", "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome é obrigatório")]
    [InlineData(null, "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi", "1234567890", "abcdefghijklmnopqrstuvwxyzabcd", "Nome deve ter no máximo 60 caracteres")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "", "abcdefghijklmnopqrstuvwxyzabcd", "CRM é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", null, "abcdefghijklmnopqrstuvwxyzabcd", "CRM é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "12345678901", "abcdefghijklmnopqrstuvwxyzabcd", "CRM deve ter no máximo 10 caracteres")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", "", "Especialidade é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", null, "Especialidade é obrigatório")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgh", "1234567890", "abcdefghijklmnopqrstuvwxyzabcde", "Especialidade deve ter no máximo 30 caracteres")]
    public void RetornaNotificacaoQuandoTentarAtualizarMedicoInvalido(string nome, string crm, string especialidade, string message)
    {
      // Arrange
      var medico = new Medico(TestHelpers.RandomString(60), TestHelpers.RandomString(10), TestHelpers.RandomString(30));

      // Act
      medico.Update(nome, crm, especialidade);

      // Assert
      Assert.False(medico.IsValid);
      Assert.Equal(1, medico.ValidationResult.Errors.Count);
      Assert.Equal(message, medico.ValidationResult.Errors[0].ErrorMessage);
    }
  }
}