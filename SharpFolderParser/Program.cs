namespace  SharpFolderParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a folder path:");
            string rootPath = @Console.ReadLine();

            while (!File.Exists(rootPath) && !Directory.Exists(rootPath))
            {
                Console.WriteLine("Invalid path. Please enter a valid file or folder path:");
                rootPath = @Console.ReadLine();
            }

            Console.WriteLine("Enter the output file path:");
            string outputPath = @Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                TraverseDirectory(rootPath, writer, 0);
            }

            Console.WriteLine("Done.");
        }

        static void TraverseDirectory(string path, StreamWriter writer, int level)
        {
            string[] files = Directory.GetFiles(path);
            string[] subdirectories = Directory.GetDirectories(path);

            writer.WriteLine(new string('\t', level) + Path.GetFileName(path) + "\\");

            foreach (string file in files)
            {
                writer.WriteLine(new string('\t', level + 1) + Path.GetFileName(file));
            }

            foreach (string subdirectory in subdirectories)
            {
                TraverseDirectory(subdirectory, writer, level + 1);
            }
        }
    }
}
