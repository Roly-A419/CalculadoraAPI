using Microsoft.AspNetCore.Mvc;

namespace Calculadora_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{
    [HttpGet("calcular")]
    public IActionResult Calcular([FromQuery] string operacion, [FromQuery] int a, [FromQuery] int b)
    {
        double result;
        switch (operacion.ToLower())
        {
            case "sumar":
                result = a + b;
                break;
            case "restar":
                result = a - b;
                break;
            case "multiplicar":
                result = a * b;
                break;
            case "dividir":
                if (b == 0)
                {
                    return BadRequest("No se puede dividir entre cero.");
                }
                result = a / (double)b;
                break;
            default:
                return BadRequest("Operación no válida.");
        }

        var response = new
        {
            a = a,
            b = b,
            operacion = operacion,
            result = result
        };
        
        return Ok(response);
    }
}