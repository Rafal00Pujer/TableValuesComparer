namespace TableValuesComparer;

internal class Body<TBody>(IEnumerable<TBody> childBodies) : IEquatable<Body<TBody>> where TBody : IEquatable<TBody>
{
    public IEnumerable<TBody> ChildBodies => childBodies;

    public bool Equals(Body<TBody>? other)
    {
        if (other is null)
        {
            return false;
        }

        return childBodies.SequenceEqual(other.ChildBodies);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Body<TBody>);
    }

    public override int GetHashCode()
    {
        return childBodies.Aggregate(new HashCode(), (acu, x) =>
        {
            acu.Add(x);
            return acu;
        }, x => x.ToHashCode());
    }

    public static bool operator ==(Body<TBody> a, Body<TBody> b) => a.Equals(b);

    public static bool operator !=(Body<TBody> a, Body<TBody> b) => !a.Equals(b);
}
