using GenericScale;
internal class EqualityScale<T>
{
    T left;
    T right;
    public EqualityScale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }
    public bool AreEqual(T left, T right)
    {
        return left.Equals(right);
    }
}

