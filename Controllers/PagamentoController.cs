using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConquerSite.Models;

namespace ConquerSite.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly string PIX_URL = "https://api.asaas.com";
        private readonly string PIX_KEY = "";
        private readonly string PIX_TOKEN = "";

  
        public IActionResult Index()
        {
            return View(new StoreModel()); 
        }

      
        [HttpPost]
        public async Task<IActionResult> Deposit(string username, int quantity)
        {
            if (quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "O valor deve ser maior que zero.");
                return View("Index", new StoreModel());
            }

            var foundPrice = 2;
            var totalValue = quantity * foundPrice;
            Console.WriteLine($"Total Value: {totalValue}");

            var qrCodeBase64 = await CreateQRCodeAsync(username, totalValue);

            if (string.IsNullOrEmpty(qrCodeBase64))
            {
                Console.WriteLine("Falha na geração do QR Code");
                ModelState.AddModelError("QrCode", "Erro ao gerar o QR Code.");
                return View("Index", new StoreModel { Price = quantity });
            }

            Console.WriteLine("QR Code gerado com sucesso!");

            var model = new StoreModel
            {
                Mount = quantity,
                QrCodeBase64 = qrCodeBase64
            };

            return View("Index", model);
        }

        private async Task<string> CreateQRCodeAsync(string username, int totalValue)
        {
            using (var client = new HttpClient())
            {
                var url = $"{PIX_URL}/v3/pix/qrCodes/static";
                var data = new
                {
                    addressKey = PIX_KEY,
                    value = totalValue,
                    format = "IMAGE",
                    externalReference = username
                };

                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                content.Headers.Add("access_token", PIX_TOKEN);

                client.DefaultRequestHeaders.Add("User-Agent", "ConquerSite/1.0 (Windows NT 10.0; en-US)");

                Console.WriteLine($"Request Body: {jsonData}");

                var response = await client.PostAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseBody}");

                if (response.IsSuccessStatusCode)
                {
                    var decodedResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var qrCodeBase64 = (string)decodedResponse?.encodedImage;

                    if (string.IsNullOrEmpty(qrCodeBase64))
                    {
                        Console.WriteLine("Resposta não contém a imagem do QR Code.");
                        return null;
                    }

                    return qrCodeBase64;
                }
                else
                {
                    Console.WriteLine($"Erro na chamada API: {response.StatusCode} - {responseBody}");
                    return null;
                }
            }
        }
    }
}
