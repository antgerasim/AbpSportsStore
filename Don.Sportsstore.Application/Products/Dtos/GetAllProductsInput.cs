using System;
using Abp.Application.Services.Dto;

namespace Don.Sportsstore.Products.Dtos
{
    public class GetAllProductsInput : IPagedResultRequest
    {
        private const int PageSize = 4;

        //todo add category as filter?
        public string Category { get; set; }

        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }

        public GetAllProductsInput()
        {
            //SkipCount = 1;
            MaxResultCount = PageSize;
        }

    }
}