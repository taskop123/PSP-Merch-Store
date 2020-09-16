using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSP_Merch_Store.Logic;
using PSP_Merch_Store.Models;

namespace PSP_Merch_Store.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        // GET: Products/Tshirts
        [AllowAnonymous]
        public ActionResult Tshirts()
        {
            var getAllProducts = db.Products.ToArray();
            var AllTshirts = new List<Products>();
            foreach(var item in getAllProducts)
            {
                if(item.ProductType == "Маици")
                {
                    AllTshirts.Add(item);
                }
            }
            return View(AllTshirts);
        }

        //GET: Products/Pants
        [AllowAnonymous]
        public ActionResult Pants()
        {
            var getAllProducts = db.Products.ToArray();
            var AllPants = new List<Products>();
            foreach (var item in getAllProducts)
            {
                if (item.ProductType == "Пантолони")
                {
                    AllPants.Add(item);
                }
            }
            return View(AllPants);
        }

        //GET: Products/Hats
        [AllowAnonymous]
        public ActionResult Hats()
        {
            var getAllProducts = db.Products.ToArray();
            var AllHats = new List<Products>();
            foreach (var item in getAllProducts)
            {
                if (item.ProductType == "Капи")
                {
                    AllHats.Add(item);
                }
            }
            return View(AllHats);
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var stringArray = new string[3] { "Маици", "Пантолони", "Капи" };
            ViewBag.ProductTypes = stringArray;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Products products)
        {
            /*if (ModelState.IsValid)
            {*/
                Products model = new Products();
                string _FileName = Path.GetFileName(products.Image.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                products.Image.SaveAs(_path);
                model.ProductType = products.ProductType;
                model.NameOfProduct = products.NameOfProduct;
                model.ImagePath = "/UploadedFiles/" + _FileName;
                model.Gender = products.Gender;
                model.Manufacturer = products.Manufacturer;
                model.Price = products.Price;
                model.Color = products.Color;
                model.Size = products.Size;
                model.Image = products.Image;
                model.Rating = products.Rating;

                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            /*}
            else
            {
                return View();
            }*/
           
        }

        //GET: Products/MaleProducts
        [AllowAnonymous]
        public ActionResult MaleProducts() 
        {
            string ProductType = Request.QueryString["ProductType"];
            var GetAllProducts = db.Products.ToList();
            var Male = new List<Products>();
            foreach(var item in GetAllProducts)
            {
                if(item.Gender.Contains("Машки") && item.ProductType == ProductType)
                {
                    Male.Add(item);
                    ViewBag.Type = ProductType;
                }
                else if(item.Gender.Contains("Машки") && ProductType == null)
                {
                    Male.Add(item);
                }
            }
            return View(Male);
        }
        //GET: Products/FemaleProducts
        [AllowAnonymous]
        public ActionResult FemaleProducts()
        {
            string ProductType = Request.QueryString["ProductType"];
            var GetAllProducts = db.Products.ToList();
            var Female = new List<Products>();
            foreach (var item in GetAllProducts)
            {
                if(item.Gender.Contains("Женски") && item.ProductType == ProductType)
                {
                    Female.Add(item);
                    ViewBag.Type = ProductType;
                }
                else if (item.Gender.Contains("Женски") && ProductType == null)
                {
                    Female.Add(item);
                }
            }
            return View(Female);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Search Result
        [AllowAnonymous]
        public ActionResult Search()
        {
            string ProductName = Request.QueryString["ProductName"];
            ApplicationDbContext _db = new ApplicationDbContext();
            var GetAllProducts = _db.Products.ToList();
            if (!String.IsNullOrEmpty(ProductName))
            {

                GetAllProducts = (List<Products>)GetAllProducts.Where(d => d.NameOfProduct.ToUpper().Contains(ProductName.ToUpper())).ToList();
            }
            return View(GetAllProducts);
        }
    }
}
