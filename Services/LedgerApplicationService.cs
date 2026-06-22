using WalletLedgerApi.Dtos;
using WalletLedgerApi.Models;
using WalletLedgerApi.Validators;

namespace WalletLedgerApi.Services;

public class LedgerApplicationService
{
    private readonly WalletService _walletService;
    private readonly LedgerService _ledgerService;
    private readonly LedgerEntryValidator _ledgerEntryValidator;

    public LedgerApplicationService(
        WalletService walletService,
        LedgerService ledgerService,
        LedgerEntryValidator ledgerEntryValidator
    )
    {
        _walletService = walletService;
        _ledgerService = ledgerService;
        _ledgerEntryValidator = ledgerEntryValidator;
    }

    public OperationResult<LedgerEntryResponseDto> CreateEntry(
        string walletNumber,
        CreateLedgerEntryRequestDto request
    )
    {
        Wallet? wallet = _walletService.GetRawWalletByNumber(walletNumber);

        if (wallet is null)
        {
            return OperationResult<LedgerEntryResponseDto>.Fail(
                $"Wallet {walletNumber} was not found."
            );
        }

        decimal currentBalance = _ledgerService.CalculateBalance(walletNumber);

        OperationResult<bool> validationResult =
            _ledgerEntryValidator.Validate(wallet, request, currentBalance);

        if (!validationResult.Success)
        {
            return OperationResult<LedgerEntryResponseDto>.Fail(
                validationResult.Message
            );
        }

        LedgerEntryResponseDto entry =
            _ledgerService.CreateEntry(wallet, request);

        return OperationResult<LedgerEntryResponseDto>.Ok(
            entry,
            "Ledger entry created successfully."
        );
    }
}
