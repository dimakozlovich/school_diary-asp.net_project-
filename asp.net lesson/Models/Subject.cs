namespace asp.net_lesson.Models
{
    public class Subject
    {
        public int Timetable_id { get; set; }
        public int Place_in_week { get; set; }
        public int Place_in_day { get; set; }
        public DateTime Date_first_day_of_week { get; set; }
        public int Name_subject_id { get; set; }
        public string Homework { get; set; }
        public int Grade_id { get; set; }
        
        public Subject(int place_in_week, int place_in_day,DateTime dateTime,int name_subject_id,string homework,int grade_id)
        {
           Place_in_week = place_in_week;
           Place_in_day = place_in_day;    
           Date_first_day_of_week = dateTime;
           Name_subject_id = name_subject_id;
           Homework = homework;
           Grade_id = grade_id;
        }
        public override string ToString()
        {
             return $"{Place_in_week} {Place_in_day} {Date_first_day_of_week} {Name_subject_id} {Homework} {Grade_id}";
        }
    }
}
