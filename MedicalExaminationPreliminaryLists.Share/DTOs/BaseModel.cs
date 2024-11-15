namespace MedicalExaminationPreliminaryLists.Share.DTOs
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public BaseModel()
        {
            UserName = string.Empty;
        }
    }
}
