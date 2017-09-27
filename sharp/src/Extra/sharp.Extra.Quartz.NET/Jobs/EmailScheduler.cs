using Quartz;
using Quartz.Impl;

namespace sharp.Extra.Quartz.NET.Jobs
{
    public class EmailScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailSender>().Build();

            ITrigger trigger = TriggerBuilder.Create()  // create trigger
                .WithIdentity("trigger1", "group1")     // identify trigger with group
                .StartNow()                            // starts the trigger
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)          // after 1 minute
                    .RepeatForever())                   // forerver repeat
                .Build();                               // build trigger

            scheduler.ScheduleJob(job, trigger);        // starts job
        }
    }
}