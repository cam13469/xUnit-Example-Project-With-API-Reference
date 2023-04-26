using System.Collections;

namespace UnitTests
{
    public partial class ClassDataFactory<T> : IEnumerable<T>
    {
        public IEnumerable<T>? Tests { get; set; }

        public T? expected;
        public IEnumerable<T> data;
        public ClassDataFactory(IEnumerable<T> data, T[] Args)
        {
            this.data = data;

            if (Args != null)
            {
                expected = Args[0];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Tests.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AddTests(IEnumerable<T> tests)
        {
            foreach (T data in tests)
            {
                Tests = Tests.Concat(new[] { data });
            }
        }

        public new Type GetType()
        {
            return typeof(IEnumerable<object[]>);
        }

        partial void MyMethod();
    }
}
