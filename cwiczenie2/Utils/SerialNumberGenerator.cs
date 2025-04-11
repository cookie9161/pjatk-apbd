namespace CargoShip;

public abstract class SerialNumberGenerator
{
    private static long Id { get; set; }
    private static string _prefix = "KON";
    
    public static string GenerateSerialNumber()
    {
        var className = new System.Diagnostics.StackFrame(1).GetMethod()?.DeclaringType?.Name ?? "UnknownClass";
        
        ++Id;
        return $"{_prefix}-{className[0]}-{Id}"; 
    }
    
}