using WalletLedgerApi.Dtos;
using WalletLedgerApi.Enums;
using WalletLedgerApi.Models;

namespace WalletLedgerApi.Services;

public class WalletBalanceService
{
    public WalletBalanceResponseDto BuildBalance(
        Wallet wallet,
        List<LedgerEntry> entries
    )
    {
        decimal totalCredits = entries
            .Where(entry => entry.Type == LedgerEntryType.Credit)
            .Sum(entry => entry.Amount);

        decimal totalDebits = entries
            .Where(entry => entry.Type == LedgerEntryType.Debit)
            .Sum(entry => entry.Amount);

        return new WalletBalanceResponseDto
        {
            WalletNumber = wallet.WalletNumber,
            OwnerName = wallet.OwnerName,
            Currency = wallet.Currency,
            TotalCredits = totalCredits,
            TotalDebits = totalDebits,
            Balance = totalCredits - totalDebits,
            CalculatedAtUtc = DateTime.UtcNow
        };
    }
}
