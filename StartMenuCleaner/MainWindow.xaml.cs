using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace StartMenuCleaner {

    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
            RefreshTree();
        }

        private void EmptyParentFolders_Click(object sender, RoutedEventArgs e) {
            Helpers.MoveFromParentToPrograms(Constants.APP_DATA_START_MENU);
            Helpers.MoveFromParentToPrograms(Constants.PROGRAM_DATA_START_MENU);
        }

        private void OpenAppDataFolder_Click(object sender, RoutedEventArgs e) {
            Process.Start("explorer", Helpers.AppDataFolder());
        }

        private void OpenProgramDataFolder_Click(object sender, RoutedEventArgs e) {
            Process.Start("explorer", Helpers.ProgramDataFolder());
        }

        private void RefreshTree_Click(object sender, RoutedEventArgs e) {
            RefreshTree();
        }

        private void RefreshTree() {
            var tree = Helpers.RecursiveTree(Path.Combine(Constants.PROGRAM_DATA_START_MENU, Constants.PROGRAM_FOLDER));
            fileTree.ItemsSource = tree.Files;
        }
    }
}