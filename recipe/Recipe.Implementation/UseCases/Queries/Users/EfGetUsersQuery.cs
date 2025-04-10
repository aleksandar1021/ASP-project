using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Search users";

        public PagedResponse<ResponseUserDataDTO> Execute(UserSearchDTO data)
        {
            var query = Context.Users.Include(x => x.UserUseCases).Include(x => x.Follows).AsQueryable();
                         

            if (data.UserId.HasValue)
            {
                query = query.Where(u => u.Id == data.UserId.Value);
            }

            if (!string.IsNullOrEmpty(data.FirstName))
            {
                query = query.Where(u => u.FirstName.ToLower().Contains(data.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(data.LastName))
            {
                query = query.Where(u => u.LastName.ToLower().Contains(data.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(data.Email))
            {
                query = query.Where(u => u.Email.ToLower().Contains(data.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(data.Username))
            {
                query = query.Where(u => u.Username.ToLower().Contains(data.Username.ToLower()));
            }

            if (data.UseCases != null && data.UseCases.Any())
            {
                query = query.Where(u => u.UserUseCases.Any(uc => data.UseCases.Contains(uc.UseCaseId)));
            }


            int totalCountOfLogs = query.Count();

            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseUserDataDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseUserDataDTO
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Username = x.Username,
                    Following = x.Follows.Count(u => u.UserId == x.Id),
                    Followers = x.Follows.Count(u => u.FollowId == x.Id),
                    UseCases = x.UserUseCases.Select(uc => uc.UseCaseId).ToList()
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
