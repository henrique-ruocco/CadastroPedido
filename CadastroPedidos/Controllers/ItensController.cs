using CadastroPedidos.App_Start;
using CadastroPedidos.Context;
using CadastroPedidos.Models;
using System.Linq;
using System.Web.Mvc;

namespace CadastroPedidos.Controllers
{
    public class ItensController : BaseController
    {
        private readonly DBContext db;
        private readonly IPedidoService _pedidoService;

        public ItensController(DBContext db, IPedidoService pedidoService)
        {
            this.db = db;
            _pedidoService = pedidoService;
        }

        // GET: Item
        public ActionResult ListarItens(int id)
        {
            var lista = db.Itens.Where(m => m.Pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }

        public ActionResult SalvarItens(int quantidade, string produto, decimal valorUnitario, int idPedido)
        {
            var item = new Item()
            {
                Quantidade = quantidade,
                Produto = produto,
                ValorUnitario = valorUnitario,
                Pedido = db.Pedidos.Find(idPedido)
            };

            item.Quantidade = 10;

            // Escrever o metodo correto. "factory method."
            var i = Item.Novo(1, 2);

            db.Itens.Add(item);
            db.SaveChanges();

            return Result(item.Id);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            return Result(_pedidoService.ExcluirItem(id));
        }
    }

    public abstract class BaseController : Controller
    {
        public JsonResult Result(object resultado)
        {
            return Json(RequestResponse.Create(resultado), JsonRequestBehavior.AllowGet);
        }
    }

    public class RequestResponse
    {
        public object Resultado { get; private set; }

        public static RequestResponse Create(object data)
        {
            return new RequestResponse
            {
                Resultado = data,
            };
        }
    }

    public abstract class Service
    {
        protected readonly DBContext Db;

        public Service(DBContext db)
        {
            Db = db;
        }
    }

    // Colocar na pasta Services e a interface na pasta interface ali
    public class PedidoService : Service, IPedidoService
    {
        public PedidoService(DBContext db)
            : base(db)
        {
        }

        public bool ExcluirItem(int id)
        {
            var item = Db.Itens.Find(id);

            var result = false;

            if (item != null)
            {
                Db.Itens.Remove(item);
                Db.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}