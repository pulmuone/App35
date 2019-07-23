using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App35
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class Data
    {
        public Data(int i)
        {
            A += i;
            B += i;
            C += i;
            D += i;
            E += i;
            F += i;
            G += i;
        }

        private string a = "A";
        private string b = "B";
        private string c = "C";
        private string d = "D";
        private string e = "E";
        private string f = "F";
        private string g = "G";

        public string A { get => a; set => a = value; }
        public string B { get => b; set => b = value; }
        public string C { get => c; set => c = value; }
        public string D { get => d; set => d = value; }
        public string E { get => e; set => e = value; }
        public string F { get => f; set => f = value; }
        public string G { get => g; set => g = value; }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {

        public ICommand SearchCommand { get; private set; }
        private ObservableCollection<Data> testCollection = new ObservableCollection<Data>();
        private List<Data> testList = new List<Data>();

        public ObservableCollection<Data> TestCollection
        {
            get => testCollection;
            set
            {
                testCollection = value;
                OnPropertyChanged("TestCollection");
            }
        }

        public MainPageViewModel()
        {
            SearchCommand = new Xamarin.Forms.Command(Search);
        }

        private void Search()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            /* 데이터 채우는 데만 1분 27초
            for (int i = 0; i < 10000; i++)
            {
                testCollection.Add(new Data(i));
            }
            TestCollection.Add(new Data(10000));
            */

            TestCollection = null;
            
            //데이터 채우는 건 0.47초
            for (int i = 0; i < 10000; i++)
            {
                testList.Add(new Data(i));
            }
            TestCollection = new ObservableCollection<Data>(testList);

           // 이후 화면에 보여지는건 동일하게 대략 5초뒤에 보임. 2013년 안드로이 4.1폰
            sw.Stop();
            Debug.WriteLine("Time : " + sw.Elapsed);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
