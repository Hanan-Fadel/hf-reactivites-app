using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        //inside our handler we need access to data context
        //So using Dependency Injection we can inject the DataContext
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
        private readonly DataContext _context;

            public Handler(DataContext context)
            {

                _context = context;
                
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                //return the list of activities from Mediator handler
                //We use cancellationTokenm to be able to cancel a running request
                return await _context.Activities.ToListAsync();
               
            }
        }
    }
}