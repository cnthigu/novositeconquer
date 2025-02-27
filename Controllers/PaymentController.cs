using ConquerSite.Data;
using ConquerSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConquerSite.Controllers
{
    [Route("payment-approved")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Seu contexto do banco de dados

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ConfirmPayment([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest == null || paymentRequest.Payment == null)
            {
                return BadRequest(new { error = "Invalid JSON" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new { error = string.Join(", ", errors) });
            }

            var payment = paymentRequest.Payment;
            string paymentId = payment.Id;
            int paymentValue = payment.Value;
            string paymentUser = payment.ExternalReference;

            // Verifica se o usuário já existe na tabela de pagamentos
            var existingPaymentRecord = _context.payments
                .FirstOrDefault(p => p.username == paymentUser);

            if (existingPaymentRecord != null)
            {
                // Se o usuário já tiver um pagamento registrado, soma os founds
                existingPaymentRecord.founds += paymentValue;
                _context.payments.Update(existingPaymentRecord); // Atualiza o registro existente
            }
            else
            {
                // Se o usuário não tiver pagamento registrado, cria um novo
                var paymentRecord = new PaymentRecord
                {
                    id = paymentId,
                    founds = paymentValue,
                    username = paymentUser,
                    Date = DateTime.Now
                };

                _context.payments.Add(paymentRecord); // Adiciona um novo pagamento
            }

            _context.SaveChanges(); // Salva as alterações no banco

            // Retorna status 200
            return Ok(new { status = "success" });
        }
    }
}
