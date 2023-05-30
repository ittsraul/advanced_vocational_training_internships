﻿namespace WebApplication1.Application
{
    public class PaginationParameters
    {
        const int maxPageSize = 50;

        public int PageSize { get; set; } = 1;

        public int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public string? Sort {  get; set; }
    }
}
