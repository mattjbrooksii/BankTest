using AccountsAccess.Contracts.Requests;
using BankClient.Models;
using AccountsAccess.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DepositsClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsAccess _access;

        public AccountsController(IAccountsAccess access)
        { 
            _access = access;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountRequestMessage request)
        {
            var r = await _access.CreateAccount(new CreateAccountRequest
            {
                UserName = request.UserName,
                StartingFunds = request.StartingFunds,
            });

            return Ok(r);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteAccount(DeleteAccountRequestMessage request)
        {
            var r = await _access.DeleteAccount(new DeleteAccountRequest
            {
                AccountId = request.AccountId
            });

            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositRequestMessage request)
        {
            var r = await _access.DepositToAccount(new DepositRequest
            {
                AccountId = request.AccountId,
                DepositAmount = request.DepositAmount
            });

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw(WithdrawRequestMessage request)
        {
            var r = await _access.WithdrawFromAccount(new WithdrawRequest
            {
                AccountId = request.AccountId,
                WithdrawAmount = request.WithdrawAmount
            });

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw(string userId, string userFullName)
        {
            var r = await _access.GetAllAccountsForUser(new GetUserAccountsRequest
            {
                UserId = userId,
                UserFullName = userFullName
            });

            return Ok(r);
        }
    }
}
