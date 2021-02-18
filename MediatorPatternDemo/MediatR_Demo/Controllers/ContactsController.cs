using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IMediator mediator;
        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query) => await this.mediator.Send(query);

        #region NestedClasses

        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        //Implementing the IRequestHandler class ensures that this class is registered as a handler when the mediator sends a message with input and output matching supplied types
        public class ContactHandler : IRequestHandler<Query, Contact>
        { 
            private ContactsContext db;

            public ContactHandler(ContactsContext db) => this.db = db;

            //Handle is a method specifically relating to MediatR, the mediator knows to forward the request here and the response is automatically sent back to the caller
            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }

        }

        #endregion
    }
}
