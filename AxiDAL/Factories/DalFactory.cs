using System;
using AxiDAL.DAL;
using AxiDAL.Interfaces;

namespace AxiDAL.Factories
{
    public class DalFactory
    {
        private IServiceProvider serviceProvider;

        
        public DalFactory(IServiceProvider ServiceProvider)
        {
            serviceProvider = ServiceProvider;
        }

        public ITestDAL GetTestDal()
        {
            return (ITestDAL)serviceProvider.GetService(typeof(TestDAL));
        }

        public IArticleDAL GetArticleDal()
        {
            return (IArticleDAL)serviceProvider.GetService(typeof(ArticleDAL));
        }
        
        
        public ICategoryDAL GetCategoryDal()
        {
            return (ICategoryDAL)serviceProvider.GetService(typeof(CategoryDAL));
        }
        
    }
}

 