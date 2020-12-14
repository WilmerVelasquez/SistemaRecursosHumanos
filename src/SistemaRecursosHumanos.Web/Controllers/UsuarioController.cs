using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRecursosHumanos.Core.Domain;
using SistemaRecursosHumanos.Infraestructure.Data;

namespace SistemaRecursosHumanos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly SistemaRecursosHumanosDbContext _context;

        public UsuarioController(SistemaRecursosHumanosDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var sistemaRecursosHumanosDbContext = _context.Usuario.Include(u => u.Aspnetusers).Include(u => u.IdEstadoNavigation).Include(u => u.IdHorarioNavigation).Include(u => u.IdSolicitudNavigation);
            return View(await sistemaRecursosHumanosDbContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Aspnetusers)
                .Include(u => u.IdEstadoNavigation)
                .Include(u => u.IdHorarioNavigation)
                .Include(u => u.IdSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario");
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion,IdHorario,IdSolicitud,IdEstado,AspnetusersId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", usuario.IdEstado);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", usuario.IdHorario);
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", usuario.IdSolicitud);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", usuario.IdEstado);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", usuario.IdHorario);
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", usuario.IdSolicitud);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion,IdHorario,IdSolicitud,IdEstado,AspnetusersId")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", usuario.IdEstado);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", usuario.IdHorario);
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", usuario.IdSolicitud);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Aspnetusers)
                .Include(u => u.IdEstadoNavigation)
                .Include(u => u.IdHorarioNavigation)
                .Include(u => u.IdSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
