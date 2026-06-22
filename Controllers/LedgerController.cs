using Microsoft.AspNetCore.Mvc;
using WalletLedgerApi.Dtos;
using WalletLedgerApi.Models;
using WalletLedgerApi.Services;

namespace WalletLedgerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LedgerController : ControllerBase
{
    private readonly WalletService _walletService;
    private readonly LedgerService _ledgerService;
    private readonly LedgerDashboardService _ledgerDashboardService;

    public LedgerController(
        WalletService walletService,
        LedgerService ledgerService,
        LedgerDashboardService ledgerDashboardService
    )
    {
        _walletService = walletService;
        _ledgerService = ledgerService;
        _ledgerDashboardService = ledgerDashboardService;
    }

    [HttpGet("dashboard")]
    public ActionResult<ApiResponse<LedgerDashboardResponseDto>> GetDashboard()
    {
        List<Wallet> wallets = _walletService.GetRawWallets();
        List<LedgerEntry> entries = _ledgerService.GetRawEntries();

        LedgerDashboardResponseDto dashboard =
            _ledgerDashboardService.BuildDashboard(wallets, entries);

        return Ok(ApiResponse<LedgerDashboardResponseDto>.Ok(
            dashboard,
            "Ledger dashboard retrieved successfully."
        ));
    }
}
