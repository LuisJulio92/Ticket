using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Models;

namespace Ticket.Services
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection =
                new SQLiteConnection(Constans.DatabasePath, Constans.Flags);
            connection.CreateTable<Tick>();
        }



        public void AddOrUpdate(Tick _tick)
        {
            int result = 0;
            try
            {
                if(_tick.Id != 0)
                {
                    result = connection.Update(_tick);
                    StatusMessage = string.Format($"{result} registro(s) Acualizado");
                }
                else
                {
                    result = connection.Insert(_tick);
                    StatusMessage = string.Format($"{result} registro(s) agregado(s)");
                }
            }
   
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Tick> GetAll()
        {
            try
            {  
                //.toList
                return connection.Table<Tick>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public Tick Get(int id)
        {

            try
            {
                return connection
                    .Table<Tick>()
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void Delete(int tickId)
        {
            try
            {
                var customer = Get(tickId);
                connection.Delete(customer);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }



    }
}
