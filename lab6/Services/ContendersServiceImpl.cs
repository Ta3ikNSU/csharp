using System.Collections.Concurrent;
using lab6.DTO;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class ContendersServiceImpl : ContendersService
{
    private ConcurrentQueue<ContenderDTO> _concurrentQueue = new ConcurrentQueue<ContenderDTO>();
    
    public bool isEmpty()
    {
        return _concurrentQueue.IsEmpty;
    }
    
    public void Enqueue(ContenderDTO contenderDto)
    {
        _concurrentQueue.Enqueue(contenderDto);
    }

    public int size()
    {
        return _concurrentQueue.Count;
    }
}