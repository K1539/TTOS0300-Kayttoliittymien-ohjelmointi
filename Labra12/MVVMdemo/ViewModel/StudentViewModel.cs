using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMdemo.Model;

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
    }
}
