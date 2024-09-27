using System.Reflection.Metadata.Ecma335;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main()
        {
            List<string> programme = Console.ReadLine().Split(", ").ToList();

            string input;
            
            while ((input = Console.ReadLine()) != "course start")
            {
                string[] commands = input.Split(":");

                switch (commands[0])
                {
                    case "Add":
                    programme = AddTitle(programme, commands[1]);
                        break;
                    case "Insert":
                    programme = InsertTitle(programme, commands[1], int.Parse(commands[2]));
                        break;
                    case "Remove":
                    programme = RemoveTitle(programme, commands[1]);
                        break;
                    case "Swap":
                    programme = SwapTitle(programme, commands[1], commands[2]);
                        break;
                    case "Exercise":
                    programme = InsertExercise(programme, commands[1]);
                        break;
                }
            }

            Console.WriteLine(PrintSchedule(programme));
        }

        private static string PrintSchedule(List<string> programme)
        {
            string result = "";
            for (int i = 0; i < programme.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{programme[i]}");
            }

            return result;
        }

        private static List<string> InsertExercise(List<string> programme, string title)
        {
            string exerciseTitle = $"{title}-Exercise";
            if (!programme.Contains(title))
            {
                AddTitle(programme, title);
            }

            if (programme.Contains(title) && !programme.Contains(exerciseTitle))
            {
                int index = programme.FindIndex(x => x == title);
                InsertTitle(programme, exerciseTitle, index + 1);
            }

            return programme;
        }

        private static List<string> SwapTitle(List<string> programme, string firstTitle, string secondTitle)
        {
            if (programme.Contains(firstTitle) && programme.Contains(secondTitle))
            {
                int firstIndex = programme.FindIndex(x => x == firstTitle);
                int secondIndex = programme.FindIndex(x => x == secondTitle);

                string temp = programme[firstIndex];
                programme[firstIndex] = programme[secondIndex];
                programme[secondIndex] = temp;

                programme = SwapExercise(programme, firstTitle, secondIndex);
                programme = SwapExercise(programme, secondTitle, firstIndex);
            }

            return programme;
        }

        private static List<string> SwapExercise(List<string> programme, string title, int titleIndex)
        {
            string exerciseTitle = $"{title}-Exercise";
            int index = programme.FindIndex(x => x == exerciseTitle);
            if (index >= 0)
            {
                RemoveTitle(programme, exerciseTitle);
                InsertTitle(programme, exerciseTitle, titleIndex + 1);
            }

            return programme;
        }

        private static List<string> InsertTitle(List<string> programme, string title, int index)
        {
            if (!programme.Contains(title))
            {
                programme.Insert(index, title);

            }

            return programme;

        }

        private static List<string> AddTitle(List<string> programme, string title)
        {
            if (!programme.Contains(title))
            {
                programme.Add(title);

            }

            return programme;
            
        }

        private static List<string> RemoveTitle(List<string> schedule, string title)
        {
            schedule.Remove(title);

            string exerciseTitle = $"{title}-Exercise";
            int index = schedule.FindIndex(x => x == exerciseTitle);
            if (index >= 0)
            {
                RemoveTitle(schedule, exerciseTitle);
            }

            return schedule;
        }


    }
}