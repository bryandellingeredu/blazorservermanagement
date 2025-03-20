
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAssemblyDemo.Client.Models;
using WebAssemblyDemo.Data;

namespace WebAssemblyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly DataContext _context;

        public ServersController(DataContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Servers.ToList());

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Server updatedServer)
        {
            if (id != updatedServer.ServerId)
            {
                return BadRequest("Server ID mismatch.");
            }

            var server = await _context.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound("Server not found.");
            }

            server.Name = updatedServer.Name;
            server.City = updatedServer.City;   
            server.IsOnline = updatedServer.IsOnline;

            _context.Entry(server).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Failed to update the server.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Server newServer)
        {
            if (newServer == null)
            {
                return BadRequest("Invalid server data.");
            }

            _context.Servers.Add(newServer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var server = await _context.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound("Server not found.");
            }

            _context.Servers.Remove(server);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
