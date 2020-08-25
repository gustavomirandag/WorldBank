using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Contexts;
using WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Model;

namespace WorldBank.Microservices.WalletMicroservice.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly WalletContext _context;

        public CurrenciesController(WalletContext context)
        {
            _context = context;
        }

        // GET: api/DbCurrencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbCurrency>>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        // GET: api/DbCurrencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbCurrency>> GetDbCurrency(Guid id)
        {
            var dbCurrency = await _context.Currencies.FindAsync(id);

            if (dbCurrency == null)
            {
                return NotFound();
            }

            return dbCurrency;
        }

        // PUT: api/DbCurrencies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbCurrency(Guid id, DbCurrency dbCurrency)
        {
            if (id != dbCurrency.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbCurrencyExists(id))
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

        // POST: api/DbCurrencies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DbCurrency>> PostDbCurrency(DbCurrency dbCurrency)
        {
            _context.Currencies.Add(dbCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbCurrency", new { id = dbCurrency.Id }, dbCurrency);
        }

        // DELETE: api/DbCurrencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbCurrency>> DeleteDbCurrency(Guid id)
        {
            var dbCurrency = await _context.Currencies.FindAsync(id);
            if (dbCurrency == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(dbCurrency);
            await _context.SaveChangesAsync();

            return dbCurrency;
        }

        private bool DbCurrencyExists(Guid id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}
