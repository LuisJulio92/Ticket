using Bogus;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket.Models;
using Xamarin.Forms;

namespace Ticket.PageModels
{

    public class CreateTicketPageModel : FreshBasePageModel
    {

        #region Constructores
        public override void Init(object initData)
        {
            GenerateNewCustomer();
            Refrest();
            
        }
        #endregion

        #region Property
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

        private Tick _newCustomer;
        public Tick NewCustomer
        {
            get { return _newCustomer; }
            set
            {
                _newCustomer = value;
                RaisePropertyChanged();
            }
        }

        private void GenerateNewCustomer()
        {
            NewCustomer = new Faker<Tick>()
                .RuleFor(x => x.Titulo, f => f.Person.FullName)
                .RuleFor(x => x.Description, f => f.Person.Address.Street)
                .Generate();
        }
        #endregion

        #region Command
        public ICommand SaveCommand => new Command(async () => await AddTiket());
        #endregion

        #region Metodos
        private async Task AddTiket()
        {
            App.CustomerRepository.AddOrUpdate(NewCustomer);
            Console.WriteLine(App.CustomerRepository.StatusMessage);
            GenerateNewCustomer();
            Refrest();
        }

        public void Refrest()
        {
            Tick = App.CustomerRepository.GetAll();
        }
        #endregion

    }
}
