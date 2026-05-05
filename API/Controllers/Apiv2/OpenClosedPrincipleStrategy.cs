using Aplication.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Apiv2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OpenClosedPrincipleStrategy : ControllerBase
{
   private readonly IDiscountApplicationService _discountApplicationService;

   public OpenClosedPrincipleStrategy(IDiscountApplicationService discountApplicationService)
   {
      _discountApplicationService = discountApplicationService;
   }
   
   [HttpPost("fixed")]
   public async Task<IActionResult> ProcessDiscount(decimal discountAmount, decimal OriginalAmount)
   {
      var result = await _discountApplicationService.ApplyFixedDiscountAsync(OriginalAmount, discountAmount);
      return Ok(result);
   }

   [HttpPost("percentage")]
   public async Task<IActionResult> ProcessDiscountPercentage(decimal percentage, decimal OriginalAmount)
   {
      var result = await _discountApplicationService.ApplyPercentageDiscountAsync(OriginalAmount, percentage);
      return Ok(result);
   }
}