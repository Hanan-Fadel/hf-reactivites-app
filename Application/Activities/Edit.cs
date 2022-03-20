using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest {
            public Activity Activity {get; set;}

        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper )
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                //We map a property into another property so it is better to use mapper to save us time
                //And to be more accurate
                // activity.Title = request.Activity.Title?? activity.Title;

                //using Mapper
                _mapper.Map(request.Activity, activity);

                await _context.SaveChangesAsync();

                //Just return nothing
                return Unit.Value;

            }
        }
    }
}