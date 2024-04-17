using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Класс, представляющий избирателя
    class Voter
    {
        public string FullName { get; set; } // ФИО избирателя

        public string Address { get; set; } // Адрес проживания

        public int Age { get; set; } // Возраст

        public int PollingStationNumber { get; set; } // Номер участка

        public int YearOfVoting { get; set; } // Год голосования

        public string Vote { get; set; } // Голосование (да / нет/ воздерживаюсь)


        // Конструктор класса Voter
        public Voter(string fullName, string address, int age, int pollingStationNumber, int yearOfVoting, string vote)
        {
            FullName = fullName;
            Address = address;
            Age = age;
            PollingStationNumber = pollingStationNumber;
            YearOfVoting = yearOfVoting;
            Vote = vote;
        }


        // Переопределение метода ToString для удобного вывода информации об избирателе
        public override string ToString()
        {
            return $"{FullName}, {Address}, {Age} лет, Участок: {PollingStationNumber}, Год голосования: {YearOfVoting}, Голос: {Vote}";
        }



    }
}
