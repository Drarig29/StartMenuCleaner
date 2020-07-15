using System;
using StartMenuCleaner.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace StartMenuCleaner {

    public static class Helpers {

        /// <summary>
        /// Moves all files from a parent folder to the corresponding Programs folder (except desktop.ini).
        /// </summary>
        public static void MoveFromParentToPrograms(string parent) {
            var files = Directory.GetFiles(parent, "*", SearchOption.TopDirectoryOnly);

            foreach (var file in files) {
                var filename = Path.GetFileName(file);
                if (filename == null || IsDesktopIni(filename)) continue;

                var fileInfo = new FileInfo(file);
                fileInfo.MoveTo(Path.Combine(parent, Constants.PROGRAM_FOLDER, filename));
            }
        }

        /// <summary>
        /// Generates a tree with files and directories starting from a root.
        /// </summary>
        /// <param name="root">The root directory.</param>
        /// <returns>The generated tree.</returns>
        public static DirectoryItem RecursiveTree(string root) {
            var directory = new DirectoryItem {
                Path = root,
                Filename = Path.GetFileName(root)
            };

            var directories = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly);
            foreach (var dir in directories) {
                var tree = RecursiveTree(dir);
                directory.Files.Add(tree);
            }

            var files = Directory.GetFiles(root, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in files) {
                var filename = Path.GetFileName(file);
                if (IsDesktopIni(filename)) continue;

                var fileItem = new FileItem {Filename = filename, Path = file};
                directory.Files.Add(fileItem);
            }

            return directory;
        }

        private static bool IsDesktopIni(string filename) {
            return Regex.IsMatch(filename, "desktop\\.ini", RegexOptions.IgnoreCase);
        }

        public static string AppDataFolder() {
            return Environment.ExpandEnvironmentVariables(Constants.APP_DATA_START_MENU);
        }

        public static string ProgramDataFolder() {
            return Constants.PROGRAM_DATA_START_MENU;
        }
    }
}