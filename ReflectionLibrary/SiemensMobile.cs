using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class SiemensMobile : CellPhone
    {
        public int NotesCount { get; set; }
        public new bool HaveInternet { get; private set; }
        public SiemensMobile(string ModelName, string OS, int SerialNumber, long PhoneNumber, int SimCount, int MemorySize, bool HaveInternet) :
            base(ModelName, OS, SerialNumber, PhoneNumber, SimCount, MemorySize, HaveInternet)
        {
            NotesCount = 0;
            HaveInternet = false;
        }
        public void MakeNote()
        {
            if (FreeMemory + 2 > MemorySize) throw new Exception("На телефоне нет памяти! Чтобы сделать заметку, нужно удалить другие!");

            NotesCount++;
            MobileStatus = "Заметка добавлена!";
        }

        public void DeleteNote()
        {
            if (NotesCount == 0) throw new Exception("На телефоне нет заметок! Сначала сделайте заметку!");

            NotesCount--;
            MobileStatus = "Заметка удалена!";
        }

        public void MakePhoto()
        {
            throw new Exception("На телефоне нет фунцкии фотоаппарата!");
        }

        public void DeletePhoto()
        {
            throw new Exception("На телефоне нет фунцкии фотоаппарата!");
        }

        public int FreeMemory
        {
            get { return MemorySize - NotesCount * 2; }
        }

        public override void EnableInternet()
        {
            throw new Exception("На данном аппарате нет интернета");
        }

        public override void DisableInternet()
        {
            throw new Exception("На данном аппарате нет интернета");
        }

        public override void SurfInternet(string request)
        {
           throw new Exception("На данном аппарате нет интернета");
        }

        public override string ToString()
        {
            return "Siemens " + ModelName;
        }
        public override List<string> GetInfo()
        {
            List<string> info = base.GetInfo();
            info.AddRange(new List<string>
            {
                "Наличие интернета: " + (HaveInternet ? "Да" : "Нет"),
                "Количество заметок: " + NotesCount.ToString(),
                "Свободная память: " + FreeMemory.ToString(),
            });
            return info;
        }
    }
}
