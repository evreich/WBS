using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class SiteForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Format { get; private set; }
        public (string label, string name) KySit { get; private set; }
        public (string label, string name) TechnicalExpert { get; private set; }
        public (string label, string name) DirectorOfSit { get; private set; }
        public (string label, string name) CreaterOfBudget { get; private set; }
        public (string label, string name) KyRegion { get; private set; }
        public (string label, string name) OperationDirector { get; private set; }

        public SiteForm()
        {
            Title = ("Название", "title");
            Format = ("Код", "code");
            KySit = ("КУ Сита", "kySite");
            TechnicalExpert = ("Технический эксперт", "technicalExpert");
            DirectorOfSit = ("Директор Сита", "directorOfSit");
            CreaterOfBudget = ("Создатель", "createrOfBudget");
            KyRegion = ("КУ региональный", "kyRegion");
            OperationDirector = ("Операционный директор", "operationDirector");
        }
    }
}
