using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.PostosColeta.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class PostosColetaController : ControllerBase
  {
    private readonly IPostoColetaRepository _postoColetaRepository;

    public PostosColetaController(IPostoColetaRepository postoColetaRepository)
    {
      _postoColetaRepository = postoColetaRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostoColetaViewModel>>> GetAll()
    {
      var postoColetaList = await _postoColetaRepository.GetAllAsync();
      var result = new List<PostoColetaViewModel>();

      foreach (var postoColeta in postoColetaList)
      {
        result.Add(
          new PostoColetaViewModel
          {
            Id = postoColeta.Id,
            LabId = postoColeta.LabId,
            Descricao = postoColeta.Descricao
          });
      }

      return Ok(result);
    }
  }
}