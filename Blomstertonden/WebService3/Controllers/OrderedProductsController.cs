using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebService3;

namespace WebService3.Controllers
{
    public class OrderedProductsController : ApiController
    {
        private BlomsterTondenDBContxext db = new BlomsterTondenDBContxext();

        // GET: api/OrderedProducts
        public IQueryable<OrderedProduct> GetOrderedProducts()
        {
            return db.OrderedProducts;
        }

        // GET: api/OrderedProducts/5
        [ResponseType(typeof(OrderedProduct))]
        public IHttpActionResult GetOrderedProduct(int id)
        {
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            return Ok(orderedProduct);
        }

        // PUT: api/OrderedProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderedProduct(int id, OrderedProduct orderedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderedProduct.FK_Order)
            {
                return BadRequest();
            }

            db.Entry(orderedProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderedProducts
        [ResponseType(typeof(OrderedProduct))]
        public IHttpActionResult PostOrderedProduct(OrderedProduct orderedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderedProducts.Add(orderedProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderedProductExists(orderedProduct.FK_Order))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderedProduct.FK_Order }, orderedProduct);
        }

        // DELETE: api/OrderedProducts/5
        [ResponseType(typeof(OrderedProduct))]
        public IHttpActionResult DeleteOrderedProduct(int id)
        {
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            db.OrderedProducts.Remove(orderedProduct);
            db.SaveChanges();

            return Ok(orderedProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderedProductExists(int id)
        {
            return db.OrderedProducts.Count(e => e.FK_Order == id) > 0;
        }
    }
}