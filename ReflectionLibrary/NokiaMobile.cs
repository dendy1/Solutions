using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class NokiaMobile : CellPhone
    {
        public bool InternetIsOn { get; set; }
        public bool AppStarted { get; set; }
        public NokiaMobile(string ModelName, string OS, int SerialNumber, long PhoneNumber, int SimCount, int MemorySize, bool HaveInternet) :
            base(ModelName, OS, SerialNumber, PhoneNumber, SimCount, MemorySize, HaveInternet)
        {

        }

        public void StartApp(string app)
        {
            if (AppStarted)
                throw new Exception("Приложение уже запущено! Закройте сначала предыдущее");

            AppStarted = true;
            MobileStatus = "Запущено приложение - " + app;
        }

        public void CloseApp()
        {
            if (!AppStarted)
                throw new Exception("Запущенного приложения нет!");

            AppStarted = false;
            MobileStatus = "Приложение закрыто";
        }

        public override void DisableInternet()
        {
            if (!HaveInternet)
                throw new Exception("На телефоне нет интернета!");

            InternetIsOn = false;
            MobileStatus = "Интернет выключен!";
        }

        public override void SurfInternet(string request)
        {
            if (!HaveInternet)
                throw new Exception("На телефоне нет интернета!");
            if (!InternetIsOn)
                throw new Exception("На телефоне не включен интернет! Сначала включите его!");

            MobileStatus = "Идёт поиск - " + request;
        }

        public override void EnableInternet()
        {
            if (!HaveInternet)
                throw new Exception("На телефоне нет интернета!");

            InternetIsOn = true;
            MobileStatus = "Интернет включен!";
        }

        public override string ToString()
        {
            return "Nokia " + ModelName;
        }
        public override List<string> GetInfo()
        {
            List<string> info = base.GetInfo();
            info.AddRange(new List<string>
            {
                "Наличие интернета: " + (HaveInternet ? "Да" : "Нет"),
                "Интернет включён: " + (InternetIsOn ? "Да" : "Нет"),
                "Запущенное приложение: " +  AppStarted
            });
            return info;
        }
    }
}
