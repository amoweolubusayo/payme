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
    public class CreateProductCommand : IRequest<ProductResp>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Currency { get; set; }
        public bool Limited { get; set; }
        public long Quantity { get; set; }
    }
     public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.Currency).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
        }

    }
     public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResp>
    {
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly HttpClientHelper _clientHelper;
        private readonly IConfiguration _configuration;
        public CreateProductCommandHandler(

            ILogger<CreateProductCommandHandler> logger
        ,HttpClientHelper clientHelper,IConfiguration configuration)
        {
            _clientHelper = clientHelper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ProductResp> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var token = _configuration.GetValue<string>("PaystackSettings:Token");
            var authHeaders = new Dictionary<string, string>();
            authHeaders.Add("Authorization", "Bearer " + token);

            ProductReq req = new ProductReq();
            req.Name = request.Name;
            req.Price = request.Price;
            req.Currency = request.Currency;
            req.Limited = request.Limited;
            req.Quantity = request.Quantity;
            req.Description = request.Description;

            var productUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:ProductSlug");
            var productRes = await _clientHelper.PostAsync<ProductResp, ProductReq>(req, productUrl, null, authHeaders);
            if(!productRes.Status){
                return new ProductResp(){
                    Status = productRes.Status,
                    Message = productRes.Message,
                    Data = productRes.Data
                };
            }
            return new ProductResp(){
                Status = productRes.Status,
                    Message = productRes.Message,
                    Data = productRes.Data
            };
        }

    }

}
