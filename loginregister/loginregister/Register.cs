using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace loginregister
{
    public class Register
    {


        public string GetStudentPath()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filepath = Path.Combine(appdata, "Hostel");
            if(!Directory. Exists (filepath ))
            {
                Directory.CreateDirectory(filepath);
            }
            string student = Path.Combine(filepath, "Student");
            if(!Directory.Exists(student ))
            {
                Directory.CreateDirectory(student);
            }
            string studentfile = Path.Combine(student , "Student" + ".json");
            return studentfile;
        }

        public List<Student> GetStudent(string studentfile)
        {
            List<Student> liststudent = new List<Student>();
            if (File.Exists(studentfile))
            {
                string json = File.ReadAllText(studentfile);
                liststudent = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            return liststudent;
        }

        public void SaveStudent(List<Student > liststudent , string studentfile)
        {
            string json = JsonConvert.SerializeObject(liststudent);
            File.WriteAllText(studentfile, json);
            MessageBox.Show("Register Successfully");
        }
    }
}
