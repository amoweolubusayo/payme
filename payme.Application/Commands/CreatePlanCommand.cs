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
using payme.Core.Common.Exceptions;

namespace payme.Application.Commands
{
    public class CreatePlanCommand : IRequest<TransactionResp>
    {
        public string Name { get; set; }
        public string Interval { get; set; }
        public string Email { get; set; }
        public long Amount { get; set; }
        public string SubAccount { get; set; }
    }
    public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public CreatePlanCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Interval).NotNull().NotEmpty();
            RuleFor(x => x.Amount).NotNull().NotEmpty();
        }

    }
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, TransactionResp>
    {
        private readonly ILogger<CreatePlanCommandHandler> _logger;
        private readonly HttpClientHelper _clientHelper;
        private readonly IConfiguration _configuration;
        public CreatePlanCommandHandler(

            ILogger<CreatePlanCommandHandler> logger
        , HttpClientHelper clientHelper, IConfiguration configuration)
        {
            _clientHelper = clientHelper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<TransactionResp> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var token = _configuration.GetValue<string>("PaystackSettings:Token");
            var authHeaders = new Dictionary<string, string>();
            authHeaders.Add("Authorization", "Bearer " + token);

            PlanReq req = new PlanReq();
            req.Name = request.Name;
            req.Interval = request.Interval;
            req.Amount = request.Amount;



            var planUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:PlanSlug");
            var planRes = await _clientHelper.PostAsync<PlanResp, PlanReq>(req, planUrl, null, authHeaders);
            if (!planRes.Status)
            {
                return new TransactionResp()
                {
                    Status = planRes.Status,
                    Message = planRes.Message,
                };
            }
            RecurringTransactionReq rq = new RecurringTransactionReq();
            rq.Amount = request.Amount;
            rq.Bearer = "subaccount";
            rq.Email = request.Email;
            rq.Plan = planRes.Data.PlanCode;
            rq.Subaccount = request.SubAccount;

            var transUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:TransactionSlug");
            var transRes = await _clientHelper.PostAsync<TransactionResp, RecurringTransactionReq>(rq,transUrl,null,authHeaders);
            var subscriptionUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:SubscriptionSlug");
           
            SubscriptionReq resq = new SubscriptionReq();
            resq.Customer = request.Email;
            resq.Plan = planRes.Data.PlanCode;
            var subRes = await _clientHelper.PostAsync<SubscriptionResp, SubscriptionReq>(resq,subscriptionUrl,null,authHeaders);
            return new TransactionResp()
            {
                Status = transRes.Status,
                Message = transRes.Message,
                Data = transRes.Data,
            };
        }

    }
}
