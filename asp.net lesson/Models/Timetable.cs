using System;
using System.Collections.Generic;
using System.Text;
using asp.net_lesson.Models;
using Microsoft.Data.SqlClient;
namespace prototypedb
{
    public class Timetable
    {
        public List<Subject> Subjects { get; set; }
        public int Grade_id { get; set; }
        public Timetable()
        {
            Subjects = new List<Subject>();
        }
        public Timetable(int grade_id)
        {
            Subjects = new List<Subject>();
            Grade_id = grade_id;
            using(var sqlConnection = new SqlConnection(Connection.connection_string))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(@$"SELECT place_in_week,place_in_day,date_first_day_of_week,name_subject_id,homework, grade_id
                                                 FROM Timetable
                                                 WHERE grade_id = {grade_id}", sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject(reader.GetInt32(0),                                                                           
                                                          reader.GetInt32(1),                                               
                                                          reader.GetDateTime(2),
                                                          reader.GetInt32(3),
                                                          reader.GetString(4),
                                                          reader.GetInt32(5));
                            Subjects.Add(subject);
                        
                        }
                    }
                }
            }
        }
        public void UpdateTimetable()
        {
            Subjects = new List<Subject>();
            using (var sqlConnection = new SqlConnection(Connection.connection_string))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(@$"SELECT place_in_week,place_in_day,date_first_day_of_week,name_subject_id,homework, grade_id
                                                 FROM Timetable
                                                 WHERE grade_id = {Grade_id}", sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject(reader.GetInt32(0),
                                                          reader.GetInt32(1),
                                                          reader.GetDateTime(2),
                                                          reader.GetInt32(3),
                                                          reader.GetString(4),
                                                          reader.GetInt32(5));
                            Subjects.Add(subject);

                        }
                    }
                }
            }
        }

        public Subject FindSubject(int place_in_day, int place_in_week, int grade_id)
        {
          foreach(var subject in Subjects)
            {
                if(
                   subject.Place_in_day == place_in_day
                    && subject.Place_in_week == place_in_week
                    && subject.Grade_id == grade_id)
                {
                    return subject;
                }
            }
            return new Subject(); 
        }
        public void EditSubject(DateTime date, int place_in_day, int place_in_week, int grade_id, string EditSubject, string EditHomework)
        {

            if (EditSubject == null)
            {
                using (var sqlConnection = new SqlConnection(Connection.connection_string))
                {
                    sqlConnection.Open();
                    var sqlCommand = new SqlCommand($@"DELETE FROM Timetable
                                                       WHERE place_in_day = {place_in_day}
                                                       AND place_in_week = {place_in_week}
                                                       AND grade_id = {grade_id}", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(Connection.connection_string))
                {
                    sqlConnection.Open();
                    var sqlCommand = new SqlCommand($@"UPDATE Timetable SET homework = '{EditHomework}',
                                                       name_subject_id = {EditSubject}
                                                       WHERE place_in_day = {place_in_day}
                                                          AND place_in_week = {place_in_week}
                                                          
                                                          AND grade_id = {grade_id}", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void AddSubject(int place_in_day, int place_in_week, int grade_id, string EditSubject, string EditHomework)
        {
            using (var sqlConnection = new SqlConnection(Connection.connection_string))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand($@"INSERT INTO Timetable (place_in_day,place_in_week,grade_id,name_subject_id,homework,date_first_day_of_week)
                                                                 VALUES({place_in_day},{place_in_week},{grade_id},{EditSubject},'{EditHomework}','2011/02/27')", 
                                                                 sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public Subject ExistenceCheck(int day,int place_in_day,Timetable timetable)
        {
           foreach(Subject subject in Subjects)
            {
              if(subject.Place_in_day == place_in_day&&subject.Place_in_week == day)
                {
                    return subject;
                }
            }
            return new Subject(timetable.Grade_id,day,place_in_day);
        }
        public bool BoolExistenceCheck(int day, int place_in_day)
        {
            foreach (Subject subject in Subjects)
            {
                if (subject.Place_in_day == place_in_day && subject.Place_in_week == day)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
