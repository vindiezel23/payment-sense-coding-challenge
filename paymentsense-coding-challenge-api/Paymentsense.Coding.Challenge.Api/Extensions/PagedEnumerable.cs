using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Extensions
{
    public static class PagedEnumerable
    {
        public static IEnumerable<T> Paged<T>(this IEnumerable<T> data, int pageNumber, int pageSize)
        {
            if (data != null && pageNumber > 0 && pageSize >= pageNumber)
            {
                return data.Skip(pageNumber * pageSize).Take(pageSize);
            }

            return default;
        }
    }
}