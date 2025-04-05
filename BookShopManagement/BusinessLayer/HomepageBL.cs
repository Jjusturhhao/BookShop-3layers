using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HomepageBL
    {
        private HomepageDL HomepageDL;
        public HomepageBL()
        {
            HomepageDL = new HomepageDL();
        }

        public DataTable GetBooks(int page, int pageSize)
        {
            return HomepageDL.GetBooks(page, pageSize);
        }
        public DataTable GetCategories()
        {
            return HomepageDL.GetCategories();
        }
        
        public DataTable GetBooksByCategory(int page, int pageSize, string categoryId)
        {
            return HomepageDL.GetBooksByCategory(page, pageSize, categoryId);
        }

        public int GetTotalRecords(string categoryId = null)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                return HomepageDL.GetTotalRecords();
            }
            else
            {
                return HomepageDL.GetTotalRecordsByCategory(categoryId);
            }
        }
    }
}
