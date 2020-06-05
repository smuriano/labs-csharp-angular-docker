using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Domain.Exames.Entities;
using Labs.Domain.Exames.Repositories;
using Labs.Domain.Medicos.Entities;
using Labs.Domain.Medicos.Repositories;
using Labs.Domain.Miscellaneous.ValueObjects;
using Labs.Domain.OrdensServico.Entities;
using Labs.Domain.OrdensServico.Repositories;
using Labs.Domain.Pacientes.Entities;
using Labs.Domain.Pacientes.Repositories;
using Labs.Domain.PostosColeta.Entities;
using Labs.Domain.PostosColeta.Repositories;
using Labs.Domain.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class SeedController : ControllerBase
  {
    private readonly IExameRepository _exameRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IOrdemServicoRepository _ordemServicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPostoColetaRepository _postoColetaRepository;
    private readonly IUoW _uow;

    public SeedController(
        IExameRepository exameRepository,
        IMedicoRepository medicoRepository,
        IOrdemServicoRepository ordemServicoRepository,
        IPacienteRepository pacienteRepository,
        IPostoColetaRepository postoColetaRepository,
        IUoW uow)
    {
      _exameRepository = exameRepository;
      _medicoRepository = medicoRepository;
      _ordemServicoRepository = ordemServicoRepository;
      _pacienteRepository = pacienteRepository;
      _postoColetaRepository = postoColetaRepository;
      _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetAll()
    {
      try
      {
        var exames = new List<Exame>();
        exames.Add(new Exame("Hemograma", 12.34M));
        exames.Add(new Exame("Hemograma", 12.34M));
        exames.Add(new Exame("Glicose", 12.34M));
        exames.Add(new Exame("GPP", 12.34M));
        exames.Add(new Exame("Glicemia", 12.34M));
        exames.Add(new Exame("Colesterol e triglicerídeos", 12.34M));
        exames.Add(new Exame("TGO", 12.34M));
        exames.Add(new Exame("TGP", 12.34M));
        exames.Add(new Exame("TSH", 12.34M));
        exames.Add(new Exame("T4L", 12.34M));
        exames.Add(new Exame("Ácido úrico", 12.34M));
        exames.Add(new Exame("Eletrocardiograma", 12.34M));
        exames.Add(new Exame("Ecocardiograma", 12.34M));
        exames.Add(new Exame("PSA", 12.34M));
        exames.Add(new Exame("GPP", 12.34M));
        exames.Add(new Exame("HbA1C", 12.34M));
        exames.Add(new Exame("HDL", 12.34M));

        exames.ForEach(x => _exameRepository.AddAsync(x));

        var medicos = new List<Medico>();
        medicos.Add(new Medico("Alexandre Ribeiro Garcia", "094649", "Cardiologia"));
        medicos.Add(new Medico("Ivair de Almeida", "070399", "Cardiologia"));
        medicos.Add(new Medico("Eduardo Sargi", "048464", "Cardiologia"));
        medicos.Add(new Medico("Helio Augusto dos Reis Corbucci", "064608", "Cardiologia"));

        medicos.ForEach(x => _medicoRepository.AddAsync(x));

        var pacientes = new List<Paciente>();
        pacientes.Add(new Paciente(
          "Oliver Cauã Melo",
          "49678917807",
          "383575229",
          DateTime.Parse("1999-03-16"),
          "M",
          new Endereco("12604170",
              "Rua Luís Gonçalves",
              "890",
              "",
              "Vila Geny",
              "Lorena",
              "SP"),
          "12991802113"));

        pacientes.Add(new Paciente(
          "Marina Alícia Vieira",
          "21311632824",
          "100953347",
          DateTime.Parse("2000-07-02"),
          "F",
          new Endereco("13473010",
              "Avenida Paschoal Ardito",
              "929",
              "",
              "Vila Belvedere",
              "Americana",
              "SP"),
          "19986828431"));

        pacientes.Add(new Paciente(
          "Isis Eliane Raimunda Gomes",
          "13331762873",
          "491587892",
          DateTime.Parse("1943-04-13"),
          "F",
          new Endereco("15300970",
              "Rua José Desiderio Fernandes 1046",
              "505",
              "",
              "Centro",
              "General Salgado",
              "SP"),
          "17981247195"));

        pacientes.Add(new Paciente(
          "Maya Vera Malu Fogaça",
          "90324034865",
          "365011721",
          DateTime.Parse("1952-08-04"),
          "F",
          new Endereco("19053019",
              "Travessa Doze",
              "794",
              "",
              "Vila Nova Prudente",
              "Presidente Prudente",
              "SP"),
          "18992053931"));

        pacientes.Add(new Paciente(
          "Betina Eloá Moraes",
          "60175578826",
          "389290403",
          DateTime.Parse("1961-01-10"),
          "F",
          new Endereco("17031596",
              "Rua Antônio Durand",
              "285",
              "",
              "Conjunto Habitacional Pastor Arlindo Lopes Viana",
              "Bauru",
              "SP"),
          "14994303876"));

        pacientes.Add(new Paciente(
          "Isabel Benedita Baptista",
          "51991289812",
          "505588493",
          DateTime.Parse("1980-01-04"),
          "F",
          new Endereco("05790270",
              "Rua General Silva Braga",
              "699",
              "",
              "Jardim Maria Sampaio",
              "São Paulo",
              "SP"),
          "11991019653"));

        pacientes.Add(new Paciente(
          "Tânia Mirella Ribeiro",
          "79481356850",
          "397635291",
          DateTime.Parse("1990-04-02"),
          "F",
          new Endereco("13348180",
              "Rua Antônio B. de Campos Penteado",
              "597",
              "",
              "Jardim Morada do Sol",
              "Indaiatuba",
              "SP"),
          "19989810633"));

        pacientes.Add(new Paciente(
          "Victor Carlos Freitas",
          "79260223814",
          "350357547",
          DateTime.Parse("1992-08-10"),
          "M",
          new Endereco("11702240",
              "Rua Nicarágua",
              "429",
              "",
              "Guilhermina",
              "Praia Grande",
              "SP"),
          "13984126241"));

        pacientes.Add(new Paciente(
          "Victor Emanuel Freitas",
          "21533168806",
          "228137688",
          DateTime.Parse("1968-03-18"),
          "M",
          new Endereco("15092050",
              "Rua João Antônio Sicoli",
              "789",
              "",
              "Jardim Maracanã",
              "São José do Rio Preto",
              "SP"),
          "17982116360"));

        pacientes.Add(new Paciente(
          "Erick Jorge Ramos",
          "70792428862",
          "355727365",
          DateTime.Parse("1974-11-07"),
          "M",
          new Endereco("06020010",
              "Avenida dos Autonomistas",
              "404",
              "",
              "Vila Yara",
              "Osasco",
              "SP"),
          "11987780575"));

        pacientes.ForEach(x => _pacienteRepository.AddAsync(x));

        var postosColeta = new List<PostoColeta>();
        postosColeta.Add(new PostoColeta(
          Guid.Parse("00d29d77-d94f-4314-8880-9fa968fec84a"),
          "Laboratório Tajara - Matriz",
          new Endereco("15090500",
              "Av. José Munia",
              "7000",
              "",
              "Jardim Bosque das Vivendas",
              "São José do Rio Preto",
              "SP")));

        postosColeta.Add(new PostoColeta(
          Guid.Parse("00d29d77-d94f-4314-8880-9fa968fec84a"),
          "Laboratório Tajara - Unidade Cila",
          new Endereco("15015800",
              "R. Cila",
              "3092",
              "",
              "Vila Redentora",
              "São José do Rio Preto",
              "SP")));

        postosColeta.Add(new PostoColeta(
          Guid.Parse("00d29d77-d94f-4314-8880-9fa968fec84a"),
          "Laboratório Tajara - Unidade Cidade Norte",
          new Endereco("15046619",
              "Av. Alfredo Antônio de Oliveira",
              "2077",
              "",
              "Jardim Planalto",
              "São José do Rio Preto",
              "SP")));

        postosColeta.ForEach(x => _postoColetaRepository.AddAsync(x));
        await _uow.CommitAsync();

        var postoColeta1 = (await _postoColetaRepository.FindByAsync(x => x.Descricao == "Laboratório Tajara - Matriz")).SingleOrDefault().Id;

        var paciente1 = (await _pacienteRepository.FindByAsync(x => x.Nome == "Oliver Cauã Melo")).SingleOrDefault().Id;
        var paciente2 = (await _pacienteRepository.FindByAsync(x => x.Nome == "Isis Eliane Raimunda Gomes")).SingleOrDefault().Id;
        var paciente3 = (await _pacienteRepository.FindByAsync(x => x.Nome == "Betina Eloá Moraes")).SingleOrDefault().Id;
        var paciente4 = (await _pacienteRepository.FindByAsync(x => x.Nome == "Maya Vera Malu Fogaça")).SingleOrDefault().Id;
        var paciente5 = (await _pacienteRepository.FindByAsync(x => x.Nome == "Tânia Mirella Ribeiro")).SingleOrDefault().Id;

        var medico1 = (await _medicoRepository.FindByAsync(x => x.Nome == "Alexandre Ribeiro Garcia")).SingleOrDefault().Id;
        var medico2 = (await _medicoRepository.FindByAsync(x => x.Nome == "Ivair de Almeida")).SingleOrDefault().Id;
        var medico3 = (await _medicoRepository.FindByAsync(x => x.Nome == "Helio Augusto dos Reis Corbucci")).SingleOrDefault().Id;

        var exame1 = (await _exameRepository.FindByAsync(x => x.Descricao == "TGO")).SingleOrDefault().Id;
        var exame2 = (await _exameRepository.FindByAsync(x => x.Descricao == "TGP")).SingleOrDefault().Id;
        var exame3 = (await _exameRepository.FindByAsync(x => x.Descricao == "TSH")).SingleOrDefault().Id;

        var ordemServicoExames = new List<OrdemServicoExame>();
        ordemServicoExames.Add(new OrdemServicoExame(Guid.Empty, exame1, 12.34M));
        ordemServicoExames.Add(new OrdemServicoExame(Guid.Empty, exame2, 12.34M));
        ordemServicoExames.Add(new OrdemServicoExame(Guid.Empty, exame3, 12.34M));

        var ordemServico1 = new OrdemServico(postoColeta1, DateTime.Parse("2020-05-28"), paciente1, "Unimed", medico1, DateTime.Parse("2020-06-01"));
        var ordemServico2 = new OrdemServico(postoColeta1, DateTime.Parse("2020-05-28"), paciente2, "Ben Saúde", medico1, DateTime.Parse("2020-06-01"));
        var ordemServico3 = new OrdemServico(postoColeta1, DateTime.Parse("2020-05-28"), paciente3, "SulAmerica Saúde", medico2, DateTime.Parse("2020-06-01"));
        var ordemServico4 = new OrdemServico(postoColeta1, DateTime.Parse("2020-05-28"), paciente4, "Unimed", medico2, DateTime.Parse("2020-06-01"));
        var ordemServico5 = new OrdemServico(postoColeta1, DateTime.Parse("2020-05-28"), paciente5, "Austa Cliníca", medico3, DateTime.Parse("2020-06-01"));

        ordemServico1.AddExames(ordemServicoExames);
        ordemServico2.AddExames(ordemServicoExames);
        ordemServico3.AddExames(ordemServicoExames);
        ordemServico4.AddExames(ordemServicoExames);
        ordemServico5.AddExames(ordemServicoExames);

        await _ordemServicoRepository.AddAsync(ordemServico1);
        await _ordemServicoRepository.AddAsync(ordemServico2);
        await _ordemServicoRepository.AddAsync(ordemServico3);
        await _ordemServicoRepository.AddAsync(ordemServico4);
        await _ordemServicoRepository.AddAsync(ordemServico5);

        await _uow.CommitAsync();
        return Ok(Task.CompletedTask);
      }
      catch
      {
        await _uow.RollbackAsync();
        return BadRequest();
      }
    }
  }
}