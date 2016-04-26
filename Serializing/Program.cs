using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serializing
{
    class Program
    {
        static string path = "person.dat";
        static IFormatter formatter = new BinaryFormatter();
        enum Mode { Serialize, Deserialize }

        static bool TryParseArgs(string[] args, out Mode mode, out string name, out int year, out int month, out int day, out Person.EGender gender)
        {
            mode = 0; name = null; year = 0; month = 0; day = 0; gender = 0;
            switch (args.Length)
            {
                case 0:
                    mode = Mode.Deserialize;
                    return true;
                case 5:
                    mode = Mode.Serialize;
                    break;
                default:
                    return false;
            }
            name = args[0];
            if (!int.TryParse(args[1], out year))
                return false;
            if (!int.TryParse(args[2], out month))
                return false;
            if (!int.TryParse(args[3], out day))
                return false;
            switch (args[4].ToLower())
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

        static Person Deserialize()
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (Person)formatter.Deserialize(stream);
            }
        }

        static void Main(string[] args)
        {
            Mode mode;
            string name;
            int year, month, day;
            Person.EGender gender;
            if (!TryParseArgs(args, out mode, out name, out year, out month, out day, out gender))
            {
                Console.WriteLine("You've mistyped something!\n(Incorrect number of arguments or invalid integer or gender)");
                return;
            }
            try
            {
                switch (mode)
                {
                    case Mode.Serialize:
                        DateTime birthDate = new DateTime(year, month, day);
                        Person personToSer = new Person(name, birthDate, gender);
                        Console.WriteLine("Person to serialize:");
                        Console.WriteLine(personToSer);
                        Serialize(personToSer);
                        Console.WriteLine("Serialization succeeded!");
                        return;
                    case Mode.Deserialize:
                        Person personDeserd = Deserialize();
                        Console.WriteLine("Deserialization succeeded!");
                        Console.WriteLine("Person deserialized:");
                        Console.WriteLine(personDeserd);
                        return;
                }
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("An argument is out-of-range! Message:");
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File cannot be found: {0}", e.FileName);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unauthorized access! Message:");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("An IOException occurred! Type: {0}\nMessage:", e.GetType());
                Console.WriteLine(e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("A SerializationException occurred! Message:");
                Console.WriteLine(e.Message);
            }
            catch (ApplicationException e)
            {
                if (e is System.Reflection.TargetException || e is System.Reflection.TargetInvocationException || e is System.Reflection.TargetParameterCountException)
                {
                    Console.WriteLine("A reflection-related exception occurred (probably while deserializing)!");
                }
                else
                {
                    Console.WriteLine("Unknown Exception occurred!");
                }
                Console.WriteLine("Type: {0}", e.GetType());
                Console.WriteLine("Message:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Stack trace:");
                Console.WriteLine(e.StackTrace);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("A cast-exception occurred! Message:");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown Exception occurred!");
                Console.WriteLine("Type: {0}", e.GetType());
                Console.WriteLine("Message:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Stack trace:");
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
