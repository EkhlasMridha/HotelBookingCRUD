using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreModel.Entities;

namespace Service.Extensions
{
    public static class Paginator
    {
        public static async Task<PaginatedData<TDocument>> ToPagedListAsync<TDocument>(this IQueryable<TDocument> source,int pageNumber, int pageSize, Expression<Func<TDocument, dynamic>> sortQuery) where TDocument : class
        {
            var result = await source.Skip((pageNumber - 1) * pageSize).OrderBy(sortQuery).Take(pageSize).ToListAsync();
            int total = source.Count();

            return new PaginatedData<TDocument>(result, total, pageNumber, pageSize);
        }
    }

    public class PaginatedData<TDocument>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalDocs { get; private set; }
        public List<TDocument> Result { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PaginatedData(List<TDocument> result, int totalDoc, int pageNumber, int pageSize)
        {
            TotalDocs = totalDoc;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalDoc / (double)pageSize);

            Result = result;
        }
    }
}
