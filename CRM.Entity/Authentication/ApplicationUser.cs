using CRM.Entity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.Authentication
{
    public class ApplicationUser
       : IdentityUser<string, ApplicationUserLogin,
       ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            // Add any custom User properties/code here
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int UserStatusID { get; set; }
        [DefaultValue("false")]
        public bool IsApproced { get; set; }

        #region Foriegn Key Values
        public virtual ICollection<ChannelTypeEntity> ChannelTypeCreatedBy { get; set; }
        public virtual ICollection<ChannelTypeEntity> ChannelTypeUpdatedBy { get; set; }

        public virtual ICollection<CityEntity> CityCreatedBy { get; set; }
        public virtual ICollection<CityEntity> CityUpdatedBy { get; set; }

        public virtual ICollection<CityTypeEntity> CityTypesCreatedBy { get; set; }
        public virtual ICollection<CityTypeEntity> CityTypesUpdatedBy { get; set; }

        public virtual ICollection<ContactTypeEntity> ContactTypeCreatedBy { get; set; }
        public virtual ICollection<ContactTypeEntity> ContactTypeUpdatedBy { get; set; }
        

        public virtual ICollection<CountryEntity> CountryCreatedBy { get; set; }
        public virtual ICollection<CountryEntity> CountryUpdatedBy { get; set; }

        public virtual ICollection<CurrentOutcomeCodeEntity> CurrentOutcomeCodeCreatedBy { get; set; }
        public virtual ICollection<CurrentOutcomeCodeEntity> CurrentOutcomeCodeUpdatedBy { get; set; }

        public virtual ICollection<CustomerEntity> CustomerCreatedBy { get; set; }
        public virtual ICollection<CustomerEntity> CustomerUpdatedBy { get; set; }

        public virtual ICollection<FlightRouteCategoryEntity> FlightRouteCategoryCreatedBy { get; set; }
        public virtual ICollection<FlightRouteCategoryEntity> FlightRouteCategoryUpdatedBy { get; set; }

        public virtual ICollection<FlightRouteEntity> FlightRouteCreatedBy { get; set; }
        public virtual ICollection<FlightRouteEntity> FlightRouteUpdatedBy { get; set; }

        public virtual ICollection<InteractionEntity> InteractionCreatedBy { get; set; }
        public virtual ICollection<InteractionEntity> InteractionUpdatedBy { get; set; }

        public virtual ICollection<LanguageEntity> LanguageCreatedBy { get; set; }
        public virtual ICollection<LanguageEntity> LanguageUpdatedBy { get; set; }

        public virtual ICollection<PriorityEntity> PriorityCreatedBy { get; set; }
        public virtual ICollection<PriorityEntity> PriorityUpdatedBy { get; set; }

        public virtual ICollection<ProductCategoryEntity> ProductCategoryCreatedBy { get; set; }
        public virtual ICollection<ProductCategoryEntity> ProductCategoryUpdatedBy { get; set; }

        public virtual ICollection<ProductEntity> ProductCreatedBy { get; set; }
        public virtual ICollection<ProductEntity> ProductUpdatedBy { get; set; }

        public virtual ICollection<ProductTypeEntity> ProductTypeCreatedBy { get; set; }
        public virtual ICollection<ProductTypeEntity> ProductTypeUpdatedBy { get; set; }

        public virtual ICollection<ServiceAdditionalDetailEntity> ServiceAdditionalDetailCreatedBy { get; set; }
        public virtual ICollection<ServiceAdditionalDetailEntity> ServiceAdditionalDetailUpdatedBy { get; set; }

        public virtual ICollection<ServiceCenterEntity> ServiceCenterCreatedBy { get; set; }
        public virtual ICollection<ServiceCenterEntity> ServiceCenterUpdatedBy { get; set; }

        public virtual ICollection<ServiceEntity> ServiceCreatedBy { get; set; }
        public virtual ICollection<ServiceEntity> ServiceUpdatedBy { get; set; }

        public virtual ICollection<ServiceStatusEntity> ServiceStatusCreatedBy { get; set; }
        public virtual ICollection<ServiceStatusEntity> ServiceStatusUpdatedBy { get; set; }

        public virtual ICollection<ServiceSupplementalDetailEntity> ServiceSupplementalDetailCreatedBy { get; set; }
        public virtual ICollection<ServiceSupplementalDetailEntity> ServiceSupplementalDetailUpdatedBy { get; set; }

        public virtual ICollection<ServiceTypeDetailEntity> ServiceTypeDetailCreatedBy { get; set; }
        public virtual ICollection<ServiceTypeDetailEntity> ServiceTypeDetailUpdatedBy { get; set; }

        public virtual ICollection<ServiceTypeEntity> ServiceTypeCreatedBy { get; set; }
        public virtual ICollection<ServiceTypeEntity> ServiceTypeUpdatedBy { get; set; }

        public virtual ICollection<StationCategoryEntity> StationCategoryCreatedBy { get; set; }
        public virtual ICollection<StationCategoryEntity> StationCategoryUpdatedBy { get; set; }

        public virtual ICollection<StationEntity> StationCreatedBy { get; set; }
        public virtual ICollection<StationEntity> StationUpdatedBy { get; set; }

        public virtual ICollection<TitleEntity> TitleCreatedBy { get; set; }
        public virtual ICollection<TitleEntity> TitleUpdatedBy { get; set; }

        #endregion



        //public async Task<ClaimsIdentity>
        //    GenerateUserIdentityAsync(ApplicationUserManager manager)
        //{
        //    var userIdentity = await manager
        //        .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}
    }

}
