using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class ProviderForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Profiles { get; private set; }

        public ProviderForm()
        {
            Title = ("Название", "title");
            Profiles = ("Профили", "profiles");
        }
    }
}
