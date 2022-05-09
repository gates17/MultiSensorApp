using Microsoft.AspNetCore.Mvc;

namespace MultiSensorAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // como ligar as duas API
        // uma diferença : no meu delete vou ter que ter em conta a cena do inactive
        // fazer o get e update para mudar o IsInactive pra true. IsInactive = !IsInactive. Não posso chamar ao método Delete.


    }
}
