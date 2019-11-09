using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(int currentPage, int totlaPages, int pageSize, int totalCount) 
        {
            this.CurrentPage = currentPage;
                this.TotlaPages = totlaPages;
                this.PageSize = pageSize;
                this.TotalCount = totalCount;
               
        }
                public int CurrentPage { get; set; }
        public int TotlaPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(List<T> items, int count, int pageNumber,int pageSize)
        {
            TotalCount = Count;
            PageSize = PageSize;
            CurrentPage = pageNumber;
            TotlaPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
            
        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize) {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}