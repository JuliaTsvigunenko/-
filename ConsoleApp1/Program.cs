using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            VoterList voterList = new VoterList(); // Создание экземпляра списка избирателей

            while (true) // Основной цикл программы для работы с меню
            {
                Console.WriteLine("\n==== Меню программы по работе с избирателями ====");
                Console.WriteLine("1. Вывести всех избирателей");
                Console.WriteLine("2. Добавить избирателя в начало списка");
                Console.WriteLine("3. Добавить избирателя в конец списка");
                Console.WriteLine("4. Добавить избирателя после указанного избирателя");
                Console.WriteLine("5. Добавить избирателя перед указанным избирателем");
                Console.WriteLine("6. Удалить избирателя из списка");
                Console.WriteLine("7. Вывести избирателей по возрастным группам");
                Console.WriteLine("8. Вывести избирателей с негативным голосом в текущем году");
                Console.WriteLine("9. Создать новый список избирателей по номеру участка");
                Console.WriteLine("10. Сохранить данные в бинарный файл");
                Console.WriteLine("11. Загрузить данные из бинарного файла");
                Console.WriteLine("12. Выход из программы");
                Console.Write("Введите номер действия: ");


                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice)) // Проверка корректности ввода
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 13.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Вывести всех избирателей
                        Console.WriteLine("\nСписок избирателей:");
                        voterList.PrintAll();
                        break;
                    case 2: // Добавить избирателя в начало списка
                        AddVoter(voterList, true);
                        break;
                    case 3: // Добавить избирателя в конец списка
                        AddVoter(voterList, false);
                        break;
                    case 4: // Добавить избирателя после указанного избирателя
                        AddVoterAfter(voterList);
                        break;
                    case 5: // Добавить избирателя перед указанным избирателем
                        AddVoterBefore(voterList);
                        break;
                    case 6: // Удалить избирателя из списка
                        RemoveVoter(voterList);
                        break;
                    case 7: // Вывести избирателей по возрастным группам
                        PrintByAgeGroup(voterList);
                        break;
                    case 8: // Вывести избирателей с негативным голосом в текущем году
                        PrintNegativeOrAbstain(voterList);
                        break;
                    case 9: // Создать новый список избирателей по номеру участка
                        FilterByPollingStation(voterList);
                        break;
                    case 10: // Сохранить данные в бинарный файл
                        SaveToFile(voterList);
                        break;
                    case 11: // Загрузить данные из бинарного файла
                        LoadFromFile(voterList);
                        break;
                    case 12: // Выход из программы
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 13.");
                        break;
                }




                // Метод для добавления избирателя в список
                static void AddVoter(VoterList voterList, bool addToBeginning)
                {
                    Console.Write("Введите ФИО: ");
                    string fullName = Console.ReadLine();
                    Console.Write("Введите адрес: ");
                    string address = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Введите номер участка: ");
                    int pollingStationNumber = int.Parse(Console.ReadLine());
                    Console.Write("Введите год голосования: ");
                    int yearOfVoting = int.Parse(Console.ReadLine());
                    Console.Write("Введите голос (да / нет / воздерживаюсь): ");
                    string vote = Console.ReadLine();

                    Voter newVoter = new Voter(fullName, address, age, pollingStationNumber, yearOfVoting, vote);

                    if (addToBeginning)
                    {
                        voterList.AddFirst(newVoter);
                    }
                    else
                    {
                        voterList.AddLast(newVoter);
                    }
                    Console.WriteLine("Избиратель добавлен.");
                }



                // Метод для добавления избирателя после указанного избирателя
                static void AddVoterAfter(VoterList voterList)
                {
                    Console.Write("Введите ФИО избирателя, после которого нужно добавить нового избирателя: ");
                    string existingFullName = Console.ReadLine();

                    Voter existingVoter = FindVoterByFullName(voterList, existingFullName);
                    if (existingVoter == null)
                    {
                        Console.WriteLine("Избиратель не найден.");
                        return;
                    }

                    AddVoter(voterList, false);
                    Voter newVoter = voterList.FindLast(x => x.FullName == existingFullName);
                    voterList.AddAfter(existingVoter, newVoter);
                    Console.WriteLine("Избиратель добавлен после указанного.");
                }



                // Метод для добавления избирателя перед указанным избирателем
                static void AddVoterBefore(VoterList voterList)
                {
                    Console.Write("Введите ФИО избирателя, перед которым нужно добавить нового избирателя: ");
                    string existingFullName = Console.ReadLine();

                    Voter existingVoter = FindVoterByFullName(voterList, existingFullName);
                    if (existingVoter == null)
                    {
                        Console.WriteLine("Избиратель не найден.");
                        return;
                    }

                    AddVoter(voterList, false);
                    Voter newVoter = voterList.FindLast(x => x.FullName == existingFullName);
                    voterList.AddBefore(existingVoter, newVoter);
                    Console.WriteLine("Избиратель добавлен перед указанным.");
                }

                // Метод для удаления избирателя из списка
                static void RemoveVoter(VoterList voterList)
                {
                    Console.Write("Введите ФИО избирателя для удаления: ");
                    string fullName = Console.ReadLine();

                    Voter voterToRemove = FindVoterByFullName(voterList, fullName);
                    if (voterToRemove == null)
                    {
                        Console.WriteLine("Избиратель не найден.");
                        return;
                    }

                    voterList.Remove(voterToRemove);
                    Console.WriteLine("Избиратель удален.");
                }



                // Метод для поиска избирателя по полному имени
                static Voter FindVoterByFullName(VoterList voterList, string fullName)
                {
                    return voterList.Find(x => x.FullName == fullName);
                }


                // Метод для вывода избирателей по возрастным группам
                static void PrintByAgeGroup(VoterList voterList)
                {
                    Console.Write("Введите минимальный возраст: ");
                    int minAge = int.Parse(Console.ReadLine());
                    Console.Write("Введите максимальный возраст: ");
                    int maxAge = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nИзбиратели:");
                    voterList.PrintByAgeGroup(minAge, maxAge);
                }


                // Метод для вывода избирателей с негативным голосом в текущем году
                static void PrintNegativeOrAbstain(VoterList voterList)
                {
                    Console.Write("Введите текущий год: ");
                    int currentYear = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nИзбиратели с негативным голосом или воздержавшиеся:");
                    voterList.PrintNegativeOrAbstain(currentYear);
                }



                // Метод для создания нового списка избирателей по номеру участка
                static void FilterByPollingStation(VoterList voterList)
                {
                    Console.Write("Введите номер участка: ");
                    int pollingStationNumber = int.Parse(Console.ReadLine());

                    VoterList filteredList = voterList.FilterByPollingStation(pollingStationNumber);

                    Console.WriteLine("\nИзбиратели на указанном участке:");
                    filteredList.PrintAll();
                }



                // Метод для сохранения данных в бинарный файл
                static void SaveToFile(VoterList voterList)
                {
                    Console.Write("Введите имя файла для сохранения данных: ");
                    string fileName = Console.ReadLine();

                    voterList.SaveToFile(fileName);
                }



                // Метод для загрузки данных из бинарного файла
                static void LoadFromFile(VoterList voterList)
                {
                    Console.Write("Введите имя файла для загрузки данных: ");
                    string fileName = Console.ReadLine();

                    voterList.LoadFromFile(fileName);
                }









            }

        }
    }
}
