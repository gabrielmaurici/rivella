using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public sealed class Album : AggregateRoot<int>
{
    public Album(
        Guid code,
        string name,
        byte[] qrCode,
        DateTime revelationDate,
        int id = 0) : base(id)
    {
        Code = code;
        Name = name;
        QrCode = qrCode;
        RevelationDate = revelationDate;
        DateCreated = DateTime.Now;
        
        Validate();
    }

    public Guid Code { get; private init; }
    public string Name { get; private set; }
    public byte[] QrCode { get; private set; }
    public DateTime RevelationDate { get; private set; }
    public DateTime DateCreated { get; private set; }
    public List<Photo> Photos { get; private set; } = [];
    
    private void Validate()
    {
        if (Code == Guid.Empty)
            throw new ArgumentException("Código é obrigatório", nameof(Code));

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Nome é obrigatório", nameof(Name));
        
        if (QrCode == null || QrCode.Length == 0)
            throw new ArgumentException("QrCode é obrigatório", nameof(QrCode));
    }
    
    public void UpdateName(string name)
    {
        Name = name;
        Validate(); 
    }
}