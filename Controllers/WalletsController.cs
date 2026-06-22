using Microsoft.AspNetCore.Mvc;
using WalletLedgerApi.Dtos;
using WalletLedgerApi.Models;
using WalletLedgerApi.Services;

namespace WalletLedgerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletsController : ControllerBase
{
    private readonly WalletService _walletService;
    private readonly LedgerService _ledgerService;
    private readonly WalletBalanceService _walletBalanceService;

    public WalletsController(
        WalletService walletService,
        LedgerService ledgerService,
        WalletBalanceService walletBalanceService
    )
    {
        _walletService = walletService;
        _ledgerService = ledgerService;
        _walletBalanceService = walletBalanceService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<List<WalletResponseDto>>> GetWallets()
    {
        List<WalletResponseDto> wallets = _walletService.GetWallets();

        return Ok(ApiResponse<List<WalletResponseDto>>.Ok(
            wallets,
            "Wallets retrieved successfully."
        ));
    }

    [HttpGet("{walletNumber}")]
    public ActionResult<ApiResponse<WalletResponseDto>> GetWalletByNumber(
        string walletNumber
    )
    {
        WalletResponseDto? wallet = _walletService.GetWalletByNumber(walletNumber);

        if (wallet is null)
        {
            return NotFound(ApiResponse<WalletResponseDto>.Fail(
                $"Wallet {walletNumber} was not found."
            ));
        }

        return Ok(ApiResponse<WalletResponseDto>.Ok(
            wallet,
            "Wallet retrieved successfully."
        ));
    }

    [HttpGet("{walletNumber}/ledger")]
    public ActionResult<ApiResponse<List<LedgerEntryResponseDto>>> GetLedgerEntries(
        string walletNumber
    )
    {
        WalletResponseDto? wallet = _walletService.GetWalletByNumber(walletNumber);

        if (wallet is null)
        {
            return NotFound(ApiResponse<List<LedgerEntryResponseDto>>.Fail(
                $"Wallet {walletNumber} was not found."
            ));
        }

        List<LedgerEntryResponseDto> entries =
            _ledgerService.GetEntriesByWalletNumber(walletNumber);

        return Ok(ApiResponse<List<LedgerEntryResponseDto>>.Ok(
            entries,
            "Ledger entries retrieved successfully."
        ));
    }

    [HttpGet("{walletNumber}/balance")]
    public ActionResult<ApiResponse<WalletBalanceResponseDto>> GetBalance(
        string walletNumber
    )
    {
        Wallet? wallet = _walletService.GetRawWalletByNumber(walletNumber);

        if (wallet is null)
        {
            return NotFound(ApiResponse<WalletBalanceResponseDto>.Fail(
                $"Wallet {walletNumber} was not found."
            ));
        }

        List<LedgerEntry> entries =
            _ledgerService.GetRawEntriesByWalletNumber(walletNumber);

        WalletBalanceResponseDto balance =
            _walletBalanceService.BuildBalance(wallet, entries);

        return Ok(ApiResponse<WalletBalanceResponseDto>.Ok(
            balance,
            "Wallet balance calculated successfully."
        ));
    }
}
