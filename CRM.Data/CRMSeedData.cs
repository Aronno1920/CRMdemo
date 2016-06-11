using CRM.Data.Authentication;
using CRM.Entity.Authentication;
using CRM.Entity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CRM.Data
{
    public class CRMSeedData : DropCreateDatabaseIfModelChanges<CRMEntities>
    {
        protected override void Seed(CRMEntities context)
        {
           
            
            #region CHANNEL TYPE
            AddChannelType(context);
            context.SaveChanges();
            #endregion
            #region CITY Types
            AddCityType(context);
            context.SaveChanges();
            #endregion
            #region CITY
            AddCity(context);
            context.SaveChanges();
            #endregion
            #region CONTACT TYPE
            AddContactType(context);
            context.SaveChanges();
            #endregion
            #region COUNTRY
            AddCountry(context);
            context.SaveChanges();
            #endregion
            #region CURRENT OUTCOME CODE
            AddCurrentOutcomeCode(context);
            context.SaveChanges();
            #endregion
            #region FLIGHT ROUTE CATEGORY
            AddFlightRouteCategory(context);
            context.SaveChanges();
            #endregion
            #region FLIGHT ROUTE
            AddFlightRoute(context);
            context.SaveChanges();
            #endregion
            #region PRIORITY
            AddPriority(context);
            context.SaveChanges();
            #endregion
            #region PRODUCT CATEGORY
            AddProductCategory(context);
            context.SaveChanges();
            #endregion
            #region PRODUCT TYPE
            AddProductType(context);
            context.SaveChanges();
            #endregion
            #region SERVICE TYPE
            AddServiceType(context);
            context.SaveChanges();
            #endregion
            #region SERVICE TYPE DETAIL
            AddServiceTypeDetail(context);
            context.SaveChanges();
            #endregion
            #region SERVICE ADDITIONAL DETAIL
            AddServiceAdditionalDetail(context);
            context.SaveChanges();
            #endregion
            #region SERVICE SUPPLEMENT DETAIL
            AddServiceSupplementDetail(context);
            context.SaveChanges();
            #endregion
            #region SERVICE CENTER
            AddServiceCenter(context);
            context.SaveChanges();
            #endregion
            #region SERVICE STATUS
            AddServiceStatus(context);
            context.SaveChanges();
            #endregion
            #region STATION CATEGORY
            AddServiceCategory(context);
            context.SaveChanges();
            #endregion
            #region STATION
            AddStation(context);
            context.SaveChanges();
            #endregion
            #region TITLE
            AddTitle(context);
            context.SaveChanges();
            #endregion
            #region LANGUAGE
            AddLanguage(context);
            context.SaveChanges();
            #endregion
            #region CUSTOMER
            AddCustomer(context);
            context.SaveChanges();
            #endregion
            #region PRODUCT
            AddProduct(context);
            context.SaveChanges();
            #endregion
            #region SERVICE
            AddService(context);
            context.SaveChanges();
            #endregion
            #region INTERACTION
            AddInteraction(context);
            #endregion
           
            context.SaveChanges();

            #region
           // AddUserAuthentication(context);
            #endregion
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void AddUserAuthentication(CRMEntities context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string FirstName = "admin";
            const string LastName = "System";
            const int UserStatusID = 1;
            const string password = "Admin@123456";
            const string roleName = "Admin";
            var aRole = new ApplicationRole(roleName);
            context.Roles.Add(aRole);
            context.SaveChanges();

            var user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true, FirstName = FirstName, LastName = LastName, UserStatusID = UserStatusID };
            var result = userManager.Create(user, password);
            result = userManager.SetLockoutEnabled(user.Id, false);

            var groupManager = new ApplicationGroupManager();
            var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { aRole.Name });


        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(CRMEntities db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string FirstName = "admin";
            const string LastName = "System";
            const int UserStatusID = 1;
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true,FirstName=FirstName,LastName=LastName,UserStatusID=UserStatusID };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);

            }

            var groupManager = new ApplicationGroupManager();
            var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
        }
        private static void AddInteraction(CRMEntities context)
        {
            var interactions = new List<InteractionEntity>
            {
            new InteractionEntity{Comments = "Test Comments 1",Code="45645", ChannelTypeID=1,CurrentOutcomeCodeID=1,ServiceID=1},
            new InteractionEntity{Comments = "Test Comments 2",Code="4576587645",ChannelTypeID=1,CurrentOutcomeCodeID=2,ServiceID=1},
            new InteractionEntity{Comments = "Test Comments 3",Code="3673",ChannelTypeID=2,CurrentOutcomeCodeID=3,ServiceID=2},
            new InteractionEntity{Comments = "Test Comments 4",Code="0678568",ChannelTypeID=2,CurrentOutcomeCodeID=4,ServiceID=2},
            new InteractionEntity{Comments = "Test Comments 5",Code="0678568",ChannelTypeID=3,CurrentOutcomeCodeID=5,ServiceID=3},
            new InteractionEntity{Comments = "Test Comments 6",Code="0678568",ChannelTypeID=3,CurrentOutcomeCodeID=6,ServiceID=3},
            new InteractionEntity{Comments = "Test Comments 7",Code="0678568",ChannelTypeID=4,CurrentOutcomeCodeID=7,ServiceID=4},
            new InteractionEntity{Comments = "Test Comments 8",Code="0678568",ChannelTypeID=5,CurrentOutcomeCodeID=8,ServiceID=4},
            new InteractionEntity{Comments = "Test Comments 9",Code="0678568",ChannelTypeID=6,CurrentOutcomeCodeID=9,ServiceID=1},
            new InteractionEntity{Comments = "Test Comments 10",Code="0678568",ChannelTypeID=7,CurrentOutcomeCodeID=1,ServiceID=1},
            };
            interactions.ForEach(s => context.Interactions.Add(s));
        }

        private static void AddService(CRMEntities context)
        {
            var services = new List<ServiceEntity>
            {
            new ServiceEntity{PNR = "Test PNR 1",Code="263465",CityID=1,CountryID=1,CustomerID=1,FlightRouteID=1,OnsiteAppointmentDate=DateTime.Now,PriorityID=1,ServiceAdditionalDetailID=1,ServiceCenterID=1,ServiceStatusID=1,ServiceSupplementalDetailID=1,ServiceTypeDetailID=1,ServiceTypeID=1,StationID=1},
            new ServiceEntity{PNR = "Test PNR 2",Code="2356",CityID=2,CountryID=2,CustomerID=2,FlightRouteID=2,OnsiteAppointmentDate=DateTime.Now,PriorityID=2,ServiceAdditionalDetailID=2,ServiceCenterID=3,ServiceStatusID=2,ServiceSupplementalDetailID=3,ServiceTypeDetailID=2,ServiceTypeID=2,StationID=3},
            new ServiceEntity{PNR = "Test PNR 3",Code="563456",CityID=3,CountryID=3,CustomerID=3,FlightRouteID=4,OnsiteAppointmentDate=DateTime.Now,PriorityID=3,ServiceAdditionalDetailID=3,ServiceCenterID=2,ServiceStatusID=3,ServiceSupplementalDetailID=4,ServiceTypeDetailID=3,ServiceTypeID=3,StationID=1},
            new ServiceEntity{PNR = "Test PNR 4",Code="2346",CityID=4,CountryID=4,CustomerID=4,FlightRouteID=3,OnsiteAppointmentDate=DateTime.Now,PriorityID=4,ServiceAdditionalDetailID=3,ServiceCenterID=1,ServiceStatusID=1,ServiceSupplementalDetailID=1,ServiceTypeDetailID=1,ServiceTypeID=1,StationID=2},
            };
            services.ForEach(s => context.Services.Add(s));
        }

        private static void AddProduct(CRMEntities context)
        {
            var products = new List<ProductEntity>
            {
            new ProductEntity{SerialNumber = "1234567890",WarrantyCode ="1",CustomerID=1,ShippingCountryID=1,WarrantyDescription="Desc A",PoPDate=DateTime.Now,ShippingDate=DateTime.Now,WarrantyExiredDate=DateTime.Now,WarrantyStartDate=DateTime.Now,CategoryID=1,TypeID=1},
            new ProductEntity{SerialNumber = "0987654321",WarrantyCode ="2",CustomerID=2,ShippingCountryID=2,WarrantyDescription="Desc B",PoPDate=DateTime.Now,ShippingDate=DateTime.Now,WarrantyExiredDate=DateTime.Now,WarrantyStartDate=DateTime.Now,CategoryID=2,TypeID=2},
            new ProductEntity{SerialNumber = "4563476548",WarrantyCode ="3",CustomerID=3,ShippingCountryID=3,WarrantyDescription="Desc C",PoPDate=DateTime.Now,ShippingDate=DateTime.Now,WarrantyExiredDate=DateTime.Now,WarrantyStartDate=DateTime.Now,CategoryID=3,TypeID=3},
            new ProductEntity{SerialNumber = "056743834658",WarrantyCode ="4",CustomerID=4,ShippingCountryID=4,WarrantyDescription="Desc D",PoPDate=DateTime.Now,ShippingDate=DateTime.Now,WarrantyExiredDate=DateTime.Now,WarrantyStartDate=DateTime.Now,CategoryID=3,TypeID=4},
            };
            products.ForEach(s => context.Products.Add(s));
        }

        private static void AddCustomer(CRMEntities context)
        {
            var customers = new List<CustomerEntity>
            {
            new CustomerEntity{FullName = "Test Name 1",Code ="1",ContactTypeID=1,CountryID=1,DealerName="Dealer A",Email="testA@example.com",OtherEmail="other_testA@example.com",FrequentFlyierCode="1",LanguageID=1,MobileNumber="+60123456789",Phone="+60987654321",ProjectName="Test Project Name A",TitleID=1},
            new CustomerEntity{FullName = "Test Name 2",Code ="2",ContactTypeID=2,CountryID=2,DealerName="Dealer B",Email="testB@example.com",OtherEmail="other_testB@example.com",FrequentFlyierCode="2",LanguageID=2,MobileNumber="+60123456789",Phone="+60987654321",ProjectName="Test Project Name B",TitleID=1},
            new CustomerEntity{FullName = "Test Name 3",Code ="3",ContactTypeID=3,CountryID=3,DealerName="Dealer C",Email="testC@example.com",OtherEmail="other_testC@example.com",FrequentFlyierCode="3",LanguageID=3,MobileNumber="+60123456789",Phone="+60987654321",ProjectName="Test Project Name C",TitleID=1},
            new CustomerEntity{FullName = "Test Name 4",Code ="4",ContactTypeID=4,CountryID=4,DealerName="Dealer D",Email="testD@example.com",OtherEmail="other_testD@example.com",FrequentFlyierCode="4",LanguageID=4,MobileNumber="+60123456789",Phone="+60987654321",ProjectName="Test Project Name D",TitleID=1},
            };
            customers.ForEach(s => context.Customers.Add(s));
        }

        private static void AddLanguage(CRMEntities context)
        {
            var languages = new List<LanguageEntity>
            {
            new LanguageEntity{Name="English",Code="EN"},
            new LanguageEntity{Name="Bahasa Malaysia",Code="BM"},
            new LanguageEntity{Name="Mandarin",Code="MD"},
            new LanguageEntity{Name="Bengali",Code="BN"},
            new LanguageEntity{Name="Hindi",Code="HN"},
            new LanguageEntity{Name="Urdu",Code="UR"},
            new LanguageEntity{Name="French",Code="FR"},
            };

            languages.ForEach(s => context.Languages.Add(s));
        }

        private static void AddTitle(CRMEntities context)
        {
            var titles = new List<TitleEntity>
            {
            new TitleEntity{Name="Corporate"},
            new TitleEntity{Name="Education"},
            new TitleEntity{Name="Dealer"},
            new TitleEntity{Name="Consumer"},
            new TitleEntity{Name="Government"},
            new TitleEntity{Name="General"},
            new TitleEntity{Name="Internal"},
            };

            titles.ForEach(s => context.Titles.Add(s));
        }

        private static void AddStation(CRMEntities context)
        {
            var station = new List<StationEntity>
            {
            new StationEntity{Name="Station Name A",StationCategoryID=1,Utc="Spain"},
            new StationEntity{Name="Station Name B",StationCategoryID=3,Utc="Italy"},
            new StationEntity{Name="Station Name C",StationCategoryID=1,Utc="Germany"},
            new StationEntity{Name="Station Name D",StationCategoryID=5,Utc="Norway"},
            new StationEntity{Name="Station Name E",StationCategoryID=3,Utc="Finland"},
            new StationEntity{Name="Station Name F",StationCategoryID=5,Utc="Denmark"},
            new StationEntity{Name="Station Name G",StationCategoryID=3,Utc="Nederland"},
            new StationEntity{Name="Station Name H",StationCategoryID=7,Utc="Sweden"},
            new StationEntity{Name="Station Name I",StationCategoryID=4,Utc="Belgium"},
            };

            station.ForEach(s => context.Stations.Add(s));
        }

        private static void AddServiceCategory(CRMEntities context)
        {
            var stationCategories = new List<StationCategoryEntity>
            {
            new StationCategoryEntity{Name="Station Category A"},
            new StationCategoryEntity{Name="Station Category B"},
            new StationCategoryEntity{Name="Station Category C"},
            new StationCategoryEntity{Name="Station Category D"},
            new StationCategoryEntity{Name="Station Category E"},
            new StationCategoryEntity{Name="Station Category F"},
            new StationCategoryEntity{Name="Station Category G"},
            new StationCategoryEntity{Name="Station Category H"},
            new StationCategoryEntity{Name="Station Category I"},
            };
            stationCategories.ForEach(s => context.StationCategorys.Add(s));
        }

        private static void AddServiceStatus(CRMEntities context)
        {
            var serviceStatuses = new List<ServiceStatusEntity>
            {
            new ServiceStatusEntity{Name="Cancelled"},
            new ServiceStatusEntity{Name="Client Escalation"},
            new ServiceStatusEntity{Name="Closed"},
            new ServiceStatusEntity{Name="Completed"},
            new ServiceStatusEntity{Name="Customer Action"},
            new ServiceStatusEntity{Name="Escalated To Level 1"},
            new ServiceStatusEntity{Name="Escalated To Level 2"},
            new ServiceStatusEntity{Name="Solution Provided"},
            new ServiceStatusEntity{Name="Pending Internally"},
            };
            serviceStatuses.ForEach(s => context.ServiceStatuses.Add(s));
        }

        private static void AddServiceCenter(CRMEntities context)
        {
            var serviceCenters = new List<ServiceCenterEntity>
            {
            new ServiceCenterEntity{Name="Service Center A",CountryID=1},
            new ServiceCenterEntity{Name="Service Center B",CountryID=2},
            new ServiceCenterEntity{Name="Service Center C",CountryID=1},
            new ServiceCenterEntity{Name="Service Center D",CountryID=2},
            new ServiceCenterEntity{Name="Service Center E",CountryID=3},
            new ServiceCenterEntity{Name="Service Center F",CountryID=2},
            new ServiceCenterEntity{Name="Service Center G",CountryID=3},
            };
            serviceCenters.ForEach(s => context.ServiceCenters.Add(s));
        }

        private static void AddServiceSupplementDetail(CRMEntities context)
        {
            var serviceSupplementalDetails = new List<ServiceSupplementalDetailEntity>
            {
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail A",ServiceAdditionalDetailID=1},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail B",ServiceAdditionalDetailID=2},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail C",ServiceAdditionalDetailID=1},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail D",ServiceAdditionalDetailID=2},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail E",ServiceAdditionalDetailID=3},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail F",ServiceAdditionalDetailID=6},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail G",ServiceAdditionalDetailID=3},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail H",ServiceAdditionalDetailID=4},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail I",ServiceAdditionalDetailID=4},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail J",ServiceAdditionalDetailID=5},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail K",ServiceAdditionalDetailID=5},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail L",ServiceAdditionalDetailID=6},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail M",ServiceAdditionalDetailID=7},
            new ServiceSupplementalDetailEntity{Name="Service Supplemental Detail N",ServiceAdditionalDetailID=7},
            };
            serviceSupplementalDetails.ForEach(s => context.ServiceSupplementalDetails.Add(s));
        }

        private static void AddServiceAdditionalDetail(CRMEntities context)
        {
            var serviceAdditionalDetails = new List<ServiceAdditionalDetailEntity>
            {
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail A",ServiceTypeDetailID=1},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail B",ServiceTypeDetailID=2},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail C",ServiceTypeDetailID=1},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail D",ServiceTypeDetailID=2},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail E",ServiceTypeDetailID=3},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail F",ServiceTypeDetailID=6},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail G",ServiceTypeDetailID=3},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail H",ServiceTypeDetailID=4},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail I",ServiceTypeDetailID=4},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail J",ServiceTypeDetailID=5},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail K",ServiceTypeDetailID=5},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail L",ServiceTypeDetailID=6},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail M",ServiceTypeDetailID=7},
            new ServiceAdditionalDetailEntity{Name="Service Additional Detail N",ServiceTypeDetailID=7},
            };
            serviceAdditionalDetails.ForEach(s => context.ServiceAdditionalDetails.Add(s));
        }

        private static void AddServiceTypeDetail(CRMEntities context)
        {
            var serviceTypeDetails = new List<ServiceTypeDetailEntity>
            {
            new ServiceTypeDetailEntity{Name="Service Type Detail A",ServiceTypeID=1},
            new ServiceTypeDetailEntity{Name="Service Type Detail B",ServiceTypeID=2},
            new ServiceTypeDetailEntity{Name="Service Type Detail C",ServiceTypeID=1},
            new ServiceTypeDetailEntity{Name="Service Type Detail D",ServiceTypeID=2},
            new ServiceTypeDetailEntity{Name="Service Type Detail E",ServiceTypeID=3},
            new ServiceTypeDetailEntity{Name="Service Type Detail F",ServiceTypeID=2},
            new ServiceTypeDetailEntity{Name="Service Type Detail G",ServiceTypeID=3},
            };
            serviceTypeDetails.ForEach(s => context.ServiceTypeDetails.Add(s));
        }

        private static void AddServiceType(CRMEntities context)
        {
            var serviceTypes = new List<ServiceTypeEntity>
            {
            new ServiceTypeEntity{Name="Product Information"},
            new ServiceTypeEntity{Name="Complaint"},
            new ServiceTypeEntity{Name="Miscellaneous Interaction"},
            };
            serviceTypes.ForEach(s => context.ServiceTypes.Add(s));
        }

        private static void AddProductType(CRMEntities context)
        {
            var productTypes = new List<ProductTypeEntity>
            {
            new ProductTypeEntity{Name="Product Type A"},
            new ProductTypeEntity{Name="Product Type B"},
            new ProductTypeEntity{Name="Product Type C"},
            new ProductTypeEntity{Name="Product Type D"},
            new ProductTypeEntity{Name="Product Type E"},
            new ProductTypeEntity{Name="Product Type F"},
            new ProductTypeEntity{Name="Product Type G"},
            };
            productTypes.ForEach(s => context.ProductTypes.Add(s));
        }

        private static void AddProductCategory(CRMEntities context)
        {
            var productCategories = new List<ProductCategoryEntity>
            {
            new ProductCategoryEntity{Name="City"},
            new ProductCategoryEntity{Name="Flight & Route"},
            new ProductCategoryEntity{Name="Station"},
            };
            productCategories.ForEach(s => context.ProductCategorys.Add(s));
        }

        private static void AddPriority(CRMEntities context)
        {
            var priorities = new List<PriorityEntity>
            {
            new PriorityEntity{Name="Immediate"},
            new PriorityEntity{Name="High"},
            new PriorityEntity{Name="Medium"},
            new PriorityEntity{Name="Low"},
            };

            priorities.ForEach(s => context.Prioritys.Add(s));
        }

        private static void AddFlightRoute(CRMEntities context)
        {
            var flightRoute = new List<FlightRouteEntity>
            {
            new FlightRouteEntity{Origin="FR Origin A",FlightRouteCategoryID=1,Destination="Spain"},
            new FlightRouteEntity{Origin="FR Origin B",FlightRouteCategoryID=3,Destination="Italy"},
            new FlightRouteEntity{Origin="FR Origin C",FlightRouteCategoryID=1,Destination="Germany"},
            new FlightRouteEntity{Origin="FR Origin D",FlightRouteCategoryID=5,Destination="Norway"},
            new FlightRouteEntity{Origin="FR Origin E",FlightRouteCategoryID=3,Destination="Finland"},
            new FlightRouteEntity{Origin="FR Origin F",FlightRouteCategoryID=5,Destination="Denmark"},
            new FlightRouteEntity{Origin="FR Origin G",FlightRouteCategoryID=3,Destination="Nederland"},
            new FlightRouteEntity{Origin="FR Origin H",FlightRouteCategoryID=7,Destination="Sweden"},
            new FlightRouteEntity{Origin="FR Origin I",FlightRouteCategoryID=4,Destination="Belgium"},
            };

            flightRoute.ForEach(s => context.FlightRoutes.Add(s));
        }

        private static void AddFlightRouteCategory(CRMEntities context)
        {
            var flightRouteCategory = new List<FlightRouteCategoryEntity>
            {
            new FlightRouteCategoryEntity{Name="FR Category A"},
            new FlightRouteCategoryEntity{Name="FR Category B"},
            new FlightRouteCategoryEntity{Name="FR Category C"},
            new FlightRouteCategoryEntity{Name="FR Category D"},
            new FlightRouteCategoryEntity{Name="FR Category E"},
            new FlightRouteCategoryEntity{Name="FR Category F"},
            new FlightRouteCategoryEntity{Name="FR Category G"},
            new FlightRouteCategoryEntity{Name="FR Category H"},
            new FlightRouteCategoryEntity{Name="FR Category I"},
            };

            flightRouteCategory.ForEach(s => context.FlightRouteCategorys.Add(s));
        }

        private static void AddCurrentOutcomeCode(CRMEntities context)
        {
            var currentOutcomeCode = new List<CurrentOutcomeCodeEntity>
            {
            new CurrentOutcomeCodeEntity{Name="Under Investigation"},
            new CurrentOutcomeCodeEntity{Name="Contact Back Scheduled"},
            new CurrentOutcomeCodeEntity{Name="Solved By 1st Level"},
            new CurrentOutcomeCodeEntity{Name="Solved By 2nd Level"},
            new CurrentOutcomeCodeEntity{Name="Awaiting Approval"},
            new CurrentOutcomeCodeEntity{Name="Solution Declined"},
            new CurrentOutcomeCodeEntity{Name="Solved"},
            new CurrentOutcomeCodeEntity{Name="Feedback"},
            new CurrentOutcomeCodeEntity{Name="Wrong Number"},
            };
            currentOutcomeCode.ForEach(s => context.CurrentOutcomeCode.Add(s));
        }

        private static void AddCountry(CRMEntities context)
        {
            var countrys = new List<CountryEntity>
            {
            new CountryEntity{Name="England",Code="EN"},
            new CountryEntity{Name="Malaysia",Code="MY"},
            new CountryEntity{Name="China",Code="CH"},
            new CountryEntity{Name="Bangladesh",Code="BD"},
            new CountryEntity{Name="India",Code="IN"},
            new CountryEntity{Name="Pakistan",Code="PK"},
            new CountryEntity{Name="France",Code="FR"},
            };
            countrys.ForEach(s => context.Countrys.Add(s));
        }

        private static void AddContactType(CRMEntities context)
        {
            var contactTypes = new List<ContactTypeEntity>
            {
            new ContactTypeEntity{Name="Corporate"},
            new ContactTypeEntity{Name="Education"},
            new ContactTypeEntity{Name="Dealer"},
            new ContactTypeEntity{Name="Consumer"},
            new ContactTypeEntity{Name="Government"},
            new ContactTypeEntity{Name="General"},
            new ContactTypeEntity{Name="Internal"},
            };
            contactTypes.ForEach(s => context.ContactTypes.Add(s));
        }

        private static void AddCity(CRMEntities context)
        {
            var citys = new List<CityEntity>
            {
            new CityEntity{Name="Kuala Lumpur",CityTypeID=1},
            new CityEntity{Name="Toronto",CityTypeID=2},
            new CityEntity{Name="British Columbia",CityTypeID=1},
            new CityEntity{Name="Sydney",CityTypeID=2},
            new CityEntity{Name="London",CityTypeID=3},
            new CityEntity{Name="Paris",CityTypeID=4},
            new CityEntity{Name="Bercelona",CityTypeID=3},
            };

            citys.ForEach(s => context.Citys.Add(s));
        }

        private static void AddCityType(CRMEntities context)
        {
            var cityTypess = new List<CityTypeEntity>
            {
            new CityTypeEntity{Name="City Type A"},
            new CityTypeEntity{Name="City Type B"},
            new CityTypeEntity{Name="City Type C"},
            new CityTypeEntity{Name="City Type D"},
            new CityTypeEntity{Name="City Type E"},
            new CityTypeEntity{Name="City Type F"},
            new CityTypeEntity{Name="City Type G"},
            };

            cityTypess.ForEach(s => context.CityTypes.Add(s));
        }

        private static void AddChannelType(CRMEntities context)
        {
            var channelTypes = new List<ChannelTypeEntity>
            {
            new ChannelTypeEntity{Name="Inbound"},
            new ChannelTypeEntity{Name="Outbound"},
            new ChannelTypeEntity{Name="Chat"},
            new ChannelTypeEntity{Name="Fax"},
            new ChannelTypeEntity{Name="Voice Mail Follow-up"},
            new ChannelTypeEntity{Name="Internal"},
            new ChannelTypeEntity{Name="Email"},
            };

            channelTypes.ForEach(s => context.ChannelTypes.Add(s));
        }
    }
}
