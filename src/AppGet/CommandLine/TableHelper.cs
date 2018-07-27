﻿using System;
using System.Collections.Generic;
using AppGet.PackageRepository;
using AppGet.Update;

namespace AppGet.CommandLine
{
    public static class TableHelper
    {
        public static void ShowTable(this IEnumerable<PackageInfo> packages)
        {
            var table = new ConsoleTable("ID", "Name", "Version", "Tag");

            foreach (var package in packages)
            {
                table.AddRow(package.Id, package.Name, package.Version, package.Tag);
            }

            Print(table);
        }


        public static void ShowTable(this IEnumerable<PackageUpdate> updates)
        {
            var table = new ConsoleTable("Package ID", "Installed Version", "Available Version");

            foreach (var update in updates)
            {
                table.AddRow(update.PackageId, update.InstalledVersion, update.AvailableVersion);
            }

            Print(table);
        }


        private static void Print(ConsoleTable table)
        {
            Console.WriteLine();
            Console.WriteLine(table.ToMarkDownString());
            Console.WriteLine();
        }
    }
}
