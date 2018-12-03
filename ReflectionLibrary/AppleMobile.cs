using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class AppleMobile : CellPhone
    {
        public bool InternetIsOn { get; set; }
        public int PhotoCount { get; set; }
        public int NotesCount { get; set; }
        public List<string> AppsStarted { get; set; }

        public AppleMobile(string modelname, string os, int serialnumber, long phonenumber, int simcount, int memorysize) :
            base(modelname, os, serialnumber, phonenumber, simcount, memorysize, true)
        {
            AppsStarted = new List<string>();
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

        public void StartApplication(string name)
        {
            AppsStarted.Add(name);
            MobileStatus = "Приложение успешно запущено!";
        }

        public void MakePhoto()
        {
            if (FreeMemory + 4 > MemorySize)
                throw new Exception("Недостаточно памяти!");

            PhotoCount++;
            MobileStatus = "Фото сделано!";
        }

        public void DeletePhoto()
        {
            if (PhotoCount == 0)
                throw new Exception("Нет фото!");

            PhotoCount--;
            MobileStatus = "Фото удалено!";
        }

        public int FreeMemory
        {
            get { return MemorySize - NotesCount * 2 - PhotoCount * 4; }
        }

        public override void DisableInternet()
        {
            InternetIsOn = false;
            MobileStatus = "Интернет выключен!";
        }

        public override void SurfInternet(string request)
        {
            if (!InternetIsOn)
                throw new Exception("На телефоне не включен интернет! Сначала включите его!");

            MobileStatus = "Идёт поиск - " + request;
        }

        public override void EnableInternet()
        {
            InternetIsOn = true;
            MobileStatus = "Интернет включен!";
        }

        public override string ToString()
        {
            return "Apple " + ModelName;
        }

        public override List<string> GetInfo()
        {
            List<string> info = base.GetInfo();
            info.AddRange(new List<string>
            {
                "Наличие интернета: " + (HaveInternet ? "Да" : "Нет"),
                 "Интернет включён: " + (InternetIsOn ? "Да" : "Нет"),
                "Количество фото: " + PhotoCount.ToString(),
                "Количество заметок: " + NotesCount.ToString(),
                "Свободная память: " + FreeMemory.ToString(),
                "Запущенные приложения: " + string.Join( ",", AppsStarted.ToArray())
            });
            return info;
        }
    }
}
