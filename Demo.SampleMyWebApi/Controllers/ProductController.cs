using Demo.SampleMyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.SampleMyWebApi.Controllers
{
    [RoutePrefix("Myproducts")]
    public class ProductController : ApiController
    {

        #region tempModel
        //private static List<ClientProductModel> products = new List<ClientProductModel>()
        //{ new ClientProductModel { ProdID =1, ProdName="Apple", Rate=100, Qty=2},
        //     new ClientProductModel { ProdID =2, ProdName="Samsung", Rate=90, Qty=2},
        //      new ClientProductModel { ProdID =3, ProdName="Moto", Rate=70, Qty=2},
        //       new ClientProductModel { ProdID =4, ProdName="Nokia", Rate=60, Qty=2}
        //};


        //[Route("GetAllProducts")]
        //public IEnumerable<ClientProductModel> Get()
        //{
        //    return products.ToList();
        //}

        //[Route("GetProductById/{Id}")]
        //public HttpResponseMessage Get(int Id)
        //{
        //    var prod =  products.Where(x => x.ProdID == Id).FirstOrDefault();



        //    if (prod==null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }

        //    //string jsonContent = Request.Content.ReadAsStringAsync().Result;
        //    return Request.CreateResponse(HttpStatusCode.OK, prod); ;
        //}



        //[Route("PostProduct")]
        //public IHttpActionResult Post(ClientProductModel  mymodel)
        //{
        //    products.Add(mymodel);

        //    return Ok(products);
        //}


        //[HttpPost]
        //[Route("UpdateProduct/{Id}")]
        //public IHttpActionResult Put(int Id,ClientProductModel mymodel)
        //{
        //    var prod = products.Where(x => x.ProdID == Id).FirstOrDefault();

        //    if (prod == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        products.Remove(prod);
        //        products.Add(mymodel);
        //    }

        //    return Ok(products);
        //}
        #endregion tempModel

        private MyProductDBEntities dbObject = new MyProductDBEntities();
        [Route("GetProducts")]
        public IHttpActionResult Get()
        {
            var allproducts = dbObject.Products.ToList();
            return Ok(allproducts);
        }


        [Route("PostProduct")]
        public IHttpActionResult Post(Products req)
        {
            dbObject.Products.Add(req);
            dbObject.SaveChanges();

            var allproducts = dbObject.Products.ToList();
            return Ok(allproducts);
        }

        
        [Route("PostClientProduct")]
        public IHttpActionResult Post(ClientProductModel req)
        {
            Products prod = new Products();
            //prod.ProductID
           // prod.ProductID = (int)req.ProdID;
            prod.ProductName = req.ProdName;
            prod.Quantity = (int)req.Qty;
            prod.Price = (int)req.Rate;

            dbObject.Products.Add(prod);
            dbObject.SaveChanges();
            
            return Ok();
        }


        [Route("UpdateUsingClientProduct/{Id}")]
        public IHttpActionResult Put(ClientProductModel req, int Id)
        {

            var prod = dbObject.Products.Where(x => x.ProductID == Id).FirstOrDefault();

            if (req.ProdName != "")
            {
                prod.ProductName = req.ProdName;
                dbObject.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                dbObject.SaveChanges();
            }
            else
            {
                return BadRequest("Product Name is a required field");
            }
            var allproducts = dbObject.Products.ToList();
            return Ok(allproducts);
        }


        [Route("Delete/{Id}")]
        public IHttpActionResult Delete(int Id)
        {

            var prod = dbObject.Products.Where(x => x.ProductID == Id).FirstOrDefault();
            if(prod!=null)
            {
                dbObject.Entry(prod).State = System.Data.Entity.EntityState.Deleted;
                dbObject.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            var allproducts = dbObject.Products.ToList();
            return Ok(allproducts);
        }

    }
}
