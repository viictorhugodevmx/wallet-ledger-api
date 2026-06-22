using WalletLedgerApi.Dtos;
using WalletLedgerApi.Enums;
using WalletLedgerApi.Models;

namespace WalletLedgerApi.Validators;

public class LedgerEntryValidator
{
    public OperationResult<bool> Validate(
        Wallet wallet,
        CreateLedgerEntryRequestDto request,
        decimal currentBalance
    )
    {
        if (!wallet.IsActive)
        {
            return OperationResult<bool>.Fail(
                $"Wallet {wallet.WalletNumber} is not active."
            );
        }

        if (request.Amount <= 0)
        {
            return OperationResult<bool>.Fail(
                "Ledger entry amount must be greater than zero."
            );
        }

        bool isValidType =
            request.Type == LedgerEntryType.Credit ||
            request.Type == LedgerEntryType.Debit;

        if (!isValidType)
        {
            return OperationResult<bool>.Fail(
                "Ledger entry type must be Credit or Debit."
            );
        }

        if (request.Type == LedgerEntryType.Debit && request.Amount > currentBalance)
        {
            return OperationResult<bool>.Fail(
                "Insufficient wallet balance."
            );
        }

        return OperationResult<bool>.Ok(
            true,
            "Ledger entry validation approved."
        );
    }
}
