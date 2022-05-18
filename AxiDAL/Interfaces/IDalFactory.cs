namespace AxiDAL.Interfaces
{
    public interface IDalFactory
    {
        public ICategoryDAL GetCategoryDal();
        public IOrderDAL GetOrderDal();
        public IOrderArticleDAL GetOrderArticleDal();
        public IRowDAL GetRowDal();
        public IShipmentArticleDAL GetShipmentArticleDAL();
        public IShipmentDAL GetShipmentDal();
        public IArticleDAL GetArticleDal();
        public ITestDAL GetTestDal();
    }
}