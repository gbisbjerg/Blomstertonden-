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
    public class PaymentTypesController : ApiController
    {
        private BlomsterTondenDBContext db = new BlomsterTondenDBContext();

        // GET: api/PaymentTypes
        public IQueryable<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes.Include(x => x.Orders);
        }

        // GET: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult GetPaymentType(int id)
        {
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // PUT: api/PaymentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentType(int id, PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.Id)
            {
                return BadRequest();
            }

            db.Entry(paymentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        // POST: api/PaymentTypes
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult PostPaymentType(PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentTypes.Add(paymentType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentType.Id }, paymentType);
        }

        // DELETE: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult DeletePaymentType(int id)
        {
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            db.PaymentTypes.Remove(paymentType);
            db.SaveChanges();

            return Ok(paymentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentTypeExists(int id)
        {
            return db.PaymentTypes.Count(e => e.Id == id) > 0;
        }
    }
}