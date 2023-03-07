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
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(CreateAccountRequestMessage request)
        {
            var r = await _access.CreateAccount(new CreateAccountRequest
            {
                UserName = request.UserName,
                StartingFunds = request.StartingFunds,
            });

            if (!r.TransactionSucceeded)
            {
                return BadRequest(r.Message);
            }

            return Created(nameof(r), r);
        }

        [HttpPut]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(DeleteAccountRequestMessage request)
        {
            var r = await _access.DeleteAccount(new DeleteAccountRequest
            {
                AccountId = request.AccountId
            });

            return Ok(r);
        }

        [HttpPost]
        [Route("Deposit")]
        public async Task<IActionResult> Deposit(DepositRequestMessage request)
        {
            var r = await _access.DepositToAccount(new DepositRequest
            {
                AccountId = request.AccountId,
                DepositAmount = request.DepositAmount
            });

            if (!r.TransactionSucceeded)
            {
                return BadRequest(r.Message);
            }

            return Ok(r);
        }

        [HttpPost]
        [Route("Withdraw")]
        public async Task<IActionResult> Withdraw(WithdrawRequestMessage request)
        {
            var r = await _access.WithdrawFromAccount(new WithdrawRequest
            {
                AccountId = request.AccountId,
                WithdrawAmount = request.WithdrawAmount
            });

            if (!r.TransactionSucceeded)
            {
                return BadRequest(r.Message);
            }

            return Ok(r);
        }

        [HttpGet]
        [Route("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts(string? userId,string userName)
        {
            var r = await _access.GetAllAccountsForUser(new GetUserAccountsRequest
            {
                UserId = userId,
                UserName = userName
            });

            return Ok(r);
        }
    }
}
