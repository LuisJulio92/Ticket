using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket.Models;
using Xamarin.Forms;

namespace Ticket.PageModels
{


    public class ViewTablePageModel : FreshBasePageModel
    {
        #region Constructores
        public override void Init(object initData)
        {
            Refrest();

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


        private Tick selectedPerson;
        public Tick SelectedPerson
        {
            get => selectedPerson; set
            {
                selectedPerson = value;
                CoreMethods.PushPageModel<TicketDetailPageModel>(value);
            }
        }

        #endregion

        #region Command

        public ICommand CreateCommand => new Command(async () => await GoToCreateTable());


        #endregion

        #region Metodos
        private async Task GoToCreateTable()
        {
            await CoreMethods.PushPageModel<CreateTicketPageModel>();
        }
        public void Refrest()
        {
            Tick = App.CustomerRepository.GetAll();
        }
        #endregion



    }
}
