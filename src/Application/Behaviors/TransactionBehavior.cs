using Core.Interfaces;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly UnitOfWork _unitOfWork;

        public TransactionBehavior(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var response = await next();

                if (typeof(TRequest).Name.EndsWith("Command"))
                {
                    if (response is IResult result)
                    {
                        if (result.IsSuccess)
                            await _unitOfWork.CommitTransactionAsync();
                        else
                            await _unitOfWork.RollbackTransactionAsync();
                    }
                }

                return response;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
