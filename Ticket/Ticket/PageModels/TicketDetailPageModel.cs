using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket.Models;
using Xamarin.Forms;

namespace Ticket.PageModels
{


    public class TicketDetailPageModel : FreshBasePageModel
    {
        #region Constructor
        public void Refrest()
        {
            Tick = App.CustomerRepository.GetAll();
        }
        #endregion

        #region Properties
        private List<Tick> _tick;
        public List<Tick> Tick
        {
            get { return _tick; }
            set
            {
                _tick = value;
                RaisePropertyChanged();
            }
        }

        public Tick Profile { get; set; }
        public override void Init(object initData)
        {
            if (initData is Tick)
            {
                Profile = initData as Tick;
            }
            //Refrest();
        }
        #endregion


        #region Command
        public ICommand updateCommand => new Command(async () => await UpdateTiket());
        //public ICommand DeteteCommand => new Command(async () => await Deleted());
        #endregion


        #region Method
        //private async Task Deleted()
        //{

        //}

        private async Task UpdateTiket()
        {
            App.CustomerRepository.AddOrUpdate(Profile);
            Console.WriteLine(App.CustomerRepository.StatusMessage);
            await CoreMethods.DisplayAlert("Note", "Updated register", "OK");
            Refrest();
        }
        #endregion


        


    }
}
