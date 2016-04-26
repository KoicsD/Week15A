using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializing
{
    class Program
    {
        static string path = "person.dat";
        static BinaryFormatter formatter = new BinaryFormatter();

        static bool TryParseArgs(string[] args, out string name, out int year, out int month, out int day, out Person.EGender gender)
        {
            name = null; year = 0; month = 0; day = 0; gender = 0;
            if (args.Length != 5)
                return false;
            name = args[0];
            if (!int.TryParse(args[1], out year))
                return false;
            if (!int.TryParse(args[2], out month))
                return false;
            if (!int.TryParse(args[3], out day))
                return false;
            switch (args[4])
            {
                case "male":
                    gender = Person.EGender.Male;
                    break;
                case "female":
                    gender = Person.EGender.Female;
                    break;
                default:
                    return false;
            }
            return true;
        }

        static void Serialize(Person person)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, person);
            }
        }

        static void Main(string[] args)
        {
            string name;
            int year, month, day;
            Person.EGender gender;
            if (!TryParseArgs(args, out name, out year, out month, out day, out gender))
            {
                Console.WriteLine("You've mistyped something!\n(Incorrect number of arguments or invalid integer or gender)");
                return;
            }
            try
            {
                DateTime birthDate = new DateTime(year, month, day);
                Person personToSer = new Person(name, birthDate, gender);
                Serialize(personToSer);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid date!");
            }
            catch (IOException e)
            {
                Console.WriteLine("An IOException occurred. Type: {0}\nMessage:", e.GetType());
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unauthorized access. Message:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
