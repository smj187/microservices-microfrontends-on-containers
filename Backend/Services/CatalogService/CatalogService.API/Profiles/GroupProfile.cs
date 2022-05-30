﻿using AutoMapper;
using CatalogService.Contracts.v1.Requests.Groups;
using CatalogService.Contracts.v1.Responses;
using CatalogService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.API.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<CreateGroupRequest, Group>();
            CreateMap<Group, GroupResponse>();
        }
    }
}
