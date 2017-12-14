using System.ComponentModel;

namespace Stockbreeding.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}