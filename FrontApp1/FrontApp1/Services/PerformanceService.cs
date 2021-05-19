namespace FrontApp1.Services
{
    public class PerformanceService : IPerformanceService
    {
        public void CpuStress(int level, int totalSec)
        {
            if (level < 0)
            {
                level = 0;
            }
            else if (level > 4)
            {
                level = 4;
            }
            for (int i = 0; i < totalSec * 10; i++)
            {
                int time = System.Environment.TickCount;
                while (System.Environment.TickCount - time < level * 25)
                { }
                System.Threading.Thread.Sleep(100 - level * 25);
            }
        }
    }
}