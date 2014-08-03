using EgyenlitoMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EgyenlitoMvc.WCF
{
    public class WinEventService : IWinEventService
    {
        public EventsModelContainer Entities { get; set; }


        public WinEventService()
        {
            Entities = new EventsModelContainer();
        }


        public string GetEvents()
        {
            var events = Entities.Events.OrderBy((x) => x.Date).Take(10).ToList();

            var str = JsonConvert.SerializeObject(events);
            return str;
        }

        public string GetUpholders()
        {
            var upholders = Entities.Upholders.ToList();

            var str = JsonConvert.SerializeObject(upholders);
            return str;
        }
    }
}
