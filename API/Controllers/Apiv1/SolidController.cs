using Aplication.Interfaces;
using Application.DTOs;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Apiv1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SolidController : ControllerBase
{
    private readonly IOrderProcessorService _orderProcessorService;

    public SolidController(IOrderProcessorService orderProcessorService)
    {
        _orderProcessorService = orderProcessorService;
    }
    
    [HttpPost]
    public async Task<IActionResult> ProcessOrder([FromBody] OrderRequestDTO requestDto)
    {
        await _orderProcessorService.ProcessOrderAsync(requestDto);
        return Ok(new { message = "Pedido processado com sucesso!" });
    }

}