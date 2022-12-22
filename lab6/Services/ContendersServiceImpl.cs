using System.Collections.Concurrent;
using lab6.DTO;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class ContendersServiceImpl : ContendersService
{
    private ConcurrentQueue<ContenderDTO> ConcurrentQueue = new ConcurrentQueue<ContenderDTO>();
    
    public bool isEmpty()
    {
        return ConcurrentQueue.IsEmpty;
    }
    
    public void Enqueue(ContenderDTO contenderDto)
    {
        ConcurrentQueue.Enqueue(contenderDto);
    }

    public int size()
    {
        return ConcurrentQueue.Count;
    }
}