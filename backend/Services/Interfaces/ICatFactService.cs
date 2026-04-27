using backend.models;

namespace backend.services.interfaces
{
    public interface ICatFactService
    {
        Task<CatFact?> GetRandomCatFact();
    }
}