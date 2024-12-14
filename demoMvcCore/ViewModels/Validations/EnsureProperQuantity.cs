using System;
using System.ComponentModel.DataAnnotations;
using demoMvcCore.Models;
using UseCases.ProductsUseCase;

namespace demoMvcCore.ViewModels.Validations
{
    public class EnsureProperQuantity : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesVM = validationContext.ObjectInstance as SalesViewModel;
            if (salesVM != null)
            {
                if (salesVM.QuantityToSell <= 0)
                {
                    return new ValidationResult("should be > 0");
                }
                else
                {
                
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;

                    if (getProductByIdUseCase != null)
                    {
                        var product = getProductByIdUseCase.Execute(salesVM.SelectedProductId);
                        if (product is not null && product.Quantity < salesVM.QuantityToSell)
                            return new ValidationResult($"{product.Name} only has {product.Quantity} left");
                    }
                    else
                    {
                        return new ValidationResult("Product doesnt exist");
                    }
                }
               
            }
            return ValidationResult.Success;
        }
    }
}
