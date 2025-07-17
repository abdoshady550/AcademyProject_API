namespace Movie_Api.Mappers
{
    using AcademyProject_API.Model.Dtos;
    using AcademyProject_API.Model.Entities;

    public static class StudentMapper
    {
        public static Student CreateStudentDto(CreateStudentDto dto)
        {

            return new Student
            {
                FName = dto.FName,
                LName = dto.LName

            };
        }

        public static IEnumerable<GetStudentDto> GetStudentsDto(IEnumerable<Student> Student)
        {

            return Student.Select(m => new GetStudentDto
            {
                Id = m.Id,
                FName = m.FName,
                LName = m.LName
            });
        }

        public static GetStudentDto GetStudentDto(Student Student)
        {

            return new GetStudentDto
            {
                Id = Student.Id,
                FName = Student.FName,
                LName = Student.LName
            };
        }
        public static UpdateStudentDto UpdateStudentDto(Student Student)
        {

            return new UpdateStudentDto
            {

                FName = Student.FName,
                LName = Student.LName
            };
        }

    }
}
