using System.Collections.Concurrent;
using lab6.DTO;
using lab6.Services.Interfaces;
using MassTransit;

namespace lab6.Services;

public class Consumer : IConsumer<ContenderDTO>
{
    private readonly ILogger<Consumer> _logger;

    private readonly ContendersService ContendersService;
    
    public Consumer(ILogger<Consumer> logger, ContendersService contendersService)
    {
        _logger = logger;
        ContendersService = contendersService;
        logger.LogInformation("create consumer");
    }

    public Task Consume(ConsumeContext<ContenderDTO> context)
    {
        _logger.LogInformation("Received Text: {Text}", context.Message.name);
        ContendersService.Enqueue(context.Message);
        _logger.LogInformation("size is {}", ContendersService.size());
        return Task.CompletedTask;
    }
}