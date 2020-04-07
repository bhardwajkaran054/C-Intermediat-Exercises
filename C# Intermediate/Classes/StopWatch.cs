using System;

namespace excerciseTimeSpan
{
    class Timer
    {
        private DateTime _startTime;
        private DateTime _stopTime;
        private Boolean _isRunning = false;

        public void Start()
        {
            if (_isRunning)
                throw new InvalidOperationException("Stopwatch already running");
            else
            {
                _startTime = DateTime.Now;
                _isRunning = true;

            }
        }
        public void Stop()
        {
            if (!_isRunning)
                throw new InvalidOperationException("Stopwatch already stopped");
            else
            {
                _stopTime = DateTime.Now;
                _isRunning = false;
            }
        }
        public TimeSpan Duration()
        {
            if (_isRunning)
                throw new InvalidOperationException("Stopwatch already stopped");
            else
            {
                return _stopTime - _startTime;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            var timer = new Timer();

            do
            {
                Console.WriteLine("Enter your choice:\n1.Start()\n2.Stop()\n3.Duration()\n4.Quit()");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            timer.Start();
                            break;
                        case 2:
                            timer.Stop();
                            break;
                        case 3:
                            Console.WriteLine(timer.Duration());
                            break;
                        default:
                            break;
                    }
                    if (choice == 4)
                        break;
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter Valid Choice!!!");
                }
            } while (true);
        }
    }
}
