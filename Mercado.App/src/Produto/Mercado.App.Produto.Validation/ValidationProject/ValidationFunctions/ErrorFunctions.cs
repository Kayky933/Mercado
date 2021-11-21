using FluentValidation.Results;
using System.Linq;

namespace Mercado.App.Produto.Validation.ValidationFunctions
{
    public static class ErrorFunctions
    {
        public static object MostrarErros(ValidationResult res)
        {
            return res.Errors.Select(a => a.ErrorMessage).ToList();
        }
    }
}
