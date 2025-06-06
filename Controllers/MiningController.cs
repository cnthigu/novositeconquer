﻿using Microsoft.AspNetCore.Mvc;
using ConquerSite.Data;
using System.Linq;
using ConquerSite.Models;

namespace ConquerSite.Controllers
{
    public class MiningController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiningController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.mined_items
                .OrderByDescending(i => i.mined_at) // Ordena por Timestamp, mais recentes primeiro
                .ToList();
            return View(items);
        }
    }
}