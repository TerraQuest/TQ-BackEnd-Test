using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TQ.Services
{
   public class WorkerTallyCounter
    {
        public static Task<int> TallyCounterAsync(int count, Func<bool> find)
        {
            int counter = 0;

            void DoBatch(int batchSize)
            {
                for (int i = 0; i < batchSize; i++)
                {
                    var newCounterValue = counter;
                    if (find())
                    {
                        newCounterValue++;
                    }
                    else
                    {
                        newCounterValue--;
                    }

                    counter = newCounterValue;
                }
            }

            var batchSize = count / 10;

            var tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() => DoBatch(batchSize));
            }

            Task.WaitAll(tasks);

            return Task.FromResult(counter);
        }

    }
}
