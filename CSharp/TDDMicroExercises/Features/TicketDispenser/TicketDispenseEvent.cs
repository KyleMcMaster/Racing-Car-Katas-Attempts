using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TDDMicroExercises.Features.TicketDispenser
{
    public class TicketDispenseEvent : INotification
    {
        public TicketDispenseEvent(int turnNumber)
        {
            TurnNumber = turnNumber;
        }

        public int TurnNumber { get; }
    }

    public class UniqueNumberHandler : INotificationHandler<TicketDispenseEvent>
    {
        private readonly TicketContext ticketContext;

        public UniqueNumberHandler(TicketContext ticketContext)
        {
            this.ticketContext = ticketContext;
        }

        public async Task Handle(TicketDispenseEvent notification, CancellationToken cancellationToken)
        {
            var duplicateItem = await ticketContext.Tickets
                .FirstOrDefaultAsync(t => t.TurnNumber == notification.TurnNumber);

            if (duplicateItem != null)
            {
                throw new Exception("Duplicate number not allowed");
            }
        }
    }

    public class TicketDispenseLoggingHandler : INotificationHandler<TicketDispenseEvent>
    {
        private readonly ILogger<TicketDispenseEvent> logger;

        public TicketDispenseLoggingHandler(ILogger<TicketDispenseEvent> logger)
        {
            this.logger = logger;
        }

        public async Task Handle(TicketDispenseEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Ticket number {notification.TurnNumber} generated");
        }
    }
}
