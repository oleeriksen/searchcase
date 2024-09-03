﻿using System;
using System.Collections.Generic;
using System.IO;
using Shared;

namespace Indexer
{
    public class App
    {
        public void Run(){
            IDatabase db = new Database();
            Crawler crawler = new Crawler(db);

            var root = new DirectoryInfo(Paths.FOLDER);

            DateTime start = DateTime.Now;

            crawler.IndexFilesIn(root, new List<string> { ".txt"});        

            TimeSpan used = DateTime.Now - start;
            Console.WriteLine("DONE! used " + used.TotalMilliseconds);

            var all = db.GetAllWordCounts();

            Console.WriteLine($"Indexed {db.GetDocumentCounts()} documents");
            Console.WriteLine($"Number of different words: {all.Count}");
            int count = 50;
            Console.WriteLine($"The first {count} is:");
            foreach (var p in all) {
                Console.WriteLine($"<{p.Id},{p.Value}> forekommer {p.Count} gange");
                count--;
                if (count == 0) break;
            }
        }
    }
}
