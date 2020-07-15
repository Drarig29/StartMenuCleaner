using System.Diagnostics;
using System.Windows;

namespace StartMenuCleaner {

    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
        }

        private void EmptyParentFolders_Click(object sender, RoutedEventArgs e) {
            Helpers.MoveFromParentToPrograms(Constants.APP_DATA_START_MENU);
            Helpers.MoveFromParentToPrograms(Constants.PROGRAM_DATA_START_MENU);
        }

        private void OpenAppDataFolder_Click(object sender, RoutedEventArgs e) {
            Process.Start("explorer", Constants.APP_DATA_START_MENU);
        }

        private void OpenProgramDataFolder_Click(object sender, RoutedEventArgs e) {
            Process.Start("explorer", Constants.PROGRAM_DATA_START_MENU);
        }

        private void BackupFolders_Click(object sender, RoutedEventArgs e) {
            
        }
    }
}