using WalletLedgerApi.Dtos;
using WalletLedgerApi.Enums;
using WalletLedgerApi.Models;

namespace WalletLedgerApi.Services;

public class LedgerService
{
    private readonly List<LedgerEntry> _entries = new()
    {
        new LedgerEntry
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1001",
            Type = LedgerEntryType.Credit,
            Amount = 5000,
            Currency = "MXN",
            Description = "Initial wallet funding",
            CreatedAtUtc = DateTime.UtcNow.AddDays(-4)
        },
        new LedgerEntry
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1001",
            Type = LedgerEntryType.Debit,
            Amount = 750,
            Currency = "MXN",
            Description = "Card purchase",
            CreatedAtUtc = DateTime.UtcNow.AddDays(-2)
        },
        new LedgerEntry
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1002",
            Type = LedgerEntryType.Credit,
            Amount = 2500,
            Currency = "MXN",
            Description = "Transfer received",
            CreatedAtUtc = DateTime.UtcNow.AddDays(-1)
        }
    };

    public List<LedgerEntryResponseDto> GetEntriesByWalletNumber(string walletNumber)
    {
        return GetRawEntriesByWalletNumber(walletNumber)
            .OrderByDescending(entry => entry.CreatedAtUtc)
            .Select(MapToResponseDto)
            .ToList();
    }

    public List<LedgerEntry> GetRawEntriesByWalletNumber(string walletNumber)
    {
        return _entries
            .Where(entry => entry.WalletNumber.Equals(
                walletNumber.Trim(),
                StringComparison.OrdinalIgnoreCase
            ))
            .ToList();
    }

    public decimal CalculateBalance(string walletNumber)
    {
        List<LedgerEntry> entries = GetRawEntriesByWalletNumber(walletNumber);

        decimal totalCredits = entries
            .Where(entry => entry.Type == LedgerEntryType.Credit)
            .Sum(entry => entry.Amount);

        decimal totalDebits = entries
            .Where(entry => entry.Type == LedgerEntryType.Debit)
            .Sum(entry => entry.Amount);

        return totalCredits - totalDebits;
    }

    private static LedgerEntryResponseDto MapToResponseDto(LedgerEntry entry)
    {
        return new LedgerEntryResponseDto
        {
            Id = entry.Id,
            WalletNumber = entry.WalletNumber,
            Type = entry.Type,
            Amount = entry.Amount,
            Currency = entry.Currency,
            Description = entry.Description,
            CreatedAtUtc = entry.CreatedAtUtc
        };
    }
}
