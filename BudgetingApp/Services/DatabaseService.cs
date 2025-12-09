using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetingApp.Models;
using SQLite;

namespace BudgetingApp.Services
{
    public class DatabaseService
    {
        private readonly Task _initializeTask;
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _initializeTask = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Expense>();
        }


        // ----- CRUD -----

        public async Task<int> AddAsync<T>(T item) where T : new()
        {
            await _initializeTask;
            return await _database.InsertAsync(item);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : new()
        {
            await _initializeTask;
            return await _database.Table<T>().ToListAsync();
        }

    }
}
