﻿using MediatR;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Product
{
    public class Update
    {
        public class UpdateResult
        {
            public int ProductId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : Products, IRequest<UpdateResult>
        {

        }

        public class Handler : IRequestHandler<Command, UpdateResult>
        {
            private readonly CleanDbContext _context;
            public Handler(CleanDbContext context)
            {
                _context = context;
            }
            public async Task<UpdateResult> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Set<Products>().Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                return new UpdateResult
                {
                    ProductId = request.ProductId,
                    Messages    = "Update Completed"
                };
            }
        }
    }
}
