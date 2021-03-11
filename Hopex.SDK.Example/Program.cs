using Hopex.SDK.Core.Log;
using Hopex.SDK.Example.Example;

namespace Hopex.SDK.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            AppLogger.Info("Example start");

            Config.LoadConfig();

            RunAllExamples(true);

            AppLogger.Info("Example stopped");
        }

        static void RunAllExamples(bool isPerformance = false)
        {
            if (isPerformance)
            {
                PerformanceLogger.GetInstance().Enable(true);

                AppLogger.Enable(false);
            }

            RunAllRestExamples();
        }

        static void RunAllRestExamples()
        {
            //AccountClientExample.RunAll();

            HomeClientExample.RunAll();

            MarketClientExample.RunAll();

            //TradeClientExample.RunAll();

            //WalletClientExample.RunAll();
        }
    }
}
