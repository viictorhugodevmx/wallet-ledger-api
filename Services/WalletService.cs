using WalletLedgerApi.Dtos;
using WalletLedgerApi.Models;

namespace WalletLedgerApi.Services;

public class WalletService
{
    private readonly List<Wallet> _wallets = new()
    {
        new Wallet
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1001",
            OwnerName = "Víctor Hugo Segundo Aguilar",
            Currency = "MXN",
            IsActive = true,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-5)
        },
        new Wallet
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1002",
            OwnerName = "Cliente Wallet Demo",
            Currency = "MXN",
            IsActive = true,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-3)
        },
        new Wallet
        {
            Id = Guid.NewGuid(),
            WalletNumber = "WAL-1003",
            OwnerName = "Cliente Wallet Bloqueado",
            Currency = "MXN",
            IsActive = false,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-1)
        }
    };

    public List<Wallet> GetRawWallets()
    {
        return _wallets;
    }

    public List<WalletResponseDto> GetWallets()
    {
        return _wallets.Select(MapToResponseDto).ToList();
    }

    public WalletResponseDto? GetWalletByNumber(string walletNumber)
    {
        Wallet? wallet = GetRawWalletByNumber(walletNumber);

        if (wallet is null)
        {
            return null;
        }

        return MapToResponseDto(wallet);
    }

    public Wallet? GetRawWalletByNumber(string walletNumber)
    {
        return _wallets.FirstOrDefault(wallet =>
            wallet.WalletNumber.Equals(walletNumber.Trim(), StringComparison.OrdinalIgnoreCase)
        );
    }

    private static WalletResponseDto MapToResponseDto(Wallet wallet)
    {
        return new WalletResponseDto
        {
            Id = wallet.Id,
            WalletNumber = wallet.WalletNumber,
            OwnerName = wallet.OwnerName,
            Currency = wallet.Currency,
            IsActive = wallet.IsActive,
            CreatedAtUtc = wallet.CreatedAtUtc
        };
    }
}
