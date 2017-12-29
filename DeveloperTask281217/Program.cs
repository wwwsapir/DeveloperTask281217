using System;

namespace DeveloperTask281217
{
    public class Program
    {
        public static void Main()
        {
            fileSystemTestRun();
            Console.ReadLine(); // This line is here for the program to stop in Visual Studio so we can see the console output
        }

        private static void fileSystemTestRun()
        {
            FileSystem fileSystem = new FileSystem();
            fileSystem.AddDir(null, "dir1");
            fileSystem.AddFile("dir1", "file1_1", 11);
            fileSystem.AddDir("root", "dir2");
            fileSystem.AddDir("dir1", "dir1_1");
            fileSystem.AddFile("dir1_1", "file1_1_1", 111);
            fileSystem.AddFile("dir1_1", "fileToDelete1_1_2", 112);
            fileSystem.AddFile("dir1_1", "file1_1_3", 113); // Shouldn't show because it's later deleted before printing
            fileSystem.AddFile("root", "file1_1_3", 113);   // Shouldn't show because the name is duplication
            fileSystem.Delete("fileToDelete1_1_2");
            fileSystem.ShowFileSystem();
        }
    }
}
