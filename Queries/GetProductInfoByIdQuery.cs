﻿using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Queries
{
    public class GetProductInfoByIdQuery: IRequest<ResponseRecord<ProductInfo>>
    {
        public string? Id { get; set; }
    }
}
