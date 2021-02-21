using System;

namespace ClimaTempoSimples.Application.Common
{
    public class PaginationArgs
    {
        public static readonly int DEFAULT_PAGE_NUMBER = 1;
        public static readonly int DEFAULT_PAGE_SIZE = 10;

        public PaginationArgs(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? DEFAULT_PAGE_NUMBER : pageNumber;
            PageSize = pageSize < 1 ? DEFAULT_PAGE_SIZE : pageSize;
        }

        internal PaginationArgs(int pageNumber, int pageSize, int itemCount) : this(pageNumber, pageSize)
        {
            ItemCount = itemCount;
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int ItemCount { get; private set; }
        public int TotalPages { get { return (int)Math.Ceiling((double)ItemCount / PageSize); } }
    }
}
