using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThePieShop.Data;

namespace ThePieShop.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _appDbContext;

        private ShoppingCart(ApplicationDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        // how we ID the cart
        public string ShoppingCartId { get; set; }

        // to keep track of cart items
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        //returns instance of shoppingcart
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            // gives access to the context and in turn to the session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            // get access to AppDbContext session
            var context = services.GetService<ApplicationDbContext>();

            // if we don't have a cartId, create one
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };

        }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _appDbContext.SaveChanges();

        }


        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems =
                    _appDbContext.ShoppingCartItems
                       .Where(c => c.ShoppingCartId == ShoppingCartId)
                       .Include(s => s.Pie)
                       .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount)
                .Sum();
            return total;
        }
    }
}
