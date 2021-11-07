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
    public class CreateCustomerCommand : IRequest<CustomerResp>
    {
        public string BusinessName { get; set; }
        public string BusinessCategory { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }

    }
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.BusinessName).NotNull().NotEmpty();
            RuleFor(x => x.BusinessCategory).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Bank).NotNull().NotEmpty();
            RuleFor(x => x.AccountNumber).NotNull().NotEmpty();
        }

    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResp>
    {
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        private readonly HttpClientHelper _clientHelper;
        private readonly IConfiguration _configuration;
        public CreateCustomerCommandHandler(

            ILogger<CreateCustomerCommandHandler> logger
        ,HttpClientHelper clientHelper,IConfiguration configuration)
        {
            _clientHelper = clientHelper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<CustomerResp> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var token = _configuration.GetValue<string>("PaystackSettings:Token");
            var authHeaders = new Dictionary<string, string>();
            authHeaders.Add("Authorization", "Bearer " + token);

            CustomerReq req = new CustomerReq();
            req.Email = request.Email;
            req.FirstName = request.BusinessName;
            req.LastName = request.BusinessCategory;
            req.Phone = request.PhoneNumber;

            SubAccountReq rq = new SubAccountReq();
            rq.BusinessName = request.BusinessName;
            rq.SettlementBank = request.Bank;
            rq.AccountNumber = request.AccountNumber;
            rq.PercentageCharge = _configuration.GetValue<long>("PaystackSettings:PercentageCharge");
            rq.Description = request.BusinessName + " " + request.BusinessCategory;


            var customerUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:CustomerSlug");
            var subAcctUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:SubAccountSlug");
            var cusRes = await _clientHelper.PostAsync<CustomerResp, CustomerReq>(req, customerUrl, null, authHeaders);
            var subAcctRes = await _clientHelper.PostAsync<SubAccountResp, SubAccountReq>(rq, subAcctUrl, null, authHeaders);
            if(!cusRes.Status){
                return new CustomerResp(){
                    Status = cusRes.Status,
                    Message = cusRes.Message,
                    Data = cusRes.Data
                };
            }
            return new CustomerResp(){
                Status = cusRes.Status,
                Message = cusRes.Message,
                Data = cusRes.Data
            };
        }

    }
}
