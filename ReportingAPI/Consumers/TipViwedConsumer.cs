using Contracts;
using MassTransit;
using ReportingAPI.DataAccess;
using ReportingAPI.DataAccess.Entities;

namespace ReportingAPI.Consumers
{
    public class TipViwedConsumer : IConsumer<TipViewedEvent>
    {
        private readonly AppDbContext _dbContext;

        public TipViwedConsumer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<TipViewedEvent> context)
        {
            var tip = new TipEvent()
            {
                TipId = context.Message.Id,
                ViewedOn = context.Message.ViewedOn
            };

            await _dbContext.AddAsync(tip);
            await _dbContext.SaveChangesAsync();
        }
    }
}
