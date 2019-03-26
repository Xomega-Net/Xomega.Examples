using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xomega.Framework;

namespace AdventureWorks.Services.Rest
{
    public static class ModelValidation
    {
        public static void AddModelErrors(ErrorList currentErrors, ModelStateDictionary modelState)
        {
            foreach (var ms in modelState)
            {
                foreach (var err in ms.Value.Errors)
                {
                    if (!string.IsNullOrEmpty(err.ErrorMessage))
                        currentErrors.AddValidationError(err.ErrorMessage);
                    else if (err.Exception != null)
                        currentErrors.AddValidationError(err.Exception.Message);
                }
            }
        }
    }
}