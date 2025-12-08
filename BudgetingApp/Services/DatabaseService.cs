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
        private readonly string _dbPath;
        private SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitializeAsync()
        {
            if (_database != null)
                return;

            _database = new SQLiteAsyncConnection(_dbPath);

            await _database.CreateTableAsync<Expense>();
        }


        // ----- CRUD -----

        public async Task<int> AddExpenseAsync(Expense expense)
        {
            InitializeAsync();
            return await _database.InsertAsync(expense);
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            InitializeAsync();
            return await _database.Table<Expense>().ToListAsync();
        }

    }
}
