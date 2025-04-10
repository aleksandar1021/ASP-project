using Microsoft.EntityFrameworkCore;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases;
using Recipe.Application.UseCases.Queries.Comments;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Comments
{
    public class EfGetCommentsByIdQuery : EfUseCase, IGetCommentByIdQuery
    {
        public EfGetCommentsByIdQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 51;

        public string Name => "Search comments by Id";

        public CommentResponsWithChildrenForComments Execute(int data)
        {
            Comment c = Context.Comments.Include(x => x.Children).ThenInclude(x => x.Children).FirstOrDefault(x => x.Id == data);

            if(c == null)
            {
                throw new NotFoundException();
            }

            CommentResponsWithChildrenForComments dto = new()
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Text = c.Text,
                UserId = c.UserId,
                RecipeId = c.Id
            };

            

            FillChildrenOfParents(dto);

            return dto;

        }



        private void FillChildrenOfParents(CommentResponsWithChildrenForComments comment)
        {
            int id = comment.Id;

            comment.Childrens = Context.Comments.Where(x => x.ParentId == id).Select(c => new CommentResponsWithChildrenForComments
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Text = c.Text,
                UserId = c.UserId,
                RecipeId = c.Id

            }).ToList();


            foreach (CommentResponsWithChildrenForComments child in comment.Childrens)
            {
                FillChildrenOfParents(child);
            }
        }


    }
    
}
