using System.Threading.Tasks;
using TransactionMicroserviceApi.Messages;

namespace TransactionMicroserviceApi.Dispatchers
{

    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }


}