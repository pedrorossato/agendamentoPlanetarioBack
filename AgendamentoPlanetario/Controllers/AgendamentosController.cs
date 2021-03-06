﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoPlanetario.Database;
using AgendamentoPlanetario.Models;
using AgendamentoPlanetario.Services;

namespace AgendamentoPlanetario.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            try
            {
                return await _context.Agendamentos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Agendamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;
        }

        // PUT: Agendamentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Agendamentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
        {
            var agendamentoThatAlreadyExists = _context.Agendamentos.FirstOrDefault(a => a.DataHoraSessao == agendamento.DataHoraSessao);

            if (agendamentoThatAlreadyExists != null)
                return Conflict("Já existe um agendamento no mesmo horário.");

            try
            {
                _context.Agendamentos.Add(agendamento);
                await EmailService.SendEmail(agendamento);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAgendamento), new {id = agendamento.Id}, agendamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        // DELETE: Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return agendamento;
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }
    }
}
