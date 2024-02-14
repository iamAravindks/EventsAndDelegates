

namespace StudentList
{
    public class SortService<T> where T : class
    {

        public static void Sort(List<T> list, Comparison<T> comparison)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (comparison(list[i], list[i + 1]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
