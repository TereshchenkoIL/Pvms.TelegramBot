using System.ComponentModel.DataAnnotations.Schema;

namespace Pvms.DAL.Entities;

public class UserStatistics
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    public DateTime StartDate { get; set; }

    public int StartCount { get; set; }
    
    public int BachelorCount { get; set; }
    
    public int MasterCount { get; set; }
    
    public int B121Count { get; set; }
    
    public int B122Count { get; set; }
    
    public int B123Count { get; set; }
    
    public int M121Count { get; set; }
    
    public int M122Count { get; set; }
    
    public int M123Count { get; set; }

    public void IncrementStatistic(string command)
    {
        switch (command)
        {
            case CommandConstants.Start:
                StartCount += 1;
                break;
            case CommandConstants.Bachelor:
                BachelorCount += 1;
                break;
            case CommandConstants.Master:
                MasterCount += 1;
                break;
            case CommandConstants.B121:
                B121Count += 1;
                break;
            case CommandConstants.B122:
                B122Count += 1;
                break;
            case CommandConstants.B123:
                B123Count += 1;
                break;
            case CommandConstants.M121:
                M121Count += 1;
                break;
            case CommandConstants.M122:
                M122Count += 1;
                break;
            case CommandConstants.M123:
                M123Count += 1;
                break;
        }
    }
}