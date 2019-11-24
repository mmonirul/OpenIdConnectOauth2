using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.API.Services.Interfaces;

namespace WestPay.Access.API.Authorization
{
    public class SuperAdminOrOwnerHandler : AuthorizationHandler<SuperAdminOrOwnerRequirement>
    {
        private readonly IBookService _bookService;

        public SuperAdminOrOwnerHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SuperAdminOrOwnerRequirement requirement)
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            if(filterContext == null)
            {
                context.Fail();

                return Task.CompletedTask;
            }

            var bookId = filterContext.RouteData.Values["Id"].ToString();
            if (!Int32.TryParse(bookId, out int bookIdAsInt))
            {
                context.Fail();

                return Task.CompletedTask;
            }

            var authorId = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var role = context.User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            var bookServiceTask = Task.Run(async () => {
                return await _bookService.GetBookByIdAsync(bookIdAsInt);
            });
            var book = bookServiceTask.Result;

            if(book.AuthorId.ToString() == authorId || role == "admin")
            {
                context.Succeed(requirement);

                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
