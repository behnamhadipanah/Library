using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Framework.Domain;

public class DomainBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; private set; }
    public bool IsActive { get; private set; }

    public DateTime CreationDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public DomainBase()
    {
        CreationDate = DateTime.Now;
        IsDeleted = false;
    }
    public void Deactive()
    {
        IsActive = false;
    }
    public void Activate()
    {
        IsActive = true;
    }
    public void Deleted()
    {
        IsDeleted = true;
    }
    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}