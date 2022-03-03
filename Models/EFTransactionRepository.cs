﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Models
{
    public class EFTransactionRepository : ITransactionRepository
    {
        private BookstoreContext context;

        public EFTransactionRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Transaction> Transactions => context.Transactions.Include(x => x.Lines).ThenInclude(x => x.Book);


        public void SaveTransaction (Transaction transaction)
        {
            context.AttachRange(transaction.Lines.Select(x => x.Book));

            if (transaction.TransactionId == 0)
            {
                context.Transactions.Add(transaction);
            }

            context.SaveChanges();
        }
    }
}
