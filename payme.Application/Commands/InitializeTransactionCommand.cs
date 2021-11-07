using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using FluentValidation;
using payme.Core.DTOs.APIRequests;
using payme.Core.DTOs.APIResponses;
using payme.Core.Utils;

namespace payme.Application.Commands
{
    public class InitializeTransactionCommand : IRequest<TransactionResp>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Amount { get; set; }
        public string SubAccount { get; set; }
    }
    public class InitializeTransactionCommandValidator : AbstractValidator<InitializeTransactionCommand>
    {
        public InitializeTransactionCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Amount).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.SubAccount).NotNull().NotEmpty();
        }

    }
    public class InitializeTransactionCommandHandler : IRequestHandler<InitializeTransactionCommand, TransactionResp>
    {
        private readonly ILogger<InitializeTransactionCommandHandler> _logger;
        private readonly HttpClientHelper _clientHelper;
        private readonly IConfiguration _configuration;
        public InitializeTransactionCommandHandler(

            ILogger<InitializeTransactionCommandHandler> logger
        , HttpClientHelper clientHelper, IConfiguration configuration)
        {
            _clientHelper = clientHelper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<TransactionResp> Handle(InitializeTransactionCommand request, CancellationToken cancellationToken)
        {
            var token = _configuration.GetValue<string>("PaystackSettings:Token");
            var authHeaders = new Dictionary<string, string>();
            authHeaders.Add("Authorization", "Bearer " + token);

         
            OneTimeTransactionReq rq = new OneTimeTransactionReq();
            rq.Amount = request.Amount;
            rq.Bearer = "subaccount";
            rq.Email = request.Email;
            rq.Subaccount = request.SubAccount;

            var transUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:TransactionSlug");
            var transRes = await _clientHelper.PostAsync<TransactionResp, OneTimeTransactionReq>(rq,transUrl,null,authHeaders);
           
            return new TransactionResp()
            {
                Status = transRes.Status,
                Message = transRes.Message,
                Data = transRes.Data,
            };
        }

    }
}
