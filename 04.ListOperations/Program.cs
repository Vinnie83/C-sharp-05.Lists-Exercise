using System;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();

                switch (arguments[0])
                {
                    case "Add":
                        int number = int.Parse(arguments[1]);
                        list.Add(number);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(arguments[1]);
                        int indexToInsert = int.Parse(arguments[2]);
                        if (IsNotValidIndex(indexToInsert, list.Count))
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        list.Insert(indexToInsert, numberToInsert);
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(arguments[1]);
                        if (IsNotValidIndex(indexToRemove, list.Count))
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        list.RemoveAt(indexToRemove);
                        break;
                    case "Shift":
                        string direction = arguments[1];
                        int count = int.Parse(arguments[2]);
                        Shift(list, direction, count);
                        break;

                }
            
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static bool IsNotValidIndex(int index, int count)
        {
            return index < 0 || index >= count;
        }

        private static void Shift(List<int> list, string direction, int count)
        {
            count %= list.Count;

            if (direction == "left")
            {
                List<int> shiftedPart = list.GetRange(0, count);
                list.RemoveRange(0, count);
                list.InsertRange(list.Count, shiftedPart);
            }
            else if (direction == "right")
            {
                List<int> shiftedPart = list.GetRange(list.Count - count, count);
                list.RemoveRange(list.Count - count, count);
                list.InsertRange(0, shiftedPart);
            }
        }


    }
}