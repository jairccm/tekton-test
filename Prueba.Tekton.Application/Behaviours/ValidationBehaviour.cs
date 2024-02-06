﻿using FluentValidation;
using MediatR;
using ValidationException = Prueba.Tekton.Application.Exeptions.ValidationExecption;

namespace Prueba.Tekton.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationsResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context,cancellationToken)));
                var failures = validationsResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if(failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }

            }
            return await next();
        }
    }
}
