namespace WalletLedgerApi.Dtos;

public class WalletBalanceResponseDto
{
    public string WalletNumber { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Currency { get; set; } = "MXN";
    public decimal TotalCredits { get; set; }
    public decimal TotalDebits { get; set; }
    public decimal Balance { get; set; }
    public DateTime CalculatedAtUtc { get; set; }
}
