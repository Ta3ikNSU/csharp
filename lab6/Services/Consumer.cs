using System.Collections.Concurrent;
using lab6.DTO;
using lab6.Services.Interfaces;
using MassTransit;

namespace lab6.Services;

public class Consumer : IConsumer<ContenderDTO>
{
    private readonly ILogger<Consumer> _logger;

    private readonly ContendersService _contendersService;
    
    public Consumer(ILogger<Consumer> logger, ContendersService contendersService)
    {
        _logger = logger;
        _contendersService = contendersService;
        logger.LogInformation("create consumer");
    }

    public Task Consume(ConsumeContext<ContenderDTO> context)
    {
        _logger.LogInformation("Received Text: {Text}", context.Message.Name);
        _contendersService.Enqueue(context.Message);
        _logger.LogInformation("size is {}", _contendersService.size());
        return Task.CompletedTask;
    }
}