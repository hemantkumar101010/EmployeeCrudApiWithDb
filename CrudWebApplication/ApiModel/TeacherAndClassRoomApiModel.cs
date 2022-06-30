namespace CrudWebApplication.Model
{
    public class TeacherAndClassRoomApiModel
    {
        public TeacherApiModel Teacher { get; set; }
        public List<ClassRoomApiModel> ClassRoomList { get; set; } 

    }
}
