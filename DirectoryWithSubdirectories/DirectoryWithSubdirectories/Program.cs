using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryWithSubdirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = @""; // between "" enter path where new directories will be created
            CreateDirectories(root);

            Console.WriteLine("Press any key to continous");
            Console.ReadLine();
            
            Console.WriteLine("List of created folder with subfolders:");
            string rootPath = $@"{root}\Folder";
            var newDivs = FindDirectories(rootPath);
            
            var folderDepth = CountDirectoriesDepth(newDivs, rootPath);

            Console.WriteLine();
            Console.WriteLine($"Created Folder has {newDivs.Length} subfolders divided in {folderDepth} levels.");

            Console.ReadLine();
        }

        // Create new directories
        private static void CreateDirectories(string root)
        {
            List<string> directories = new List<string>();

            directories.Add(new string(@$"{root}\Folder"));
            directories.Add(new string(@$"{root}\Folder\Subfolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder1\SubSubFolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder1\SubSubSubFolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder2"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder2\SubSubSubFolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder2\SubSubSubFolder1\SubSubSubSubFolder1"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder2\SubSubSubFolder2"));
            directories.Add(new string(@$"{root}\Folder\Subfolder2\SubSubFolder3"));

            foreach (var directory in directories)
            {
                Directory.CreateDirectory(directory);
            }
        }

        // Find directories
        private static string[] FindDirectories(string path)
        {
            string []dirs = {};
            foreach (var dir in Directory.GetDirectories(path))
            {
                dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                Console.WriteLine(dir);
            }
                        
            foreach (var dir in Directory.GetDirectories(path))
            {
                FindDirectories(dir);
            }

            return dirs;
        }

        // Count structure depth of directory
        private static int CountDirectoriesDepth(string[] dirs, string basePath)
        {
            var depth = new List<int>();

            foreach (var dir in dirs)
            {
                depth.Add(dir.Count(x => x == '\\'));
            }
                                  
            return depth.Max() - basePath.Count(x => x == '\\') + 1;
        } 
    }
}
