using FreshMvvm;
using System;
using Ticket.PageModels;
using Ticket.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ticket
{
    public partial class App : Application
    {

        private static CustomerRepository _customerRepository;
        public static CustomerRepository CustomerRepository
        {
            get
            {
                if(_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository();

                }

                return _customerRepository;
            }
        }

        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.
                ResolvePageModel<ViewTablePageModel>();

            MainPage = new FreshNavigationContainer(page);
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
