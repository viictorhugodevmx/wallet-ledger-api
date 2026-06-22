namespace WalletLedgerApi.Dtos;

public class LedgerDashboardResponseDto
{
    public int TotalWallets { get; set; }
    public int ActiveWallets { get; set; }
    public int InactiveWallets { get; set; }

    public int TotalLedgerEntries { get; set; }
    public int TotalCredits { get; set; }
    public int TotalDebits { get; set; }

    public decimal TotalCreditedAmount { get; set; }
    public decimal TotalDebitedAmount { get; set; }
    public decimal NetBalance { get; set; }

    public string Currency { get; set; } = "MXN";
    public DateTime GeneratedAtUtc { get; set; }
}
