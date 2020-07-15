using System.Collections.ObjectModel;

namespace StartMenuCleaner.Model {

    public class DirectoryItem : FileItem {

        public DirectoryItem() {
            Files = new ObservableCollection<FileItem>();
        }

        public ObservableCollection<FileItem> Files { get; }
    }
}