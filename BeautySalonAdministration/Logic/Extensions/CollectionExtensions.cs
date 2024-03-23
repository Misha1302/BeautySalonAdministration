namespace BeautySalonAdministration.Logic.Extensions;

using System.Collections;

public static class CollectionExtensions
{
    public static void Do(this int count, Action<int> act)
    {
        for (var i = 0; i < count; i++)
            act(i);
    }


    public static void ForEach<T>(this IList arr, Action<T, int> action)
    {
        for (var i = 0; i < arr.Count; i++)
            action((T)arr[i]!, i);
    }
}