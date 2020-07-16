using System.IO;
namespace Github_Like_Procedural_Avatar
{
    class Program
    {
        public static int width = 100; // default width
        public static int height = 100; // default height
        static void Main(string[] args)
        {
            Generator generator = new Generator(100, 100);

            Stream stream = new MemoryStream();

            generator.Export(stream);

            generator.Save("Avatar");
            generator.Generate();
            generator.Save("Avatar2");
            generator.Generate();
            generator.Save("Avatar3");
        }
    }
}
