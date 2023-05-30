﻿namespace WebApplication1.Application
{
    public class PagedList<T> : List<T>
    {

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> isPaggedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var round = source.Count();
            var items = source.Skip(pageNumber - 1).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

