using System;
using System.Collections.Generic;

namespace Workflow
{
    class Program
    {
        static void Main(string[] args)
        {

            Workflow workflow = new Workflow();
            workflow.Add(new UploadVideo());
            workflow.Add(new SendMail());

            WorkFlowEngine engine = new WorkFlowEngine();
            engine.Run(workflow);

        }
    }
    public interface ITask
    {
        void Execute();
    }
    public interface IWorkflow
    {
        void Add(ITask task);
        void Remove(ITask task);
        List<ITask> GetTasks();

    }
    public class Workflow : IWorkflow
    {
        private readonly List<ITask> _task;

        public Workflow()
        {
            _task = new List<ITask>();
        }
        public void Add(ITask task)
        {
            _task.Add(task);
        }
        public void Remove(ITask task)
        {
            _task.Remove(task);
        }
        public List<ITask> GetTasks()
        {
            return _task;
        }
    }
    public class UploadVideo : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Video Uploading...");
        }
    }
    public class SendMail : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Sending mail...");
        }
    }

    public class WorkFlowEngine
    {
        public void Run(IWorkflow workflow)
        {
            foreach (ITask task in workflow.GetTasks())
            {
                task.Execute();
            }
        }
    }

}
