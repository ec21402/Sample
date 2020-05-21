using AutoMapper;
using Sample.web.Contracts.V1.Responses;
using Sample.web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.web.Mapping
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<Brand, BrandResponse>();
        }
    }
}
