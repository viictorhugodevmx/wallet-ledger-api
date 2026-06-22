Sexto proyecto del programa **Bankaool .NET Fintech Bridge Lab**.

API REST con ASP.NET Core Web API para practicar conceptos de ledger financiero, wallets y movimientos contables.

## Stack

- Ubuntu
- .NET 8
- C#
- ASP.NET Core Web API
- Swagger/OpenAPI
- Postman

## Conceptos practicados

- Controllers
- DTOs
- Models
- Enums
- Services
- Validators
- Helpers
- Dependency Injection
- ApiResponse<T>
- OperationResult<T>
- HTTP status codes: 200, 201, 400, 404
- Ledger financiero
- Wallet balance
- Credit / Debit
- Dashboard operativo

## Conceptos fintech

| Concepto | Significado |
|---|---|
| Wallet | Cuenta digital del cliente |
| Ledger | Libro contable de movimientos |
| Credit | Entrada de dinero |
| Debit | Salida de dinero |
| Balance | Créditos menos débitos |
| Entry | Registro individual del ledger |

## Regla de saldo

```txt
Balance = Total Credits - Total Debits
Endpoints
Health
GET /api/health
Wallets
GET /api/wallets
GET /api/wallets/{walletNumber}
Ledger
GET /api/wallets/{walletNumber}/ledger
POST /api/wallets/{walletNumber}/ledger
Balance
GET /api/wallets/{walletNumber}/balance
Dashboard
GET /api/ledger/dashboard
Crear movimiento ledger
Credit
{
  "type": 1,
  "amount": 1000,
  "description": "Wallet credit test"
}
Debit
{
  "type": 2,
  "amount": 500,
  "description": "Wallet debit test"
}
Response standard
{
  "success": true,
  "message": "Operation completed successfully.",
  "data": {}
}
Comandos

Restaurar:

dotnet restore

Build:

dotnet build

Ejecutar:

dotnet run

Modo watch:

dotnet watch run

Limpiar:

pkill -f "dotnet"
dotnet clean
rm -rf bin obj
Puerto local

Este repo está corriendo en:

http://localhost:5214
Swagger

Con la API corriendo:

http://localhost:5214/swagger
Postman

Colección:

postman/wallet-ledger-api.postman_collection.json

Variable:

baseUrl = http://localhost:5214
Arquitectura final
HTTP Request
→ Controller
→ Application Service
→ Validator
→ Domain Service
→ OperationResult<T>
→ ApiResponse<T>
→ HTTP Response
Archivos clave
Controllers/WalletsController.cs
Controllers/LedgerController.cs
Dtos/ApiResponse.cs
Dtos/CreateLedgerEntryRequestDto.cs
Dtos/LedgerDashboardResponseDto.cs
Dtos/LedgerEntryResponseDto.cs
Dtos/WalletBalanceResponseDto.cs
Dtos/WalletResponseDto.cs
Enums/LedgerEntryType.cs
Helpers/ApiResponseHelper.cs
Models/LedgerEntry.cs
Models/OperationResult.cs
Models/Wallet.cs
Services/LedgerApplicationService.cs
Services/LedgerDashboardService.cs
Services/LedgerService.cs
Services/WalletBalanceService.cs
Services/WalletService.cs
Validators/LedgerEntryValidator.cs
Cierre
wallet-ledger-api · Paso 10 listo

EOF