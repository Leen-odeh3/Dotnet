using DotNet.Host.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DotNet.Host.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var stopwatch = Stopwatch.StartNew();

        var products = await _context.Products.ToListAsync();

        stopwatch.Stop();
        return Ok(new { TimeTaken = stopwatch.ElapsedMilliseconds, Products = products });
    }
}