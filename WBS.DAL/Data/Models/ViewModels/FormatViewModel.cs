namespace WBS.DAL.Models
{ 
    public class FormatViewModel : IViewModel<Format>
    {      
        public int Id { get; set; }   
        public string Title { get; set; }
        public string Profile { get; set; }

        public int? DirectorOfFormatId { get; set; }
        public string DirectorOfFormatFio { get; set; }

        public int? DirectorOfKYFormatId { get; set; }
        public string DirectorOfKYFormatFio { get; set; }

        public int? KYFormatId { get; set; }
        public string KYFormatFio { get; set; }

        public string TypeOfFormat { get; set; }
        public int E1Limit { get; set; }
        public int E2Limit { get; set; }
        public int E3Limit { get; set; }

        public FormatViewModel(Format model)
        {
            Id = model.Id;
            Title = model.Title;
            Profile = model.Profile;

            DirectorOfFormatId = model.DirectorOfFormatId;
            if (model.DirectorOfKYFormat!=null) DirectorOfKYFormatFio = model.DirectorOfKYFormat.Fio;

            DirectorOfFormatId = model.DirectorOfFormatId;
            if (model.DirectorOfFormat!=null) DirectorOfFormatFio = model.DirectorOfFormat.Fio;

            KYFormatId = model.KYFormatId;
            if (model.KYFormat != null) KYFormatFio = model.KYFormat.Fio;

            TypeOfFormat = model.TypeOfFormat;

            E1Limit = model.E1Limit;
            E2Limit = model.E2Limit;
            E3Limit = model.E3Limit;
        }

        public FormatViewModel()
        {
        }

        public Format CreateModel()
        {
            return new Format()
            {
                Id = Id,
                Title = Title,
                Profile = Profile,
                DirectorOfFormatId = DirectorOfFormatId,
                DirectorOfKYFormatId = DirectorOfKYFormatId,
                KYFormatId = KYFormatId,
                TypeOfFormat = TypeOfFormat,
                E1Limit = E1Limit,
                E2Limit = E2Limit,
                E3Limit = E3Limit
            };
        }   
    }
}
