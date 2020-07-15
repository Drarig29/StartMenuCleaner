using System.IO;

namespace StartMenuCleaner {

    public class Helpers {

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
    }
}