namespace Tutorial6.Models;

public class ErrorResponseDto
{
    public int Status { get; set; }
    public string Error { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}