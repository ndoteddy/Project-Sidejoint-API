using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SideJointAPI.Hubs;
using SideJointAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SideJointAPI
{
    public class PriceTrackerHostedService : IHostedService
    {
        private Timer _timer;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly MainContext _mainContext;
       

        public PriceTrackerHostedService(IHubContext<NotificationHub> hubContext ,IServiceProvider serviceProvider)
        {
            _hubContext = hubContext;
            _mainContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<MainContext>();

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(2));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _hubContext.Clients.All.SendAsync("SendMessage",
                new
                {
                    priceSummary = GetPriceSummary()                    
                }); ;
        }


        private async Task<List<PriceSummaryDTO>> GetPriceSummary()
        {
            
            var _masterdata = await _mainContext.MasterItems.AsNoTracking().ToListAsync();
            var _listPriceSummaryDTO = new List<PriceSummaryDTO>();
            foreach (var masteritem in _masterdata)
            {               
                var todayopeningmarket = masteritem.todayopenvalue;                
                var data = await _mainContext.PriceTracker.Where(x => x.itemid == masteritem.id).AsNoTracking().ToListAsync();
                var result = data.GroupBy(x => x.itemid)
                               .Select(group => new PriceSummaryItem
                               {
                                   itemid = group.Key,
                                   totalprice = Math.Round(group.Sum(i => i.price),2),
                                   averageprice = Math.Round(group.Average(i => i.price),2)
                               }).ToList();

                foreach (var item in result)
                {
                    var percentage = Math.Round(((Double)item.averageprice - (Double)todayopeningmarket) / ((Double)todayopeningmarket) * 100);
                    var percentageInString = "";
                    if (percentage > 0){
                        item.pricestatus = "UP";
                        percentageInString = "+" + percentage + "%";                      
                    }
                    else {
                        item.pricestatus = "DOWN";
                        percentageInString = percentage + "%";
                    }
                    item.percentage = percentageInString;
                }

                _listPriceSummaryDTO.Add(new PriceSummaryDTO()
                {
                    itemid = masteritem.id,
                    name = masteritem.name,
                    email=masteritem.email,
                    todayopenvalue = masteritem.todayopenvalue,
                    priceSummaryItem = result

                });
            }            
            return _listPriceSummaryDTO;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
