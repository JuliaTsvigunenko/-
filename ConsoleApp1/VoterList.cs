using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Класс, представляющий список избирателей
    class VoterList
    {

        private List<Voter> voters = new List<Voter>(); // Список избирателей

        // Метод для добавления избирателя в начало списка
        public void AddFirst(Voter voter)
        {
            voters.Insert(0, voter);
        }

        // Метод для добавления избирателя в конец списка
        public void AddLast(Voter voter)
        {
            voters.Add(voter);
        }


        // Метод для добавления избирателя после указанного избирателя
        public void AddAfter(Voter existingVoter, Voter newVoter)
        {
            int index = voters.IndexOf(existingVoter);
            if (index != -1)
            {
                voters.Insert(index + 1, newVoter);
            }
            else
            {
                Console.WriteLine("Указанный избиратель не найден.");
            }

        }


        // Метод для добавления избирателя перед указанным избирателем
        public void AddBefore(Voter existingVoter, Voter newVoter)
        {
            int index = voters.IndexOf(existingVoter);
            if (index != -1)
            {
                voters.Insert(index, newVoter);
            }
            else
            {
                Console.WriteLine("Указанный избиратель не найден.");
            }
        }



        // Метод для удаления избирателя из списка
        public void Remove(Voter voter)
        {
            voters.Remove(voter);
        }

        // Метод для вывода всех избирателей
        public void PrintAll()
        {
            foreach (var voter in voters)
            {
                Console.WriteLine(voter);
            }
        }


        // Метод для вывода избирателей по возрастным группам
        public void PrintByAgeGroup(int minAge, int maxAge)
        {
            foreach (var voter in voters)
            {
                if (voter.Age < 30 && voter.Age >= minAge)
                {
                    Console.WriteLine($"Младше 30 лет: {voter}");
                }
                else if (voter.Age >= 30 && voter.Age <= 50)
                {
                    Console.WriteLine($"От 30 до 50 лет: {voter}");
                }
                else if (voter.Age > 50 && voter.Age <= maxAge)
                {
                    Console.WriteLine($"Старше 50 лет: {voter}");
                }
            }
        }


        // Метод для вывода избирателей с негативным голосом в текущем году
        public void PrintNegativeOrAbstain(int currentYear)
        {
            foreach (var voter in voters)
            {
                if (voter.YearOfVoting == currentYear && (voter.Vote.ToLower() == "нет" || voter.Vote.ToLower() == "воздерживаюсь"))
                {
                    Console.WriteLine(voter);
                }
            }
        }



        // Метод для создания нового списка избирателей по номеру участка
        public VoterList FilterByPollingStation(int pollingStationNumber)
        {
            var filteredList = new VoterList();
            foreach (var voter in voters)
            {
                if (voter.PollingStationNumber == pollingStationNumber)
                {
                    filteredList.AddLast(voter);
                }
            }
            return filteredList;
        }




        //// Метод для сохранения данных списка в бинарный файл
        //public void SaveToFile(string fileName)
        //{
        //    try
        //    {
        //        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        //        {
        //            BinaryFormatter formatter = new BinaryFormatter();
        //            formatter.Serialize(fs, voters);
        //        }
        //        Console.WriteLine("Данные успешно сохранены в файл.");
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine($"Ошибка при сохранении данных: {e.Message}");
        //    }
        //}

        //// Метод для загрузки данных из бинарного файла
        //public void LoadFromFile(string fileName)
        //{
        //    try
        //    {
        //        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        //        {
        //            BinaryFormatter formatter = new BinaryFormatter();
        //            voters = (List<Voter>)formatter.Deserialize(fs);
        //        }
        //        Console.WriteLine("Данные успешно загружены из файла.");
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine($"Ошибка при загрузке данных: {e.Message}");
        //    }
        //    catch (SerializationException e)
        //    {
        //        Console.WriteLine($"Ошибка десериализации: {e.Message}");
        //    }
        //}









    }
}


