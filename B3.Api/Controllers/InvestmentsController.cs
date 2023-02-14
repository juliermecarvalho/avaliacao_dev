using B3.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace B3.Api.Controllers
{
    public class InvestmentsController : ApiController
    {

        [HttpPost]
        public decimal CalculateFinalValue(Investment investment)
        {
            decimal cdi = 0.009m;
            decimal tb = 1.08m;
         

            return investment.CalculateFinalValue(cdi, tb);
        }

       

    }
}
