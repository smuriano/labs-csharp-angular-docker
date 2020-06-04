using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.Exames.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class ExamesController : ControllerBase
  {
    private readonly IExameRepository _exameRepository;

    public ExamesController(IExameRepository exameRepository)
    {
      _exameRepository = exameRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExameViewModel>>> GetAll()
    {
      var exameList = await _exameRepository.GetAllAsync();
      var result = new List<ExameViewModel>();

      foreach (var exame in exameList)
      {
        result.Add(
          new ExameViewModel
          {
            Id = exame.Id,
            Descricao = exame.Descricao,
            Preco = exame.Preco
          });
      }

      return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<ExameViewModel>> GetById(Guid id)
    {
      var exame = await _exameRepository.GetByIdAsync(id);
      var result = new ExameViewModel
      {
        Id = exame.Id,
        Descricao = exame.Descricao,
        Preco = exame.Preco
      };

      return Ok(result);
    }
  }
}