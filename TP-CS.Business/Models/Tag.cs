using System.Diagnostics.SymbolStore;

namespace TP_CS.Business.Models;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public bool Iscomplete { get; set; }
    
    public long? TaskId { get; set; }
}