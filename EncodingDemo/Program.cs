using System.IO;
using System.Text;

namespace EncodingDemo
{
    class Program
    {
        static string source = "C:\\Windows\\WindowsUpdate.log";
        static string dest = "WindowsUpdateutf7.txt";

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(source))
            {
                using (StreamWriter writer = new StreamWriter(dest, false, Encoding.UTF7))
                {
                    writer.Write(reader.ReadToEnd());
                }
            }
        }
    }
}
