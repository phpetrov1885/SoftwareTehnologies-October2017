namespace TrainSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class TripController : Controller
    {
        private TrainSystemDbContext db = new TrainSystemDbContext();
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var trips = db.Trips.ToList();
            return View(trips);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(trip);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Trip trip)
        {
            var tripFromDb = db.Trips.Find(id);
            if (tripFromDb == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                tripFromDb.Origin = trip.Origin;
                tripFromDb.Destination = trip.Destination;
                tripFromDb.Business = trip.Business;
                tripFromDb.Economy = trip.Economy;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Edit", trip);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Trip tripModel)
        {
            var tripFromDb = db.Trips.Find(id);
            if (tripFromDb == null)
            {
                return HttpNotFound();
            }

            db.Trips.Remove(tripFromDb);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}