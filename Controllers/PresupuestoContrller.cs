using Microsoft.AspNetCore.Mvc;
using espacioProducto;
using espacioProductoRepository;
namespace tl2_tp5_2024_GonzaSanPla.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private static ProductoRepository repositorioProducto = new ProductoRepository();
    Producto producto = new Producto();

    [HttpPost("Cargar producto")]   //No tendria que poner {producto}??? Para que sirve?
    public ActionResult cargarProduto(string descripcionProducto,int precio)
    {
        producto.Descripcion = descripcionProducto;
        producto.Precio = precio;
        repositorioProducto.CrearNuevo(producto);
        return Created();
    }

    [HttpGet("Listar Productos")]
    public ActionResult<List<Producto>> listarProducto()
    {
        return Ok(repositorioProducto.ListarProductos());
    }

    [HttpPut("Modificar Producto")] //No tendria que poner {id,producto}??? Para que sirve?
    
    public ActionResult modficarProducto(int id,string descripcionProducto,int precio )
    {
        producto.Descripcion=descripcionProducto;
        producto.Precio=precio;
        repositorioProducto.ModificarProducto(id,producto);
        return Ok();
    }

    [HttpGet("Obtener producto por id")]

    public ActionResult<Producto> ObtenerProdutoPorId(int id)
    {
        producto=repositorioProducto.ObtenerProductoPorId(id);
        if(producto.Descripcion==null)
        {
            return NotFound();
        }
        return Ok(producto);
    }
}
