namespace lab6.Services.Interfaces;

public interface HallService
{
    public string? getNextContender(int attemp_number);

    public int getHusbandRating(int attemp_number);
}
