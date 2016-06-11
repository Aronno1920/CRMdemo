using AutoMapper;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ChannelTypeEntity, CRMViewModel>();
           // Mapper.CreateMap<Gadget, GadgetViewModel>();
        }
    }
}