namespace lab5.Services.Interfaces;

public interface HallService
{
    public string? getNextContender(int attemp_number);
    
    public Int32 getHusbandRating(int attemp_number);
}
