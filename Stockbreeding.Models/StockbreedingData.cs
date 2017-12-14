using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stockbreeding.Models
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("StockbreedingData")]
    public class StockbreedingData : INotifyPropertyChanged
    {
        public StockbreedingData()
        {
            Flocks = new ObservableCollection<Flock>();
        }

        public void LoadFromXML(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            Flock[] flocksArray;
            XmlSerializer serializer = new XmlSerializer(typeof(Flock[]));

            using (StreamReader reader = new StreamReader(path))
            {
                try
                {
                    flocksArray = (Flock[])serializer.Deserialize(reader);
                }
                catch (InvalidOperationException e)
                {
                    return;
                }
            }

            Flocks = new ObservableCollection<Flock>(flocksArray);
        }
        public void SaveToXML(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Flock[]));

            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, Flocks.ToArray<Flock>());
            }
        }
        public void Clear()
        {
            Flocks.Clear();
        }

        public ObservableCollection<Flock> Flocks
        {
            get
            {
                return _flocks;
            }
            private set
            {
                _flocks = value;
                OnPropertyChanged("Flocks");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Flock> _flocks;
    }
}