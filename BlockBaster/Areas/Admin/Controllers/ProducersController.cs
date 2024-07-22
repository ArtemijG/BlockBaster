using Microsoft.AspNetCore.Mvc;
using BlockBaster.Areas.Admin.Models;
using BlockBaster.Data;
using BlockBaster.Data.Entities;
using BlockBaster.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace BlockBaster.Areas.Admin.Controllers
{
    public class ProducersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;

        
        public ProducersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;

        }

        [HttpGet]
        public IActionResult ListProducers()
        {
            IQueryable<Producer> producer = _db.Producers/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;
            ProducerViewModel model = new ProducerViewModel
            {
                producers=producer
            };
            return View(model);

        }

        [HttpGet]
        public IActionResult AddProducer(int id)
        {
            var producer = id == default ? new Producer() : dataManager.Producer.GetProducerById(id);
            
            
            return View(producer);

        }

        [HttpPost]
        public IActionResult AddProducer(Producer producer, IFormFile imageFile, int id)
        {
            if (producer != null)
            {
                if (imageFile != null)
                {
                    producer.Path = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/Producers", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                }
                Producer p = new Producer
                { 
                    Id = id,
                    Path = producer.Path,
                    Name = producer.Name
                };
                dataManager.Producer.SaveProducer(p);
                return RedirectToAction(nameof(HomeController), nameof(HomeController).CutController());
            }
            return View(producer);

        }
    }
}
