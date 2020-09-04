﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phones.Data;
using Phones.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phones
{
    public class PhoneBusinessLogic
    {
        private PhonesContext Context;

        public PhoneBusinessLogic(PhonesContext context)
        {
            Context = context;
        }

        public IQueryable<Phone> GetProducts(PhoneSearchModel searchModel)
        {
            IQueryable<Phone> phonesQuery = Context.Phones.Include(p => p.Producer).AsQueryable().AsNoTracking();


            // If new search term comes in, then the PageIndex should reset to 1
            // Every new Filter (price, name, producername, etc.) needs to be added here
            if (searchModel.FilterByName != null || searchModel.FilterByPriceFrom != null || searchModel.FilterByProducerName != null)
            {
                searchModel.PageIndex = 1;
            }
            else
            {
                searchModel.FilterByName = searchModel.CurrentFilterByName;
                searchModel.FilterByPriceFrom = searchModel.CurrentFilterByPriceFrom;
                searchModel.FilterByProducerName = searchModel.CurrentFilterByProducerName;
            }

            // Producer names dropdown
            IQueryable<string> producerNameQuery = from p in Context.Producers
                                                   orderby p.ProducerName
                                                   select p.ProducerName;
            List<string> ProducerNames = producerNameQuery.Distinct().ToList();
            searchModel.ProducerNames = new SelectList(ProducerNames, searchModel.FilterByProducerName);


            if (searchModel != null)
            {
                // Filter by name
                if (!string.IsNullOrEmpty(searchModel.FilterByName))
                    phonesQuery = phonesQuery.Where(p => p.Name.Contains(searchModel.FilterByName));

                // Filter by PriceFrom
                if (searchModel.FilterByPriceFrom.HasValue)
                    phonesQuery = phonesQuery.Where(p => p.Price >= searchModel.FilterByPriceFrom);

                // Sort by price
                if (string.IsNullOrEmpty(searchModel.SortByPrice) && string.IsNullOrEmpty(searchModel.CurrentSort))
                {
                    searchModel.SortByPrice = "price_desc";
                }
                else if (searchModel.SortByPrice == "price_desc" || searchModel.CurrentSort == "price_desc")
                {
                    phonesQuery = phonesQuery.OrderByDescending(p => p.Price);
                    searchModel.SortByPrice = "price_asc";
                    searchModel.CurrentSort = "price_desc";
                }
                else if (searchModel.SortByPrice == "price_asc" || searchModel.CurrentSort == "price_asc")
                {
                    phonesQuery = phonesQuery.OrderBy(p => p.Price);
                    searchModel.SortByPrice = "price_desc";
                    searchModel.CurrentSort = "price_asc";
                }

                // Sort by name
                if (string.IsNullOrEmpty(searchModel.SortByName) && string.IsNullOrEmpty(searchModel.CurrentSort))
                {
                    searchModel.SortByName = "name_desc";
                }
                else if (searchModel.SortByName == "name_desc" || searchModel.CurrentSort == "name_desc")
                {
                    phonesQuery = phonesQuery.OrderByDescending(p => p.Name);
                    searchModel.SortByName = "name_asc";
                    searchModel.CurrentSort = "name_desc";
                }
                else if (searchModel.SortByName == "name_asc" || searchModel.CurrentSort == "name_asc")
                {
                    phonesQuery = phonesQuery.OrderBy(p => p.Name);
                    searchModel.SortByName = "name_desc";
                    searchModel.CurrentSort = "name_asc";
                }

                // Filter by ProducerName dropdown (SelectList)
                foreach (string name in ProducerNames)
                {
                    if (searchModel.FilterByProducerName == name)
                    {
                        phonesQuery = phonesQuery.Where(p => p.Producer.ProducerName == name);
                        break;
                    }
                }
            }



            return phonesQuery;
            //List<Phone> result = await phonesQuery.Include(p => p.Producer).ToListAsync();

            //return result;
        }
    }
}
