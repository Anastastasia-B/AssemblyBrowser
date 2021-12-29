using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowser.Command;
using AssemblyBrowser.Model;

namespace AssemblyBrowser.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Assembly _assembly;
        public Assembly Assembly
        {
            get
            {
                return _assembly;
            }
            set
            {
                _assembly = value;
                OnPropertyChanged("Assembly");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
