using Jogo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jogo1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string[] opcoes = { "Pedra", "Papel", "Tesoura" };

        public IActionResult Index()
        {
            return base.View(new Models.Jogo());
        }

        [HttpPost]
        public IActionResult Jogar(int escolha)
        {
            Random random = new Random();
            int escolhaMaquina = random.Next(1, 4);
            var jogo = new Models.Jogo
            {
                EscolhaUsuario = opcoes[escolha - 1],
                EscolhaMaquina = opcoes[escolhaMaquina - 1],
            };

            if (escolhaMaquina == escolha)
            {
                jogo.Resultado = "Empate!";
            }
            else if ((escolha == 1 && escolhaMaquina == 3) ||
                     (escolha == 2 && escolhaMaquina == 1) ||
                     (escolha == 3 && escolhaMaquina == 2))
            {
                jogo.Resultado = "Você ganhou!";
            }
            else
            {
                jogo.Resultado = "O computador ganhou!";
            }

            return View("Index", jogo);
        }

    }
}
