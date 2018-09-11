using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class FormatForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Profile { get; private set; }
        public (string label, string name) TypeOfFormat { get; private set; }
        public (string label, string name) E1Limit { get; private set; }
        public (string label, string name) E2Limit { get; private set; }
        public (string label, string name) E3Limit { get; private set; }
        public (string label, string name) DirectorOfFormat { get; private set; }
        public (string label, string name) DirectorOfKYFormat { get; private set; }
        public (string label, string name) KYFormat { get; private set; }

        public FormatForm()
        {
            Title = ("Название", "title");
            Profile = ("Код", "code");
            TypeOfFormat = ("Название", "title");
            E1Limit = ("Код", "code");
            E2Limit = ("Название", "title");
            E3Limit = ("Код", "code");
            DirectorOfFormat = ("Название", "title");
            DirectorOfKYFormat = ("Код", "code");
            KYFormat = ("Название", "title");
        }
    }
}
