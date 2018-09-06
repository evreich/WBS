using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Data.Classes;
using Newtonsoft.Json;

namespace WBS.API.Descriptors
{
    public abstract class Descriptor
    {
        //TODO: поменять на соотв DAL
        //private readonly BudgetPlanDAL _allowsToFieldDAL;

        //TODO: загружать в контроллере и передавать в параметры 

        private readonly object _typeID;
        private readonly List<string> _roles;

        //Реализация основных поелй формы в наследниках

        //TODO: поменять на соотв DAL
        public Descriptor(
            //BudgetPlanDAL dal, 
            object typeID, 
            List<string> roles
            )
        {
            //_allowsToFieldDAL = dal;
            _typeID = typeID;
            _roles = roles;
        }

        protected bool CanEditField(string fieldName)
        {
            if (String.IsNullOrEmpty(fieldName))
                throw new ArgumentException("Введен пустой параметр fieldName.");
            //return _allowsToFieldDAL.CanEditField(fieldName, typeID, roles);
            return true;
        }

        protected bool CanAccessToObject()
        {
            //return _allowsToFieldDAL.CanAccessToObject(typeID, roles);
            return true;
        }

        public string ConvertToJSON()
        {
            if (!CanAccessToObject())
                return null; //exception on access

            var fields = this.GetType().GetFields()
                                    .Where(field => field.GetType() == typeof(FieldAttributes))
                                    .Select(field => (FieldAttributes)field.GetValue(this))
                                    .ToDictionary(field => field.Name);

            return JsonConvert.SerializeObject(fields);
        }
    }
}
