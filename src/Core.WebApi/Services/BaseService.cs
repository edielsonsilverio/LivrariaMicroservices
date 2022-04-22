using System.Net;
using System.Text;
using System.Text.Json;

namespace Core.WebApi;

public static class BaseService
{
    public static StringContent ObterConteudo(object dado)
    {
        return new StringContent(
            JsonSerializer.Serialize(dado),
            Encoding.UTF8,
            "application/json");
            
    }

    public static async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        
        return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
    }
 

    public static bool TratarErrosResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest) return false;

        response.EnsureSuccessStatusCode();
        return true;
    }

}
