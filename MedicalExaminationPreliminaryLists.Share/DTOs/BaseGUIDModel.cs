namespace MedicalExaminationPreliminaryLists.Share.DTOs
{
    public class BaseGUIDModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public BaseGUIDModel()
        {
            Id = Guid.NewGuid();
            UserName = string.Empty;
        }
    }
}
