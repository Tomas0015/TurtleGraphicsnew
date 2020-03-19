﻿using Igor.Localization;
using Igor.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TurtleGraphics
{
    /// <summary>
    /// Interaction logic for LoadSaveDataDialog.xaml
    /// </summary>
    public partial class LoadSaveDataDialog : UserControl, INotifyPropertyChanged
    {

        #region Notifications

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        public string GenericCancel => LocaleProvider.Instance.Get(Locale.GENERIC_CANCEL);
        public string GenericLoad => LocaleProvider.Instance.Get(Locale.GENERIC_LOAD);

        public LoadSaveDataDialog()
        {
            InitializeComponent();
            DataContext = this;

            CancelCommand = new Command(() =>
            {
                MainWindow.Instance.Paths.Children.Remove(this);
                SelectedData = new SavedData() { Name = null };
                evnt.Set();
            });

            LoadCommand = new ParametrizedCommand((o) =>
            {
                SavedData d = (SavedData)o;
                SelectedData = d;
                MainWindow.Instance.Paths.Children.Remove(this);
                evnt.Set();
            });

            ItemList.Loaded += ItemList_Loaded;
        }

        private void ItemList_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ItemList.Focus();
        }

        private string _path;
        private ManualResetEventSlim evnt = new ManualResetEventSlim();

        private ObservableCollection<SavedData> _items = new ObservableCollection<SavedData>();
        private ICommand _cancelCommand;
        private ICommand _loadCommand;

        public ICommand LoadCommand { get => _loadCommand; set { _loadCommand = value; Notify(nameof(LoadCommand)); } }
        public ICommand CancelCommand { get => _cancelCommand; set { _cancelCommand = value; Notify(nameof(CancelCommand)); } }
        public ObservableCollection<SavedData> Items { get => _items; set { _items = value; Notify(nameof(Items)); } }

        public SavedData SelectedData { get; set; }

        public string Path
        {
            get => _path; set
            {
                _path = value;
                DirectoryInfo info = new DirectoryInfo(value);
                FileInfo[] files = info.GetFiles("*" + FileSystemManager.EXTENSION);
                foreach (FileInfo finfo in files)
                {
                    string text = File.ReadAllText(finfo.FullName);
                    int lineIndex = text.IndexOf('\r');
                    Items.Add(new SavedData() { Name = text.Substring(0, lineIndex), Code = text.Substring(lineIndex + 2) });
                }
            }
        }

        public async Task<SavedData> Select()
        {
            bool bck = MainWindow.Instance.ShowTurtleCheckBox;
            MainWindow.Instance.ShowTurtleCheckBox = false;
            evnt.Reset();
            await Task.Run(evnt.Wait);
            MainWindow.Instance.ShowTurtleCheckBox = bck;
            return SelectedData;
        }
    }
}
