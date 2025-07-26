namespace BookingComExample.Domain.Bookings;

public class DateRange
{
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    
    public int LenghtInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start>end)
        {
            throw new ApplicationException("Start date must be before end date");
        }
        
        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}