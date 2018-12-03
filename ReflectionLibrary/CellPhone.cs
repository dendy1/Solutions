using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public abstract class CellPhone : IPhone
    {
        //реализация интрефейса
        public bool IsBusy { get; set; } = false;
        public string MobileStatus { get; set; }
        public string ModelName { get; set; }
        public long PhoneNumber { get; set; }
        public void StartCall(string phone)
        {
            MobileStatus = "Данный аппарат звонит на номер " + phone.ToString();
            IsBusy = true;
        }
        public void AcceptCall(string phone)
        {
            MobileStatus = "Данный аппарат соединенён с номером " + phone.ToString();
            IsBusy = true;
        }
        public void StopCall()
        {
            MobileStatus = "Данный аппарат свободен";
            IsBusy = false;
        }

        //дополнительные поля
        public int IMEI { get; private set; }
        public int SimCount { get; set; }
        public string OS { get; set; }
        public int MemorySize { get; set; }
        public bool HaveInternet { get; set; }
        public CellPhone(string ModelName, string OS, int SerialNumber, long PhoneNumber, int SimCount, int MemorySize, bool HaveInternet)
        {
            IMEI = SerialNumber;
            this.SimCount = SimCount;
            this.OS = OS;
            this.PhoneNumber = PhoneNumber;
            this.ModelName = ModelName;
            this.MemorySize = MemorySize;
            this.HaveInternet = HaveInternet;
            MobileStatus = "Свободен";
        }
        public abstract void EnableInternet();
        public abstract void SurfInternet(string request);
        public abstract void DisableInternet();

        public virtual List<string> GetInfo()
        {
            List<string> info = new List<string>()
            {
                "Модель: " + ModelName,
                "Операционная система: " + OS,
                "IMEI: " + IMEI.ToString(),
                "Номер телефона: " + PhoneNumber.ToString(),
                "Количество сим-карт: " + SimCount.ToString(),
                "Количество памяти: " + MemorySize.ToString(),
                "Модель: " + MobileStatus
            };

            return info;
        }
    }
}
