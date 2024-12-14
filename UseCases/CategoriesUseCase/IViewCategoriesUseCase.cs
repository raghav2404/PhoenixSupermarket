using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
    public interface IViewCategoriesUseCase
    {

        IEnumerable<Category> Execute();


    }
}