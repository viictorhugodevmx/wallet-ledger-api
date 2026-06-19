using Microsoft.AspNetCore.Mvc;
using WalletLedgerApi.Dtos;

namespace WalletLedgerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<ApiResponse<object>> GetHealth()
    {
        var health = new
        {
            status = "Healthy",
            service = "wallet-ledger-api",
            checkedAtUtc = DateTime.UtcNow
        };

        return Ok(ApiResponse<object>.Ok(
            health,
            "API is healthy."
        ));
    }
}
