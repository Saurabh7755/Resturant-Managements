using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Data;
using Restaurant.Web.Models;

namespace Resturant.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manage/OrderDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDetails.Include(o => o.MenuItem).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexNew()
        {
            var applicationDbContext = _context.OrderDetails.Include(o => o.MenuItem).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manage/OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.MenuItem)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: Manage/OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName");
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderNumber");
            ViewData["CustomerID"] = new SelectList(_context.Orders, "CustomerID", "CustomerName");
            return View();
        }

        // POST: Manage/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailId,OrderNumber,MenuItemId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderDetail.MenuItemId);
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderNumber", orderDetail.OrderNumber);
            return View(orderDetail);
        }

        // GET: Manage/OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderDetail.MenuItemId);
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderNumber", orderDetail.OrderNumber);
            return View(orderDetail);
        }

        // POST: Manage/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailId,OrderNumber,MenuItemId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailId))
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
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderDetail.MenuItemId);
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderNumber", orderDetail.OrderNumber);
            return View(orderDetail);
        }

        // GET: Manage/OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.MenuItem)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: Manage/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailId == id);
        }
    }
}
