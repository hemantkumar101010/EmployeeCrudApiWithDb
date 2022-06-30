using AutoMapper;
using CrudWebApplication.Model;
using EmployeesData;
using EmployeesData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CrudWebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherNClassRoomController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;
        public TeacherNClassRoomController(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult PostTeacherNClassRoom(TeacherAndClassRoomApiModel teacherAndClassRoomApiModel)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity ser 'EmployeeDbContext.Teacher' is null");
            }

            // converting TeacherApiModel type to datamodel Teacher type
            var obj = _mapper.Map<Teacher>(teacherAndClassRoomApiModel.Teacher);

            //converting list of classRoomApiModel to data model list of classroom
            var classRoomList = _mapper.Map<List<ClassRoom>>(teacherAndClassRoomApiModel.ClassRoomList);

            obj.ClassRoomList = classRoomList;
            _context.Teachers.Add(obj);
            _context.SaveChanges();
            return Ok();

        }


        [HttpGet]
        public async Task<TeacherAndClassRoomApiModel> GetTeacherNClassroom(int TeacherId)
        {

            TeacherAndClassRoomApiModel teacherAndClassRoomApiModel = new();

            TeacherApiModel teacherApiModel = new();
            List<ClassRoomApiModel> classRoomApiModelsList = new List<ClassRoomApiModel>();

            var teacher = await _context.Teachers.FindAsync(TeacherId);
            if(teacher != null)
            {
                var classroomList = _context.ClassRooms.Where(c => c.teacher.TeacherId == TeacherId).ToList();

                teacherApiModel = _mapper.Map<TeacherApiModel>(teacher);
                classRoomApiModelsList = _mapper.Map<List<ClassRoomApiModel>>(classroomList);

                teacherAndClassRoomApiModel.Teacher = teacherApiModel;
                teacherAndClassRoomApiModel.ClassRoomList = classRoomApiModelsList;

                return teacherAndClassRoomApiModel;
            }
            else
            {
                return teacherAndClassRoomApiModel;
            }
            
            
        }



        [HttpGet]
        public ActionResult GetAllTeachers()
        {

            if (_context.Teachers == null)
            {
                return Ok(NotFound());
            }
            var allTeachers = _context.Teachers.Include(cl => cl.ClassRoomList).ToList();

            return Ok(allTeachers);
        }



        [HttpPut]
         public ActionResult PutTeacherNClassrooms(int id, TeacherAndClassRoomApiModel teacherAndClassRoomApiModel)
        {
            var teacherObj = _context.Teachers.Find(id);
            if(teacherObj != null)
            {
                //converting ApiModel type to Entity data model type

                var teacher = _mapper.Map<Teacher>(teacherAndClassRoomApiModel.Teacher);
                var classroom = _mapper.Map<List<ClassRoom>>(teacherAndClassRoomApiModel.ClassRoomList);

                //updating in both table
                var updateTeacher = _context.Teachers.Where(t => t.TeacherId == id).Include(c => c.ClassRoomList).FirstOrDefault();


                updateTeacher.TeacherName = teacher.TeacherName;
                updateTeacher.TeacherMobNumber = teacher.TeacherMobNumber;

                updateTeacher.ClassRoomList = classroom;

                _context.Update(updateTeacher);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPatch]

        public ActionResult PatchTeacherNClassrooms(int id, int mobile)
        {
            var teacherObj = _context.Teachers.Where(t=>t.TeacherId==id).FirstOrDefault();
            if (teacherObj != null)
            {
                var update = _context.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();


                update.TeacherMobNumber = mobile;

                _context.Update(update);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        public ActionResult DeleteTeacheNClassroom(int id)
        {
            var teacher = _context.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
