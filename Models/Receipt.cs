namespace Models;
public class Receipt
{
    public int ReceiptNumber { get; set; }
    public DateTime EntryDateTime { get; set; }
    public DateTime ExitDateTime { get; set; }
    public decimal Fee { get; set; }
    public string Location { get; set; } = "";
    public string ErrorMessage { get; set; } = "";
}