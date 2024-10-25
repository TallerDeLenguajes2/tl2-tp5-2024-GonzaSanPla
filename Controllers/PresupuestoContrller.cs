using Microsoft.AspNetCore.Mvc;
using espacioProducto;
using espacioProductoRepository;
namespace tl2_tp5_2024_GonzaSanPla.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    public static Producto producto =new Producto();
    private static ProductoRepository repositorioProducto= new ProductoRepository();
    
    // [HttpPost("Cargar producto")]
    // public ActionResult cargarProduto([FromBody]Producto nuevoProducto)
    // {

    //     return Ok(repositorioProducto.ListarProductos());
    // }

    [HttpGet("Listar Productos")]
    public ActionResult listarProducto()
    {
        return Ok(repositorioProducto.ListarProductos());
    }
}
