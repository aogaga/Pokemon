
namespace PokeMonAPi.Services
{
    [Serializable]
    internal class DataRetrievalException : Exception
    {
        public DataRetrievalException()
        {
        }

        public DataRetrievalException(string? message) : base(message)
        {
        }

        public DataRetrievalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}