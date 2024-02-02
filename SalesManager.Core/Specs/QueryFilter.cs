using System.Linq.Expressions;

namespace SalesManager.Core.Specs
{
	public record QueryFilter<T>(Expression<Func<T, bool>> Query = null!, int PageNumber = 1, int PageSize = 10)
    {
        public int Offset {
            get
            {
                return PageNumber < 2 ? 0 : (PageNumber - 1) * PageSize;
            }
        }
    }
}
