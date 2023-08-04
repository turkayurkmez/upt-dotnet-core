using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(IsExistsFilter))
        {
        }
    }
}
