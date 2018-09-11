using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using System.Linq;
using WBS.DAL.Models;
using WBS.DAL.Descriptors.ConstantModelFields;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL.Descriptors
{
    public class DescriptorOfFormGenerator
    {
        private readonly IPermissionsDAL _permissionsDAL;

        public DescriptorOfFormGenerator(IPermissionsDAL permissionsDAL)
        {
            _permissionsDAL = permissionsDAL;
        }

        private bool CanEditField(string fieldName, string typeName, string assemblyName, List<string> roles)
        {

            if (String.IsNullOrEmpty(fieldName))
                throw new ArgumentException("Введен пустой параметр fieldName.");
            //return _permissionsDAL.GetPermissionsForField(fieldName, typeID, roles);
            return true;
        }

        private bool CanAccessToObject(string typeName, string assemblyName, List<string> roles)
        {
            return _permissionsDAL.GetPermissionsForType(typeName, assemblyName, roles).Any();
        }

        public Descriptor CreateDescriptor<T> (List<string> roles) where T : IBaseEntity
        {
            List<FieldInfo> fields;
            Type typeEntity = typeof(T);
            string assemblyName = typeEntity.Assembly.GetName().Name;
            string typeName = typeEntity.Name;

            if (!CanAccessToObject(typeName, assemblyName, roles))
            {
                throw new TypeAccessException();
            }

            switch (typeEntity)
            {
                case Type type when (typeof(BudgetPlan).Name == type.Name):
                    var budgetPlanNames = new BudgetPlanForm();

                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(budgetPlanNames.Year.label, budgetPlanNames.Year.name, false, 
                            CanEditField(budgetPlanNames.Year.name, typeEntity.Name, assemblyName, roles))
                    };
                    return new Descriptor(fields);
                case Type type when(typeof(CategoryGroup).Name == type.Name):
                    var categoryGroupsNames = new CategoryGroupsForm();

                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(categoryGroupsNames.Title.label, categoryGroupsNames.Title.name, false, 
                            CanEditField(categoryGroupsNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(categoryGroupsNames.Code.label, categoryGroupsNames.Code.name, false, 
                            CanEditField(categoryGroupsNames.Code.name, typeEntity.Name, assemblyName, roles))
                    };                    
                    return new Descriptor(fields);

                case Type type when (typeof(CategoryOfEquipment).Name == type.Name):
                    var categoryOfEquipmentNames = new CategoriesOfEquipmentForm();

                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(categoryOfEquipmentNames.Title.label, categoryOfEquipmentNames.Title.name, false, 
                            CanEditField(categoryOfEquipmentNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(categoryOfEquipmentNames.Code.label, categoryOfEquipmentNames.Code.name, false, 
                            CanEditField(categoryOfEquipmentNames.Code.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(categoryOfEquipmentNames.DepreciationPeriod.label, categoryOfEquipmentNames.DepreciationPeriod.name, false, 
                            CanEditField(categoryOfEquipmentNames.DepreciationPeriod.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(categoryOfEquipmentNames.CategoryGroup.name, categoryOfEquipmentNames.CategoryGroup.name, false, 
                            CanEditField(categoryOfEquipmentNames.CategoryGroup.name, typeEntity.Name, assemblyName, roles)),
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(DAIRequest).Name == type.Name):
                    var daiRequestsName = new DAIRequestForm();

                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(daiRequestsName.AdditionalSalesPerYear.name, daiRequestsName.AdditionalSalesPerYear.name, false,
                            CanEditField(daiRequestsName.AdditionalSalesPerYear.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.ApprovalOfTechExpertIsRequired.name, daiRequestsName.ApprovalOfTechExpertIsRequired.name, false,
                            CanEditField(daiRequestsName.ApprovalOfTechExpertIsRequired.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.CommentForDirectorGeneral.name, daiRequestsName.CommentForDirectorGeneral.name, false,
                            CanEditField(daiRequestsName.CommentForDirectorGeneral.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.CreationData.name, daiRequestsName.CreationData.name, false,
                            CanEditField(daiRequestsName.CreationData.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.DeliveryTime.name, daiRequestsName.DeliveryTime.name, false,
                            CanEditField(daiRequestsName.DeliveryTime.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.DirectorApprovalDate.name, daiRequestsName.DirectorApprovalDate.name, false,
                            CanEditField(daiRequestsName.DirectorApprovalDate.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.EstimatedOperationPeriod.name, daiRequestsName.EstimatedOperationPeriod.name, false,
                            CanEditField(daiRequestsName.EstimatedOperationPeriod.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.ExtraAnnualCost.name, daiRequestsName.ExtraAnnualCost.name, false,
                            CanEditField(daiRequestsName.ExtraAnnualCost.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.InternalRateOfReturn.name, daiRequestsName.InternalRateOfReturn.name, false,
                            CanEditField(daiRequestsName.InternalRateOfReturn.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.LastModifiedDate.name, daiRequestsName.LastModifiedDate.name, false,
                            CanEditField(daiRequestsName.LastModifiedDate.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.MarginOnAddedValue.name, daiRequestsName.MarginOnAddedValue.name, false,
                            CanEditField(daiRequestsName.MarginOnAddedValue.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.NetMargin.name, daiRequestsName.NetMargin.name, false,
                            CanEditField(daiRequestsName.NetMargin.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.NetPresentValue.name, daiRequestsName.NetPresentValue.name, false,
                            CanEditField(daiRequestsName.NetPresentValue.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.Number.name, daiRequestsName.Number.name, false,
                            CanEditField(daiRequestsName.Number.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.PeriodOfPayback.name, daiRequestsName.PeriodOfPayback.name, false,
                            CanEditField(daiRequestsName.PeriodOfPayback.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.RationaleForInvestment.name, daiRequestsName.RationaleForInvestment.name, false,
                            CanEditField(daiRequestsName.RationaleForInvestment.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.ReasonForDAI.name, daiRequestsName.ReasonForDAI.name, false,
                            CanEditField(daiRequestsName.ReasonForDAI.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.ResultCenter.name, daiRequestsName.ResultCenter.name, false,
                            CanEditField(daiRequestsName.ResultCenter.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.SavingsPerYear.name, daiRequestsName.SavingsPerYear.name, false,
                            CanEditField(daiRequestsName.SavingsPerYear.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.Site.name, daiRequestsName.Site.name, false,
                            CanEditField(daiRequestsName.Site.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.Subject.name, daiRequestsName.Subject.name, false,
                            CanEditField(daiRequestsName.Subject.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.TechnicalServices.name, daiRequestsName.TechnicalServices.name, false,
                            CanEditField(daiRequestsName.TechnicalServices.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(daiRequestsName.TotalInvestment.name, daiRequestsName.TotalInvestment.name, false,
                            CanEditField(daiRequestsName.TotalInvestment.name, typeEntity.Name, assemblyName, roles)),
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(Format).Name == type.Name):
                    var formatNames = new FormatForm();
                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(formatNames.Title.label, formatNames.Title.name, false, 
                            CanEditField(formatNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.Profile.label, formatNames.Profile.name, false, 
                            CanEditField(formatNames.Profile.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.TypeOfFormat.label, formatNames.TypeOfFormat.name, false, 
                            CanEditField(formatNames.TypeOfFormat.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.KYFormat.label, formatNames.KYFormat.name, false,
                            CanEditField(formatNames.KYFormat.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.DirectorOfFormat.label, formatNames.DirectorOfFormat.name, false,
                            CanEditField(formatNames.DirectorOfFormat.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.DirectorOfKYFormat.label, formatNames.DirectorOfKYFormat.name, false,
                            CanEditField(formatNames.DirectorOfKYFormat.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.E1Limit.label, formatNames.E1Limit.name, false,
                            CanEditField(formatNames.E1Limit.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.E2Limit.label, formatNames.E2Limit.name, false,
                            CanEditField(formatNames.E2Limit.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(formatNames.E3Limit.label, formatNames.E3Limit.name, false,
                            CanEditField(formatNames.E3Limit.name, typeEntity.Name, assemblyName, roles)),
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(User).Name == type.Name):
                    var profilesNames = new ProfileForm();

                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(profilesNames.FIO.label, profilesNames.FIO.name, false,
                            CanEditField(profilesNames.FIO.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.JobPosition.label, profilesNames.JobPosition.name, false,
                            CanEditField(profilesNames.JobPosition.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.Login.label, profilesNames.Login.name, false,
                            CanEditField(profilesNames.Login.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.Password.label, profilesNames.Password.name, false,
                            CanEditField(profilesNames.Password.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.Department.label, profilesNames.Department.name, false,
                            CanEditField(profilesNames.Department.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.DeletionMark.label, profilesNames.DeletionMark.name, false,
                            CanEditField(profilesNames.DeletionMark.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(profilesNames.Roles.label, profilesNames.Roles.name, false,
                            CanEditField(profilesNames.Roles.name, typeEntity.Name, assemblyName, roles)),
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(Provider).Name == type.Name):
                    var providerNames = new ProviderForm();
                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(providerNames.Title.label, providerNames.Title.name, false,
                            CanEditField(providerNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(providerNames.Profiles.label, providerNames.Profiles.name, false,
                            CanEditField(providerNames.Profiles.name, typeEntity.Name, assemblyName, roles))
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(ResultCenter).Name == type.Name):
                    var resultCentresNames = new ResultCentresForm();
                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(resultCentresNames.Title.label, resultCentresNames.Title.name, false,
                            CanEditField(resultCentresNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(resultCentresNames.Code.label, resultCentresNames.Code.name, false,
                            CanEditField(resultCentresNames.Code.name, typeEntity.Name, assemblyName, roles))
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(Site).Name == type.Name):
                    var siteNames = new SiteForm();
                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(siteNames.Title.label, siteNames.Title.name, false,
                            CanEditField(siteNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.TechnicalExpert.label, siteNames.TechnicalExpert.name, false,
                            CanEditField(siteNames.TechnicalExpert.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.OperationDirector.label, siteNames.OperationDirector.name, false,
                            CanEditField(siteNames.OperationDirector.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.KySit.label, siteNames.KySit.name, false,
                            CanEditField(siteNames.KySit.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.KyRegion.label, siteNames.KyRegion.name, false,
                            CanEditField(siteNames.KyRegion.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.Format.label, siteNames.Format.name, false,
                            CanEditField(siteNames.Format.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.DirectorOfSit.label, siteNames.DirectorOfSit.name, false,
                            CanEditField(siteNames.DirectorOfSit.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(siteNames.CreaterOfBudget.label, siteNames.CreaterOfBudget.name, false,
                            CanEditField(siteNames.CreaterOfBudget.name, typeEntity.Name, assemblyName, roles))
                    };
                    return new Descriptor(fields);
                case Type type when (typeof(TypeOfInvestment).Name == type.Name):
                    var typeOfInvestmentNames = new TypeOfInvestmentForm();
                    fields = new List<FieldInfo>
                    {
                        new FieldInfo(typeOfInvestmentNames.Title.label, typeOfInvestmentNames.Title.name, false,
                            CanEditField(typeOfInvestmentNames.Title.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(typeOfInvestmentNames.Code.label, typeOfInvestmentNames.Code.name, false,
                            CanEditField(typeOfInvestmentNames.Code.name, typeEntity.Name, assemblyName, roles)),
                        new FieldInfo(typeOfInvestmentNames.ExternalCode.label, typeOfInvestmentNames.ExternalCode.name, false,
                            CanEditField(typeOfInvestmentNames.ExternalCode.name, typeEntity.Name, assemblyName, roles))
                    };
                    return new Descriptor(fields);
                default:
                    throw new TypeAccessException();
            }
        }
    }
}
