using FluentValidation.Results;

namespace Prueba.Tekton.Application.Exeptions
{
    public class ValidationExecption : ApplicationException
    {
        public ValidationExecption() : base("Existen un o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationExecption(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get;}
    }
}
