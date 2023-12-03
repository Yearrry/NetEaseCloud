using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetEase_clund_music.Db;
using NetEase_clund_music.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace NetEase_clund_music.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ContentCollection = new ObservableCollection<string>();
            contentParameters = new Dictionary<string, object[]>();

            QueryCommand = new RelayCommand(QueryBystr);
            LastContent = new RelayCommand(SwitchLastContent);
            NextContent = new RelayCommand(SwitchNextContent);

        }

        private void SwitchNextContent()
        {
            if(ContentCollection.Count > 1)
            {
                if(index + 1 >= ContentCollection.Count)
                {
                    return;
                }
                else
                {
                    ActivateControl(ContentCollection[index + 1], true);
                }
            }
        }

        private void SwitchLastContent()
        {
            if(ContentCollection.Count > 1)
            {
                if(index != 0)
                {
                    ActivateControl(ContentCollection[index - 1],false);
                }
            }
        }

        private void QueryBystr()
        {
            if (string.IsNullOrWhiteSpace(Condition))
            {
                return;
            }
            object[] parameters = { Condition };

            ActivateControl("QueryResultControl",parameters);
        }

        private FrameworkElement maincontent;

        public FrameworkElement Maincontent
        {
            get { return maincontent; }
            set { maincontent = value; RaisePropertyChanged(); }
        }

        private string condition;

        public string Condition
        {
            get { return condition; }
            set { condition = value;RaisePropertyChanged(); }
        }

        private song playSong;

        public song PlaySong 
        {
            get { return playSong; }
            set { playSong = value; RaisePropertyChanged(); }
        }

        private string playPath;

        public string PlayPath
        {
            get { return playPath; }
            set { playPath = value;RaisePropertyChanged(); }
        }


        public RelayCommand QueryCommand { get; set; }

        public RelayCommand LastContent { get; set; }

        public RelayCommand NextContent { get; set; }


        public ObservableCollection<string> ContentCollection { get; set; }
        public Dictionary<string,object[]> contentParameters { get; set; }

        public int index { get; set; } = -1;

        public async void ActivateControl(string obj)
        {
            ContentCollection.Add(obj);

            await SwitchContent(obj, new object[] {});
            index++;
        }

        public async void ActivateControl(string obj,object[] parameters)
        {
            if (!contentParameters.ContainsKey(obj))
            {
                ContentCollection.Add(obj);
                contentParameters.Add(obj, parameters);
            }
            else
            {
                if(!contentParameters.ContainsKey(string.Format("{0},{1}", obj, index + 1)))
                {
                    ContentCollection.Add(string.Format("{0},{1}", obj, index + 1));
                    contentParameters.Add(string.Format("{0},{1}", obj, index + 1), parameters);
                }
                else
                {
                    contentParameters[string.Format("{0},{1}", obj, index + 1)] = parameters;
                }
            }

            await SwitchContent(obj, parameters);
            index++;
        }


        public Task SwitchContent(string obj,object[] parameters)
        {
            Type type = obj.Contains("NetEase_clund_music") ? Type.GetType(obj) : Type.GetType("NetEase_clund_music.Views." + obj.ToString());

            if (parameters.Length > 0)
            {
                ConstructorInfo cti = type.GetConstructor(Type.GetTypeArray(parameters));
                Maincontent = (FrameworkElement)cti.Invoke(parameters);
            }
            else
            {
                ConstructorInfo cti = type.GetConstructor(Type.EmptyTypes);
                Maincontent = (FrameworkElement)cti.Invoke(null);
            }

            return Task.CompletedTask;
        }


        public async void ActivateControl(string obj,bool order)
        {
            object[] parameters = { };

            if(contentParameters.TryGetValue(obj,out parameters))
            {
                if(obj.Split(',').Length > 1)
                {
                    obj = obj.Split(',')[0];
                }
                await SwitchContent(obj, parameters);
            }
            else
            {
                await SwitchContent(obj, parameters);
            }
           
            if (order)
            {
                index++;
            }
            else
            {
                index--;
            }
        }

        public static SongData ChangePalySong()
        {
            SongData sd = localDb.GetSong(1);

            return sd;
        }

        public void shixxii()
        {
            return;
        }

        public bool IsFm { get; set; }

    }
}