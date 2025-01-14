using System.Text;
using Rivella.Domain.Exceptions;
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
        var errorsBuilder = new StringBuilder();
        if (Code == Guid.Empty)
            errorsBuilder.Append("Código é obrigatório, ");

        if (string.IsNullOrWhiteSpace(Name))
            errorsBuilder.Append("Nome é obrigatório, ");

        if (QrCode.Length == 0)
            errorsBuilder.Append("QrCode é obrigatório, ");

        if (errorsBuilder.Length <= 0) 
            return;
        
        var errors = errorsBuilder
            .ToString()
            .TrimEnd();
            
        throw new RequiredFieldsException(
            errors.Remove(errors.Length - 1, 1)
        );

    }
    
    public void UpdateName(string name)
    {
        Name = name;
        Validate(); 
    }
}