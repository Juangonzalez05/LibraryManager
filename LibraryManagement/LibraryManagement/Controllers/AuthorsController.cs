﻿using LibraryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public AuthorsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/Authors
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
		{
			return await _context.Authors.ToListAsync();
		}

		// GET: api/Authors/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Author>> GetAuthor(int id)
		{
			var author = await _context.Authors.FindAsync(id);

			if (author == null)
			{
				return NotFound();
			}

			return author;
		}

		// POST: api/Authors
		[HttpPost]
		public async Task<ActionResult<Author>> PostAuthor(Author author)
		{
			_context.Authors.Add(author);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
		}

		// PUT: api/Authors/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAuthor(int id, Author author)
		{
			if (id != author.Id)
			{
				return BadRequest();
			}

			_context.Entry(author).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AuthorExists(id))
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

		// DELETE: api/Authors/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAuthor(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AuthorExists(int id)
		{
			return _context.Authors.Any(e => e.Id == id);
		}
	}
}
