using System;

namespace TimeKeeping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|| Employee Time Keeping System ||");
            Console.WriteLine($"TODAY's DATE: {DateTime.Today.ToShortDateString()}");

            Console.Write("To log your time-in enter your employee id: ");
            string employeeId = Console.ReadLine();

            //Date and Time --> DateTime
            //Time only --> TimeSpan

            TimeSpan timeIn = new TimeSpan(8, 0, 0);
            Console.WriteLine($"Your login time is recorded: {timeIn}");

            Console.WriteLine("****************************************");
            Console.Write("To log your time-out enter employee id: ");
            employeeId = Console.ReadLine();

            TimeSpan timeOut = new TimeSpan(16, 0, 0);
            Console.WriteLine($"Your logout time is recorded: {timeOut}");

            TimeSpan lunchBreakDuration = new TimeSpan(1, 0, 0);
            TimeSpan totalHours = (timeOut - timeIn) - lunchBreakDuration;

            Console.WriteLine($"Your total hours worked is: {totalHours}");

            TimeSpan regularHoursStart = new TimeSpan(8, 0, 0);
            TimeSpan regularHoursEnd = new TimeSpan(17, 0, 0); 
            TimeSpan lateIn = new TimeSpan(0, 0, 0);
            TimeSpan earlyOut = new TimeSpan(0, 0, 0);

            if (timeIn > regularHoursStart)
            {
                lateIn = timeIn - regularHoursStart;
            }

            if (timeOut < regularHoursEnd)
            {
                earlyOut = timeOut - regularHoursEnd;
            }

            TimeSpan totalRegularHours = totalHours - (lateIn + earlyOut);
            Console.WriteLine($"Your total regular hours worked is: {totalRegularHours}");

            

            if (timeOut < regularHoursEnd)
            {
                Console.WriteLine("THE EMPLOYEE IS WORKING UNDERTIME");

                TimeSpan totalUndertimeHours = regularHoursEnd - timeOut ;
                Console.WriteLine($"Your total undertime hours/minutes is: {totalUndertimeHours}");
            }

            if (timeOut >= regularHoursEnd)
            {
                Console.WriteLine("THE EMPLOYEE DID THE FULL-TIME WORK");
            }
        }
    }
}
