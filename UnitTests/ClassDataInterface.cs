using System.Collections;

namespace UnitTests
{
   
    public class DataTemplate<T, U> : IEnumerable<object[]>
    {
        public List<Tuple<T, U>> Data = new List<Tuple<T, U>>();

        public DataTemplate(T[] data, U[] expectedOuts)
        {
            if (data.Count() != expectedOuts.Count())
            {
                throw new ArgumentException("The amount of data elements must match the number of expected outputs");
            }

            for (int i=1; i < data.Count(); i++)
            {
                Data.Add(Tuple.Create(data[i], expectedOuts[i]));
            }
        }

        public static T[] New(params T[] args)
        {
            return args;
        }
        
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (Tuple<T,U> dp in Data)
            {
                yield return new object[] { dp.Item1, dp.Item2 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }   

}
