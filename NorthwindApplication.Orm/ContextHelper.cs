
namespace NorthwindApplication.Orm
{
    public static class ContextHelper
    {
        public static NorthwindEntities GetContext { get { return new NorthwindEntities(); } }
    }
}
