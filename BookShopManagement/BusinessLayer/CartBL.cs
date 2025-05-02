using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class CartBL
    {
        private static List<CartItem> cartItems;
        private CartDL cartDL;
        public CartBL()
        {
            cartItems = new List<CartItem>();
            cartDL = new CartDL();
        }
        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }
        public void ClearCart()
        {
            cartItems.Clear();  // Xóa toàn bộ các mục trong giỏ hàng
        }

        public void AddToCart(string bookID)
        {
            CartItem existing = null;

            foreach (CartItem item in cartItems)
            {
                if (item.BookID == bookID)
                {
                    existing = item;
                    break;  
                }
            }

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                CartItem item = cartDL.GetBookByID(bookID);

                if (item != null)
                {
                    cartItems.Add(item);
                }
            }
        }

        public void RemoveFromCart(string bookID)
        {
            CartItem itemToRemove = null;

            foreach (CartItem item in cartItems)
            {
                if (item.BookID == bookID)
                {
                    itemToRemove = item;
                    break;  // Dừng vòng lặp khi tìm thấy phần tử cần xóa
                }
            }

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove); 
            }
        }

        public int GetTotalAmount()
        {
            int totalAmount = 0;

            foreach (CartItem item in cartItems)
            {
                totalAmount += item.TotalPrice;  
            }

            return totalAmount;
        }
        
        // Tính tổng số lượng các sách trong giỏ hàng
        public int GetTotalQuantity()
        {
            int totalQuantity = 0;

            foreach (CartItem item in cartItems)
            {
                totalQuantity += item.Quantity;
            }
            return totalQuantity;
        }
        
    }
}
