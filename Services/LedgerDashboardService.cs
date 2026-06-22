using WalletLedgerApi.Dtos;
using WalletLedgerApi.Enums;
using WalletLedgerApi.Models;

namespace WalletLedgerApi.Services;

public class LedgerDashboardService
{
    public LedgerDashboardResponseDto BuildDashboard(
        List<Wallet> wallets,
        List<LedgerEntry> entries
    )
    {
        List<LedgerEntry> credits = entries
            .Where(entry => entry.Type == LedgerEntryType.Credit)
            .ToList();

        List<LedgerEntry> debits = entries
            .Where(entry => entry.Type == LedgerEntryType.Debit)
            .ToList();

        decimal totalCreditedAmount = credits.Sum(entry => entry.Amount);
        decimal totalDebitedAmount = debits.Sum(entry => entry.Amount);

        return new LedgerDashboardResponseDto
        {
            TotalWallets = wallets.Count,
            ActiveWallets = wallets.Count(wallet => wallet.IsActive),
            InactiveWallets = wallets.Count(wallet => !wallet.IsActive),
            TotalLedgerEntries = entries.Count,
            TotalCredits = credits.Count,
            TotalDebits = debits.Count,
            TotalCreditedAmount = totalCreditedAmount,
            TotalDebitedAmount = totalDebitedAmount,
            NetBalance = totalCreditedAmount - totalDebitedAmount,
            Currency = "MXN",
            GeneratedAtUtc = DateTime.UtcNow
        };
    }
}
