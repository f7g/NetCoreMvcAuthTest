namespace Core.Models;

public class ItemModel : BaseModel
{
    public int Id { get; set; }

    // Relationships
    public DataModel? Data;
}
