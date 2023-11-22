namespace Crawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var cw=  new CrawleTag();

                Console.WriteLine("set page Number : ");
                var page =Console.ReadLine();
                cw.startCrawle(int.Parse(page));
                Console.ReadKey();
                Console.WriteLine("end task!");
        }
    }
}
