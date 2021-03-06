﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../";
            string sourceFileName = "sliceMe.mp4";
            string destinationFolder = "Sliced";
            Directory.CreateDirectory(Path.Combine(path, destinationFolder));

            string sourceFile = Path.Combine(path, sourceFileName);
            string destinationDirectory = Path.Combine(path, destinationFolder);

            Slice(sourceFile, destinationDirectory, 5);

            List<string> files = Directory.GetFiles(destinationDirectory).ToList();
            Assemble(files, destinationDirectory);
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string fullFilePath = Path.Combine(destinationDirectory, "assembled.mp4");
            FileStream fullFile = new FileStream(fullFilePath, FileMode.Create);
            foreach (var file in files)
            {
                FileStream currentFile = new FileStream(file, FileMode.Open);
                using (currentFile)
                {
                    byte[] buffer = new byte[currentFile.Length];
                    fullFile.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            FileStream source = new FileStream(sourceFile, FileMode.Open);

            using (source)
            {
                
                for (int i = 0; i < parts; i++)
                {
                    byte[] buffer = new byte[source.Length / parts];
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    string currentFile = Path.Combine(destinationDirectory, $"Part-{i}.mp4");
                    
                    FileStream slicedFile = new FileStream(currentFile, FileMode.Create);

                    using (slicedFile)
                    {
                        slicedFile.Write(buffer, 0, readBytes);
                    }
                }
            }
            
        }
    }
}
