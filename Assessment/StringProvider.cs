using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {

        public IEnumerable<string> ProcessData(string source, string separator)
        {
            return source.Split(separator);
        }
    }
}