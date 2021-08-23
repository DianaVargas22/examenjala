using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider, string separator)
        {
            data = provider.ProcessData(source,separator);
            currentPage = 1;
            this.pageSize = pageSize;
        }
        public void FirstPage()
        {
            currentPage = 0;
            
        }

        public void GoToPage(int page)
        {
            if(page > 0 && page< pageSize){
                currentPage = page;
            }else{
                throw new System.InvalidOperationException();
            }
        }

        public void LastPage()
        {
            currentPage = pageSize-1;
           // throw new System.NotImplementedException();
        }

        public void NextPage()
        {
            if(currentPage < pageSize){
                currentPage = currentPage++;
            }else{
                throw new System.NotImplementedException();
            }
        }

        public void PrevPage()
        {
            if(currentPage >= 1){
                currentPage = --currentPage;
            }else{
                throw new System.InvalidOperationException();
            }
            
        }

        public IEnumerable<string> GetVisibleItems(int number)
        {
            return data.Skip(currentPage*pageSize).Take(number);
        }
        
        

        public int CurrentPage()
        {
            return currentPage;
           // throw new System.NotImplementedException();
        }

        public int Pages()
        {
            return pageSize;
            //throw new System.NotImplementedException();
        }
    }
}