using Microsoft.AspNetCore.Mvc;
using espacioPresupuestoRepository;
using espacioPresupuestos;
using espacioPresupuestosDetalle;
namespace tl2_tp5_2024_GonzaSanPla.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository presupuestoRepositorio= new PresupuestoRepository();
    private Presupuesto presupuesto = new Presupuesto();
    private PresupuestoDetalle detalle= new PresupuestoDetalle();

    [HttpPost("Cargar presupuesto")]  
    public ActionResult cargarPresupuesto(string nombreDestinatario,string fechaCreacion) // Hago que ingrese la fecha o uso la fecha actual? 
    {
        presupuesto.NombreDestinatario=nombreDestinatario;
        presupuesto.FechaCreacion=fechaCreacion;
        presupuestoRepositorio.CrearNuevoPresupuesto(presupuesto);
        return Created();
    }

    [HttpPost("Cargar detalles presupuesto")]  
    public ActionResult cargarPresupuestoDetalle(int idPrespuesto,int idProducto,int cantidad) // El idProducto mando como int o mando el producto? Se qchequea que el producto existe?
    {
        detalle.Cantidad=cantidad;
        detalle.Producto.IdProducto=idProducto;
        presupuestoRepositorio.CrearNuevoDetalle(idPrespuesto,detalle);
        return Created();
    }
    [HttpGet("Listar Productos")]
    public ActionResult<List<Presupuesto>> listarProducto()
    {
        return Ok(presupuestoRepositorio.ListarProductos());
    }
}
