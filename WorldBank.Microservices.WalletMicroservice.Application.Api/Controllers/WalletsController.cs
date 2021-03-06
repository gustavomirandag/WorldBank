﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;
using WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Contexts;

namespace WorldBank.Microservices.WalletMicroservice.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly WalletContext _context;

        public WalletsController(WalletContext context)
        {
            _context = context;
        }

        // GET: api/Wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallets()
        {
            return await _context.Wallets.ToListAsync();
        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(Guid id)
        {
            var wallet = await _context.Wallets.FindAsync(id);

            if (wallet == null)
            {
                return NotFound();
            }

            return wallet;
        }

        // PUT: api/Wallets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallet(Guid id, Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(id))
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

        // POST: api/Wallets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid accountHolderId);
            if (!validId)
                return BadRequest("Not a valid AccountHolderId.");

            wallet.AccountHolderId = accountHolderId;
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallet", new { id = wallet.Id }, wallet);
        }

        // DELETE: api/Wallets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wallet>> DeleteWallet(Guid id)
        {
            var wallet = await _context.Wallets.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }

            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();

            return wallet;
        }

        private bool WalletExists(Guid id)
        {
            return _context.Wallets.Any(e => e.Id == id);
        }
    }
}
