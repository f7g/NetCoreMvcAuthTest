namespace Core.Models;

public abstract class BaseModel
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    private string _createdBy = null!;
    public string CreatedBy
    {
        get => _createdBy;
        set
        {
            if (string.IsNullOrEmpty(_createdBy)) _createdBy = value;
        }
    }
}
