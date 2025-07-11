using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed record LastName : ValueObject
{
    public string Name { get; }
    public static LastName Default => new();

    private LastName() => Name = "MaterializacaoEF";

    public LastName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValueObjectException<LastName>("Name", "Ultimo nome vazio");
        
        Name = name.ToUpper();
    }

    public override string ToString() => Name;
}