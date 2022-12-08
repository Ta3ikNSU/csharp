
using lab4.DAO;

namespace lab4;

public class ChoiceAttemptDao
{

    public long Id { get; set; }
    public int NumberAttempt { get; set; }

    public ContenderDao ContenderDao { get; set; }
    
    public int Number { get; set; }
    
    public int Rating { get; set; }
}