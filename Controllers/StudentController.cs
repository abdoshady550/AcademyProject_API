using AcademyProject_API.Model.Dtos;
using AcademyProject_API.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Api.Handler;
using Movie_Api.Mappers;
using Movie_Api.Services;
using static AcademyProject_API.Model.Dtos.StudentDto;

namespace AcademyProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentService _service;
        public StudentController(IStudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            var AllStudent = await _service.GetAll();
            if (AllStudent == null)
                throw new ApiException($"Has No Data Back", StatusCodes.Status204NoContent);
            var dto = StudentMapper.GetStudentsDto(AllStudent);

            return Ok(APIRespone<IEnumerable<GetStudentDto>>.CreateSuccess(dto));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"Not Found", StatusCodes.Status404NotFound);
            var dto = StudentMapper.GetStudentDto(item);

            return Ok(APIRespone<GetStudentDto>.CreateSuccess(dto));
        }
        [HttpPost]
        public async Task<ActionResult> AddStudent(CreateStudentDto StudentDto)
        {
            if (StudentDto == null)
                throw new ApiException($"BadRequest from body", StatusCodes.Status400BadRequest);

            var item = StudentMapper.CreateStudentDto(StudentDto);
            await _service.Add(item);
            return Ok(APIRespone<Student>.CreateSuccess(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentById(int id, [FromBody] UpdateStudentDto StudentDto)
        {
            if (StudentDto == null)
                throw new ApiException($"BadRequest from body", StatusCodes.Status400BadRequest);

            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"Not Found", StatusCodes.Status404NotFound);
            if (StudentDto.FName != null)
                item.FName = StudentDto.FName;
            if (StudentDto.LName != null)
                item.LName = StudentDto.LName;
            _service.Update(item);

            return Ok(APIRespone<Student>.CreateSuccess(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentById(int id)
        {

            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"NoContent", StatusCodes.Status204NoContent);

            _service.Delete(item);

            return Ok(APIRespone<Student>.CreateSuccess(item));
        }
    }
}
