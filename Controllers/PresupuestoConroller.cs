using Microsoft.AspNetCore.Mvc;
using espacioPresupuestoRepository;
using espacioPresupuestos;
namespace tl2_tp5_2024_GonzaSanPla.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository presupuestoRepositorio= new PresupuestoRepository();
    private Presupuesto presupuesto = new Presupuesto();

    [HttpPost("Cargar presupuesto")]  
    public ActionResult cargarProduto(string nombreDestinatario,string fechaCreacion) // Hago que ingrese la fecha o uso la fecha actual? 
    {
        presupuesto.NombreDestinatario=nombreDestinatario;
        presupuesto.FechaCreacion=fechaCreacion;
        presupuestoRepositorio.CrearNuevo(presupuesto);
        return Created();
    }
}
