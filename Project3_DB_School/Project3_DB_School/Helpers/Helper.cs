using Project3_DB_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.Helpers
{
    [Serializable]
    internal class Helper
    {
        public static MemoryStream SerializeToStream(object obj)
        {
            MemoryStream ms = new MemoryStream();
            var formatter = new BinaryFormatter(); // Merubah object menjadi biner
            formatter.Serialize(ms, obj);
            return ms;
        }

        // Merubah Stream ke Object
        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object obj = formatter.Deserialize(stream);
            return obj;
        }

        public void CreateFileSchool()
        {
            string namaFile = @"C:\Users\khair\OneDrive\Dokumen\Belajar .NET\FileStream\SchoolDB.txt";

            if (!File.Exists(namaFile))
            {
                SchoolContext schoolContext = new SchoolContext()
                {
                    students = new List<Student>(),
                    grades = new List<Grade>()
                };

                MemoryStream ms = SerializeToStream(schoolContext);
                using (FileStream fs = new FileStream(namaFile, FileMode.Create, FileAccess.Write))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.CopyTo(fs);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        public void SaveFile(SchoolContext schoolContext)
        {
            string namaFile = @"C:\Users\khair\OneDrive\Dokumen\Belajar .NET\FileStream\SchoolDB.txt";

            MemoryStream ms = SerializeToStream(schoolContext);
            using (FileStream fs = new FileStream(namaFile, FileMode.Open, FileAccess.ReadWrite))
            {
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(fs);
                fs.Flush();
                fs.Close();
            }
        }

        public SchoolContext OpenFile()
        {
            string namaFile = @"C:\Users\khair\OneDrive\Dokumen\Belajar .NET\FileStream\SchoolDB.txt";

            MemoryStream ms = new MemoryStream();
            using (FileStream fs = new FileStream(namaFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                fs.CopyTo(ms);
            }

            var schoolContex = (SchoolContext)DeserializeFromStream(ms);
            return schoolContex;
        }

        public void DeleteFileStudent()
        {
            //buat file delete sendiri
        }

        public void UpdateFileSchool()
        {
            //buat file update sendiri
        }
    }
}
