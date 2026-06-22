using WalletLedgerApi.Enums;

namespace WalletLedgerApi.Dtos;

public class CreateLedgerEntryRequestDto
{
    public LedgerEntryType Type { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
}
