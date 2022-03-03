﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore1.Models;
using BookStore1.Models.ViewModels;
using Bookstore1.Models.Infrastructure;

namespace BookStore1.Pages
{
    public class CartModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookStoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }



        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            
            cart.AddItem(b, 1);

           
            return RedirectToPage(new { ReturnUrl = returnUrl});


        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
