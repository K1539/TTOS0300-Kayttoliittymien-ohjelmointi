using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMdemo.Model;
using MySql.Data.MySqlClient;

namespace MVVMdemo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            //lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa haettaisiin esim tietokannasta
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen", AsioId="A1234"});
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", AsioId = "B1234" });
            students.Add(new Student { FirstName = "Tomi", LastName = "Tötterström", AsioId = "C1234" });
            students.Add(new Student { FirstName = "Anni", LastName = "Ainokainen", AsioId = "D1234" });
            Students = students;
        }
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MVVMdemo.Model.Student s = new Model.Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.AsioId = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            string pw = "";
            //Haetaan salasana App.Config- konfiguraatiotiedostosta
            pw = MVVMdemo.Properties.Settings.Default.passu;
            return string.Format("Data source=mysql.labranet.jamk.fi; Initial Catalog=K1539_3; user=K1539; password={0}", pw);
        }
    }
}
