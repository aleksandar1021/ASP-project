using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation
{
    //public class GenerateChildren<T> where T : class, IHierarchicalEntity
    //{
    //    private readonly RecipeContext _context;

    //    public GenerateChildren(RecipeContext context)
    //    {
    //        _context = context;
    //    }

    //    public void FillChildCategories(T entity)
    //    {
    //        int id = entity.Id;

    //        entity.Children = _context.Set<T>()
    //                                  .Where(x => x.ParentId == id)
    //                                  .Cast<IHierarchicalEntity>()
    //                                  .ToList();

    //        foreach (T child in entity.Children)
    //        {
    //            FillChildCategories(child as T);
    //        }
    //    }
    //}


}

