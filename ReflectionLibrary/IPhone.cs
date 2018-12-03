using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public interface IPhone
    {
        bool IsBusy { get; set; }
        string MobileStatus { get; set; }
        string ModelName { get; set; }
        long PhoneNumber { get; set; }
        void StartCall(string phone);
        void AcceptCall(string phone);
        void StopCall();
        List<string> GetInfo();
    }
}
