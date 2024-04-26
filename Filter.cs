using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Xps.Serialization;
using Expression = System.Linq.Expressions.Expression;

namespace AnualLists.Helper
{
    public class Filter
    {
        //To use this filter correclty in Dictionary<string,string> parameters you must give as key value the name of the field and then as a value the value
        //by which you want to filter. You can pass empty dictionary aswell if you want to filter only by year. If your year field is not something like
        // Year,year,_year,year_ and its not int you cant filter by it.
        public static List<object> FilterByYearAndParameters<TEntity>(DbSet<TEntity> dbSet, int year,Dictionary<string,string> parameters) where TEntity : class
        {
            IQueryable<object> query = dbSet.Cast<object>();
            var properties = typeof(TEntity).GetProperties();
            var nameProperty = properties.FirstOrDefault(p => p.Name.ToLower().Contains("name") || p.Name.ToLower().Contains("_name"));
            var yearProperty = properties.FirstOrDefault(p => p.Name.ToLower().Contains("year") || p.Name.ToLower().Contains("_year") || p.Name.ToLower().Contains("year_"));
            string yearPropertyName = yearProperty.Name;
            if (year > 0)
            {
                query = query.Where(item => EF.Property<int>(item, yearPropertyName) == year);
            }

            if (nameProperty != null)
            {
                string namePropertyName = nameProperty.Name;
                var latestYears = dbSet
                    .Where(item => EF.Property<int>(item, yearPropertyName) <= year)
                    .GroupBy(item => EF.Property<string>(item, namePropertyName))
                    .Select(group => new
                    {
                        Name = group.Key,
                        LatestYear = group.Max(item => (int?)EF.Property<int>(item, yearPropertyName))
                    })
                    .ToList();

                foreach (var item in latestYears)
                {
                    string name = item.Name;
                    int? latestYear = item.LatestYear;

                    if (latestYear != null && latestYear <= year)
                    {
                        query = query.Union(dbSet.Where(entity => EF.Property<int>(entity, yearPropertyName) == latestYear && EF.Property<string>(entity, namePropertyName) == name));
                    }
                }
            }
            if(parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    var parameterName = parameter.Key;
                    var parameterValue = parameter.Value;

                    var property = properties.FirstOrDefault(p => p.Name.ToLower() == parameterName.ToLower());
                    if (property != null)
                    {
                        query = query.Where(entity => EF.Property<string>(entity, parameterName) == parameterValue);
                    }
                }
            }

            var queryToList = query.ToList();
            var orderedList = queryToList.OrderByDescending(x => x.GetType().GetProperty("Id").GetValue(x, null)).ToList();
            var result = orderedList.DistinctBy(x => x.GetType().GetProperty(nameProperty.Name).GetValue(x, null)).ToList();
            return result;
        }

    }
}
