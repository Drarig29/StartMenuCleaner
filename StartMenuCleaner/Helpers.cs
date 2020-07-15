using System.IO;
using System.Windows.Controls;

namespace StartMenuCleaner {

    public static class Helpers {

        /// <summary>
        /// Moves all files from a parent folder to the corresponding Programs folder (except desktop.ini).
        /// </summary>
        public static void MoveFromParentToPrograms(string parent) {
            var files = Directory.GetFiles(parent, "*", SearchOption.TopDirectoryOnly);

            foreach (var file in files) {
                var fileName = Path.GetFileName(file);
                if (fileName == null || fileName == "desktop.ini") continue;

                var fileInfo = new FileInfo(file);
                fileInfo.MoveTo(Path.Combine(parent, Constants.PROGRAM_FOLDER, fileName));
            }
        }

        /// <summary>
        /// Generates a tree with files and folders starting from a root.
        /// </summary>
        /// <param name="root">The root directory.</param>
        /// <returns>The generated tree.</returns>
        public static TreeViewItem RecursiveTree(string root) {
            var item = new TreeViewItem {
                Header = root
            };

            var folders = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly);
            foreach (var folder in folders) {
                var tree = RecursiveTree(folder);
                item.Items.Add(tree);
            }

            var files = Directory.GetFiles(root, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in files) {
                if (Path.GetFileName(file) == "desktop.ini") continue;
                var fileItem = new TreeViewItem {Header = file};
                item.Items.Add(fileItem);
            }

            return item;
        }
    }
}