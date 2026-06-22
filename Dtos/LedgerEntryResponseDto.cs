using WalletLedgerApi.Enums;

namespace WalletLedgerApi.Dtos;

public class LedgerEntryResponseDto
{
    public Guid Id { get; set; }
    public string WalletNumber { get; set; } = string.Empty;
    public LedgerEntryType Type { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "MXN";
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
}
