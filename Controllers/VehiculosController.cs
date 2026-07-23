using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehiculosController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        public VehiculosController(ConcesionariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Vehiculo>>>> GetVehiculos()
        {
            var vehiculos = await _context.Vehiculos
                .AsNoTracking()
                .ToListAsync();

            return Ok(new ApiResponse<IEnumerable<Vehiculo>>
            {
                Success = true,
                Message = "Vehículos obtenidos correctamente.",
                Data = vehiculos
            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<Vehiculo>>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VehiculoId == id);

            if (vehiculo == null)
            {
                return NotFound(new ApiResponse<Vehiculo>
                {
                    Success = false,
                    Message = "No se encontró el vehículo solicitado.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<Vehiculo>
            {
                Success = true,
                Message = "Vehículo obtenido correctamente.",
                Data = vehiculo
            });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Vehiculo>>> PostVehiculo(
            Vehiculo vehiculo)
        {
            var matriculaNormalizada = vehiculo.Matricula.Trim().ToUpper();

            var matriculaExiste = await _context.Vehiculos
                .AnyAsync(v => v.Matricula.ToUpper() == matriculaNormalizada);

            if (matriculaExiste)
            {
                return Conflict(new ApiResponse<Vehiculo>
                {
                    Success = false,
                    Message = "Ya existe un vehículo con esa matrícula.",
                    Data = null
                });
            }

            var concesionarioExiste = await _context.Concesionarios
                .AnyAsync(c => c.ConcesionarioId == vehiculo.ConcesionarioId);

            if (!concesionarioExiste)
            {
                return BadRequest(new ApiResponse<Vehiculo>
                {
                    Success = false,
                    Message = "El concesionario seleccionado no existe.",
                    Data = null
                });
            }

            if (vehiculo.PrecioVenta < vehiculo.PrecioCompra)
            {
                return BadRequest(new ApiResponse<Vehiculo>
                {
                    Success = false,
                    Message = "El precio de venta no puede ser menor que el precio de compra.",
                    Data = null
                });
            }

            vehiculo.Matricula = matriculaNormalizada;

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetVehiculo),
                new { id = vehiculo.VehiculoId },
                new ApiResponse<Vehiculo>
                {
                    Success = true,
                    Message = "Vehículo registrado correctamente.",
                    Data = vehiculo
                });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> PutVehiculo(
            int id,
            Vehiculo vehiculo)
        {
            if (id != vehiculo.VehiculoId)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El identificador de la ruta no coincide con el vehículo enviado.",
                    Data = null
                });
            }

            var vehiculoExistente = await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.VehiculoId == id);

            if (vehiculoExistente == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "No se encontró el vehículo que desea actualizar.",
                    Data = null
                });
            }

            var matriculaNormalizada = vehiculo.Matricula.Trim().ToUpper();

            var matriculaDuplicada = await _context.Vehiculos.AnyAsync(v =>
                v.VehiculoId != id &&
                v.Matricula.ToUpper() == matriculaNormalizada);

            if (matriculaDuplicada)
            {
                return Conflict(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Ya existe otro vehículo con esa matrícula.",
                    Data = null
                });
            }

            var concesionarioExiste = await _context.Concesionarios
                .AnyAsync(c => c.ConcesionarioId == vehiculo.ConcesionarioId);

            if (!concesionarioExiste)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El concesionario seleccionado no existe.",
                    Data = null
                });
            }

            if (vehiculo.PrecioVenta < vehiculo.PrecioCompra)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El precio de venta no puede ser menor que el precio de compra.",
                    Data = null
                });
            }

            vehiculoExistente.Marca = vehiculo.Marca;
            vehiculoExistente.Modelo = vehiculo.Modelo;
            vehiculoExistente.Color = vehiculo.Color;
            vehiculoExistente.Extras = vehiculo.Extras;
            vehiculoExistente.Combustible = vehiculo.Combustible;
            vehiculoExistente.TipoVehiculo = vehiculo.TipoVehiculo;
            vehiculoExistente.Estado = vehiculo.Estado;
            vehiculoExistente.Matricula = matriculaNormalizada;
            vehiculoExistente.Kilometraje = vehiculo.Kilometraje;
            vehiculoExistente.ConcesionarioId = vehiculo.ConcesionarioId;
            vehiculoExistente.PrecioCompra = vehiculo.PrecioCompra;
            vehiculoExistente.PrecioVenta = vehiculo.PrecioVenta;
            vehiculoExistente.Disponible = vehiculo.Disponible;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Vehículo actualizado correctamente.",
                Data = null
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "No se encontró el vehículo que desea eliminar.",
                    Data = null
                });
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Vehículo eliminado correctamente.",
                Data = null
            });
        }
    }
}