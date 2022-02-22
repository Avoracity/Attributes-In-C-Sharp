namespace FirstNamespace
{
    interface IFirstInterface
    {
        void AudioQueue();
        bool BoolInstance { get; set; }
        int NumInstance { get; set; }

        char CharInstance { get; set; }
    }

    class FirstClass : IFirstInterface
    {
        public bool Switch;
        public int Threads;
        public char SingleChar;

        public delegate void Notify();

        public void AudioQueue()
        {
            Console.WriteLine("Owa Owa");
        }
        public bool BoolInstance // property
        {
            get { return Switch; }
            set { Switch = value; }
        }

        public int NumInstance // property
        {
            get { return Threads; }
            set { Threads = value; }
        }

        public char CharInstance
        {
            get { return SingleChar; }
            set { SingleChar = value; }
        }
    }

    public class Service
    {
        public string Item;
    };

    public class ProvidingNow
    {
        // Delegate: ref to method : used when method chosen undecided until runtime

        public delegate void ProvideEventHandler(object source, EventArgs args);

        // Event : an event occurs 
        public event ProvideEventHandler ProvideService; 

        public void QueueServiceThread(Service service)
        {
            Console.WriteLine($"Providing . . . '{service.Item}', lorem");
            Thread.Sleep(4000);

            OnCompletion();
        }

        protected virtual void OnCompletion() // method func for event
        {
            if (ProvideService != null)
                ProvideService(this, null);
        }

    }

    public class AppService
    {
        public void OnCompletion(object source, EventArgs eventArgs)
        {
            Console.WriteLine("AppService: queue has completed.");

        }
    }

    
    class SampleArray<T>
    {
        private T[] arr = new T[100];

        public T this[int i] // indexer : i
        {
            get { return arr[i]; }
            set { arr[i] = value;  }

        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var service_choice = new Service { Item = "cheeto fingers" };
            var service_queue = new ProvidingNow();
            var app_queue = new AppService();
            service_queue.ProvideService += app_queue.OnCompletion; // event subscribe, -= to unsubscribe
            service_queue.QueueServiceThread(service_choice);
            Console.ReadKey();

            // indexer being used for array
            var listOfStrings = new SampleArray<string>();
            listOfStrings[0] = "first element";
            Console.WriteLine(listOfStrings[0]);
        }
    }

}