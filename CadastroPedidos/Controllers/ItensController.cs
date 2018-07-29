
//using System.Linq;
//using System.Web.Mvc;
//using CadastroPedidosCore.Context;
//using CadastroPedidosCore.Models;
//using CadastroPedidosCore.Context;

//namespace CadastroPedidos.Controllers
//{
//    public class ItensController : BaseController
//    {
//        private readonly DBContext _db;
//        private readonly IPedidoService _pedidoService;

//        public ItensController(DBContext db, IPedidoService pedidoService)
//        {
//            _db = db;
//            _pedidoService = pedidoService;
//        }

//        // GET: Item
//        public ActionResult ListarItens(int id)
//        {
//            var lista = _db.Itens.Where(m => m.Pedido.Id == id);
//            ViewBag.Pedido = id;
//            return PartialView(lista);
//        }

//        public ActionResult SalvarItens(int quantidade, string produto, decimal valorUnitario, int idPedido)
//        {
//            var item = new ItemPedido
//            {
//                Quantidade = quantidade,
//                Produto = produto,
//                ValorUnitario = valorUnitario,
//                Pedido = _db.Pedidos.Find(idPedido)
//            };

//            item.Quantidade = 10;

//            // Escrever o metodo correto. "factory method."
//            var i = Pedido.Novo(1, 2);

//            _db.Itens.Add(item);
//            _db.SaveChanges();

//            return Result(item.Id);
//        }

//        [HttpPost]
//        public ActionResult Excluir(int id, int idItem)
//        {
//            return Result(_pedidoService.ExcluirItem(id, idItem));
//        }
//    }

//    public abstract class BaseController : Controller
//    {
//        public JsonResult Result(object resultado)
//        {
//            return Json(RequestResponse.Create(resultado), JsonRequestBehavior.AllowGet);
//        }
//    }

//    public class RequestResponse
//    {
//        public object Resultado { get; private set; }

//        public static RequestResponse Create(object data)
//        {
//            return new RequestResponse
//            {
//                Resultado = data,
//            };
//        }
//    }

   

//    // Colocar na pasta Services e a interface na pasta interface ali
//}