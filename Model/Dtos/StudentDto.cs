namespace AcademyProject_API.Model.Dtos
{

    public class CreateStudentDto
    {
        public string FName { get; set; }
        public string LName { get; set; }


    }
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }


    }
    public class UpdateStudentDto
    {
        public string? FName { get; set; }
        public string? LName { get; set; }


    }


}
