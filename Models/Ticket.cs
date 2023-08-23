namespace Models;
public class Ticket
{
    public int TicketNumber { get; set; }
    public int SpotNumber { get; set; }
    public DateTime EntryDateTime { get; set; }
    public String? Vehicle { get; set; } // Nullable property
    public String Location { get; set; } = ""; // Nullable property

}
