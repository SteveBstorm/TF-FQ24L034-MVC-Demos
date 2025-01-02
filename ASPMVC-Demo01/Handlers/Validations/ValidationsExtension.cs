using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPMVC_Demo01.Handlers.Validations
{
    public static class ValidationsExtension
    {
        public static ModelStateDictionary ValidateTime(this ModelStateDictionary modelState, TimeOnly formField, string fieldName)
        {
            if(formField < new TimeOnly(8,0) || formField > new TimeOnly(19, 30))
            {
                modelState.AddModelError(fieldName, $"Attention : L'heure {formField} n'est pas compris entre 8:00 et 19:30");
            }
            return modelState;
        }

        public static ModelStateDictionary ValidateTime(this ModelStateDictionary modelState, TimeOnly formField, string fieldName, TimeOnly minTime, TimeOnly maxTime)
        {
            if (formField < minTime || formField > maxTime)
            {
                modelState.AddModelError(fieldName, $"Attention : L'heure {formField} n'est pas compris entre {minTime.ToShortTimeString()} et {maxTime.ToShortTimeString()}");
            }
            return modelState;
        }
        public static ModelStateDictionary ValidateDate(this ModelStateDictionary modelState, DateOnly formField, string fieldName)
        {
            if (formField < DateOnly.FromDateTime(DateTime.Now))
            {
                modelState.AddModelError(fieldName, $"Attention : La date doit être après la date d'aujourd'hui : {DateTime.Now.ToShortDateString()}");
            }
            return modelState;
        }
    }
}
