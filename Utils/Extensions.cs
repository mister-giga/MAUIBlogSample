namespace Blogs.Utils;

public static class Extensions
{
    public static bool TryGetValue<Tk, Tv>(this IDictionary<Tk, object> values, Tk key, out Tv? value)
    {
        if (values.TryGetValue(key, out object? valueObj) && valueObj is Tv valueCasted)
        {
            value = valueCasted;
            return true;
        }

        value = default;
        return false;
    }
}
