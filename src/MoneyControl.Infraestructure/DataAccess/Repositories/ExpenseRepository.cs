﻿using Microsoft.EntityFrameworkCore;
using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Repositories.Expenses;

namespace MoneyControl.Infraestructure.DataAccess.Repositories
{
    internal class ExpenseRepository(MoneyControlDbContext context) : 
        IExpensesWriteOnlyRepository, 
        IExpensesReadOnlyRepository, 
        IExpensesDeleteOnlyRepository,
        IExpensesUpdateOnlyRepository
    {

        private readonly MoneyControlDbContext _context = context;

        public async Task Add(Expense expense) => await _context.Expenses.AddAsync(expense);

        public async Task DeleteById(long id)
        {

            var expense = await _context.Expenses
            .FirstAsync(expense => expense.Id == id);

            _context.Expenses.Remove(expense);


        }

        public async Task<ICollection<Expense>> GetAll(long userId)
        {
            return await _context.Expenses
            .AsNoTracking()
            .Where(expense => expense.UserId == userId)
            .ToListAsync();
        }

        async Task<Expense?> IExpensesReadOnlyRepository.GetById(long id)
        {
            return await _context.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);
        }

        public async Task UpdateById(Expense expense)
        {
           
           _context.Expenses.Update(expense);

           
        }

        async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(long id)
        {
            return await _context.Expenses
            .FirstOrDefaultAsync(expense => expense.Id == id);
        }

        public async Task<ICollection<Expense>> FilterByMonth(DateOnly date)
        {

            var startDate = new DateTime(year:date.Year, month:date.Month, day:1).Date;

            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth).Date;

            return await _context.Expenses
             .AsNoTracking()
             .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
             .OrderBy(expense => expense.Date)
             .ThenBy(expense => expense.Title)
             .ToListAsync();
        }
    }
}
