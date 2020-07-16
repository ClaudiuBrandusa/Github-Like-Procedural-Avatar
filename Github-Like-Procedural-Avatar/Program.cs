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

            generator.Generate();
            generator.SetColor("#eb4034"); // keep in mind that we need to set the color before we save/export, so then we can set the color after the generation
            generator.Save("test");
        }
    }
}
