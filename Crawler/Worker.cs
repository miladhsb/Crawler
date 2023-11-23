using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crawler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cw = new CrawleTag();

           


            //Parallel.For()



            List<int> PageNum = new List<int>();

            for (int i = 1; i < 100; i+=10)
            {
                PageNum.Add(i);
            }
            Parallel.ForEachAsync(PageNum,  async (i,c) =>
            {
                cw.startCrawle(i);

                
               
              
            });

            //Task.Run(() =>
            //{


            //});
        }
    }
}
