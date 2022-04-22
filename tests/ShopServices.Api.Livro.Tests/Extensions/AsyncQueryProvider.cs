using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ShopServices.Api.Livro.Tests
{
    public class AsyncQueryProvider<T> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _query;

        public AsyncQueryProvider(IQueryProvider query)
        {
            _query = query;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new AsyncEnumerable<T>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AsyncEnumerable<TElement>(expression);
        }

        public object? Execute(Expression expression)
        {
            return _query.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _query.Execute<TResult>(expression);
        }

        public   TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            var tipo = typeof(TResult).GetGenericArguments()[0];
            var execucao = typeof(IQueryProvider)
                .GetMethod(
                    name: nameof(IQueryProvider.Execute),
                    genericParameterCount: 1,
                    types: new[] {typeof(Expression)}
                )
                .MakeGenericMethod(tipo)
                .Invoke(this, new[] { expression });

            return (TResult) typeof(Task).GetMethod(nameof(Task.FromResult))?
                .MakeGenericMethod(tipo).Invoke(null, new[] {execucao});

        }
    }
}