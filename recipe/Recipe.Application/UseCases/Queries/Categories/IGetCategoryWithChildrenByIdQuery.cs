﻿using Recipe.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.Queries.Categories
{
    public interface IGetCategoryWithChildrenByIdQuery : IQuery<CategoryResponseWithChildrenDTO, TableIdDTO>
    {
    }
}
