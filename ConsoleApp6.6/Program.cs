string fileName = "directory-of-employees.txt";

Console.WriteLine("Выберете вариант выполнения программы: \n1. Вывести данные на экран\n2. Заполнить данные и добавить в фаил");
int switch_on = Convert.ToInt32(Console.ReadLine());

switch (switch_on)
{
    case 1:
        if (File.Exists(fileName))
            ReadToFile();
        else
            Console.WriteLine("Фаил не найден(");
        break;
    case 2:
        InputToFile();
        break;
    default:
        Console.WriteLine("Введите 1 или 2");
        break;
}

void InputToFile()
{
    using (StreamWriter sw = new StreamWriter(fileName, true))
    {
        char key = 'y';
        do
        {
            string note = String.Empty;

            Console.WriteLine("\nВведите ID: ");
            int count = Convert.ToInt32(Console.ReadLine());
            note += $"{count}#";
            // note += $"\n{count}#";

            DateTime dateNow = DateTime.Now;
            note += dateNow.ToString() + "#";

            Console.WriteLine("\nВведите ФИО: ");
            note += $"{Console.ReadLine()}#";

            Console.WriteLine("\nВведите рост: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите дату рождения : ");
            DateTime bday = Convert.ToDateTime(Console.ReadLine());

            dateNow = DateTime.Today;
            int age = dateNow.Year - bday.Year;
            if (bday > dateNow.AddYears(-age)) age--;

            note += $"{age}#{height}#{bday.ToString("dd.MM.yyyy")}#";

            Console.WriteLine("\nВведите место рождения: ");
            note += $"{Console.ReadLine()}";

            sw.WriteLine(note);
            Console.Write("Продолжить y/n?");
            key = Console.ReadKey(true).KeyChar;

        } while (char.ToLower(key) == 'y');
    }
}

void ReadToFile()
{
    using (StreamReader sr = new StreamReader(fileName))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            line = line.Replace("#", " ");
            Console.WriteLine(line);
        }
    }
}