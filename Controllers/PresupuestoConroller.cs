using Microsoft.AspNetCore.Mvc;
using espacioPresupuestoRepository;
using espacioProductoRepository;
using espacioPresupuestos;
using espacioPresupuestosDetalle;
using espacioProducto;
namespace tl2_tp5_2024_GonzaSanPla.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository presupuestoRepository = new PresupuestoRepository();
    private ProductoRepository productoRepository = new ProductoRepository();
    private Presupuesto presupuesto = new Presupuesto();
    public PresupuestoController()
    {

    }

    [HttpPost("CargarPresupuesto")]
    public ActionResult cargarPresupuesto(string nombreDestinatario, string fechaCreacion) // Hago que ingrese la fecha o uso la fecha actual? 
    {
        presupuesto.NombreDestinatario = nombreDestinatario;
        presupuesto.FechaCreacion = fechaCreacion;
        presupuestoRepository.CrearNuevoPresupuesto(presupuesto);
        return Created();
    }

    [HttpPost("CargarDetallesPresupuesto")]
    public ActionResult cargarPresupuestoDetalle(int idPrespuesto, int idProducto, int cantidad) // El idProducto mando como int o mando el producto? Se qchequea que el producto existe?
    {
        Producto nuevoProducto = new Producto();
        PresupuestoDetalle detalle = new PresupuestoDetalle();
        nuevoProducto = productoRepository.ObtenerProductoPorId(idProducto);
        detalle.Cantidad = cantidad;
        detalle.CargarProducto(nuevoProducto);
        presupuestoRepository.CrearNuevoDetalle(idPrespuesto, detalle);
        return Created();
    }
    [HttpGet("ListarPresupuestos")]
    public ActionResult<List<Presupuesto>> listarProducto()
    {
        return Ok(presupuestoRepository.ListarPresupuestos());
    }
}
