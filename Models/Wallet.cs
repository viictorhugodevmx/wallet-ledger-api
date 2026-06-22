namespace WalletLedgerApi.Models;

public class Wallet
{
    public Guid Id { get; set; }
    public string WalletNumber { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Currency { get; set; } = "MXN";
    public bool IsActive { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
