using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FluentValidation;
using payme.Application.Models;
using payme.Core.DTOs.APIResponses;
using payme.Core.Utils;

namespace payme.Application.Queries
{
    public class FetchAllProductsQuery : IRequest<BaseModel<List<ProductModel>>>
    {

    }
    public class FetchAllProductsQueryHandler : IRequestHandler<FetchAllProductsQuery, BaseModel<List<ProductModel>>>
    {
        private readonly ILogger<FetchAllProductsQueryHandler> _logger;
        private readonly HttpClientHelper _clientHelper;
        private readonly IConfiguration _configuration;
        public FetchAllProductsQueryHandler(ILogger<FetchAllProductsQueryHandler> logger
        , HttpClientHelper clientHelper, IConfiguration configuration)
        {
            _clientHelper = clientHelper;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<BaseModel<List<ProductModel>>> Handle(FetchAllProductsQuery request, CancellationToken cancellationToken)
        {
            var token = _configuration.GetValue<string>("PaystackSettings:Token");
            var authHeaders = new Dictionary<string, string>();
            authHeaders.Add("Authorization", "Bearer " + token);
            
            var response = new BaseModel<List<ProductModel>>();
            var productUrl = _configuration.GetValue<string>("PaystackSettings:BaseUrl") + _configuration.GetValue<string>("PaystackSettings:ProductSlug");

            var prodRes = await _clientHelper.GetAsync<ProductsListResp>(productUrl,null,authHeaders);
            response.Status = true;
            response.Message = $"{prodRes.Data.ToList().Count} Record(s) Selected";
            response.Data = prodRes.Data.Select(c => new ProductModel
            {
                ProductName = c.Name,
                Description = c.Description,
                Price = c.Price

            }).ToList();
            return response;
        }
    }
}
