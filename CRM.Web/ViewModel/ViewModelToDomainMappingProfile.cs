using AutoMapper;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CRMViewModel, ChannelTypeEntity>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.IsActive, map => map.MapFrom(vm => vm.IsActive))
                .ForMember(g => g.IsDeleted, map => map.MapFrom(vm => vm.IsDeleted))
                .ForMember(g => g.CreatedDate, map => map.MapFrom(vm => vm.CreatedDate))
                .ForMember(g => g.UpdatedDate, map => map.MapFrom(vm => vm.UpdatedDate));
        }
    }
}