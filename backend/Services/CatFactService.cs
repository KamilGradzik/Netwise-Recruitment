using backend.models;
using backend.services.interfaces;

namespace backend.services
{
    public class CatFactService : ICatFactService
    {   
        private readonly HttpClient _httpClient;
        private readonly IFileService _fileService;

        public CatFactService(HttpClient httpClient, IFileService fileSerivce)
        {
            _httpClient = httpClient;
            _fileService = fileSerivce;
        }
        public async Task<CatFact?> GetRandomCatFact()
        {
            try
            {   
                var response = await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
                if(response != null)
                {
                    _fileService.WriteLineToFile($"[{response.Length}] {response.Fact}\n");
                    return response;
                }    
                else return null;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}