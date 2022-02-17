﻿using System;
using System.Linq;

namespace BookStore1.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Books> Books { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
