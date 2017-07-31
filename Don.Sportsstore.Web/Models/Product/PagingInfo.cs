using System;

namespace Don.Sportsstore.Web.Models.Product
{
    public class PagingInfo
    {
  
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public PagingInfo(int currentPage, int itemsPerPage, int totalItems)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}