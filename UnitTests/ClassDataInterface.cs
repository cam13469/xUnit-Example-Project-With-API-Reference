using System.Collections;

namespace UnitTests
{
   
    public class DataTemplate<T, U> : IEnumerable<object[]>
    {
        public List<Tuple<T, U>> _Data = new List<Tuple<T, U>>();

        public DataTemplate(T[] data, U[] expectedOuts)
        {
            if (data.Length != expectedOuts.Length)
            {
                throw new ArgumentException("The amount of data elements must match the number of expected outputs");
            }

            for (int i=0; i < data.Length; i++)
            {
                _Data.Add(Tuple.Create(data[i], expectedOuts[i]));
            }
        }

        public static V[] Data<V>(params V[] args)
        {
            return args;
        }
        
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (Tuple<T,U> dp in _Data)
            {
                yield return new object[] { dp.Item1, dp.Item2 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }   

}
