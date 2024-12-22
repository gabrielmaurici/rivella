using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public class Album : AggregateRoot<int>
{
    public Album(string name, DateTime revelationDate, int id = 0) : base(id)
    {
        Code = Guid.NewGuid();
        Name = name;
        RevelationDate = revelationDate;
        DateCreated = DateTime.Now;

        Validate();
    }

    public Guid Code { get; private set; }
    public string Name { get; private set; }
    public DateTime RevelationDate { get; private set; }
    public DateTime DateCreated { get; private set; }
    public virtual List<Photo> Photos { get; private set; } = [];
    
    private void Validate()
    {
        if (Code == Guid.Empty)
            throw new ArgumentException("Código é obrigatório", nameof(Code));

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Nome é obrigatório", nameof(Name));
    }
    
    public void UpdateName(string name)
    {
        Name = name;
        Validate(); 
    }
}