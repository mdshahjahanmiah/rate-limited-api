using Agoda.HotelManagement.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Agoda.HotelManagement.Domain.Mappers
{
    public static class HotelMapper
    {
        public static DataObjects.Models.Hotel ToObject(this Hotel model) 
        {
            return new DataObjects.Models.Hotel()
            {
                HotelId = model.HotelId,
                City = model.City,
                Room = model.Room,
                Price = model.Price
            };
        }
    }

    public static class Test
    {
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool descending)
        {
            var result = descending? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
            return result;
        }
    }
    
}
