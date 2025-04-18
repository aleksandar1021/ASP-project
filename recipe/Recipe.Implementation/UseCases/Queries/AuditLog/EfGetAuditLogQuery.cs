﻿using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.AuditLogs;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.AuditLog
{
    public class EfGetAuditLogQuery : EfUseCase, IGetAuditLogQuery
    {
        public EfGetAuditLogQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get audit log (Executed use case)";

        public PagedResponse<AuditLogDTO> Execute(AuditLogSearchDTO dto)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(dto.Username))
            {
                query = query.Where(x => x.Username.Contains(dto.Username));
            }

            if (!string.IsNullOrEmpty(dto.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.Contains(dto.UseCaseName));
            }

            if (dto.DateFrom.HasValue)
            {
                query = query.Where(x => x.ExecutedAt > dto.DateFrom);
            }

            if (dto.DateTo.HasValue)
            {
                query = query.Where(x => x.ExecutedAt < dto.DateTo);
            }

            int totalCountOfLogs = query.Count();

            int perPage = dto.PerPage.HasValue ? (int)Math.Abs((double)dto.PerPage) : 5;
            int page = dto.Page.HasValue ? (int)Math.Abs((double)dto.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<AuditLogDTO>
            {
                Page = page,
                Data = query.Select(x => new AuditLogDTO
                {
                    Id = x.Id,
                    UseCaseName = x.UseCaseName,
                    Username = x.Username,
                    UseCaseData = x.UseCaseData,
                    ExecutedAt = x.ExecutedAt,
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
