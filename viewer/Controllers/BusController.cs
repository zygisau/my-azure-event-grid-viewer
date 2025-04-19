using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using viewer.Hubs;
using viewer.Models;
using Azure.Identity;
using Azure.Messaging.ServiceBus;

namespace viewer.Controllers
{
    [Route("api/[controller]")]
    public class BusController : Controller
    {
        #region Data Members

        private readonly ServiceBusClient _serviceBusClient;

        #endregion

        #region Constructors

        public BusController(ServiceBusClient serviceBusClient)
        {
            this._serviceBusClient = serviceBusClient;
        }

        #endregion

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            ServiceBusSender sender = this._serviceBusClient.CreateSender("viewexequeue");
            await sender.SendMessageAsync(new ServiceBusMessage("Hello from managed identity!"));
            Console.WriteLine("Message sent.");
            return Ok();
        }

        #endregion
    }
}
