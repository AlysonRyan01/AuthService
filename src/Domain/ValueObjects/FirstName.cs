using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed record FirstName : ValueObject
{
    public string Name { get; }
    public static FirstName Default => new();
    
    private FirstName() => Name = "MaterializacaoEF";

    public FirstName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValueObjectException<FirstName>("Name", "Primeiro nome vazio");
        
        Name = name.ToUpper();
    }

    public override string ToString() => Name;
}