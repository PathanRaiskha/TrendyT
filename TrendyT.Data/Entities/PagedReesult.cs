using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Entities
{
    public class PagedReesult<T>
    {
        public int TotalRecords { get; set; }
        public T Result { get; set; }
        public PagedReesult(T item,int totalRecords)
        {
                Result = item;
                TotalRecords = totalRecords;
        }
    }
}
