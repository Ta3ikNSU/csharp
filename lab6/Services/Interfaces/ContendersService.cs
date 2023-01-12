using lab6.DTO;

namespace lab6.Services.Interfaces;

public interface ContendersService
{
    bool isEmpty();

    public void Enqueue(ContenderDTO contenderDto);

    public int size();
}