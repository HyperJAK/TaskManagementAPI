using System;

namespace ClassFormWithDb.Classes
{
    public class SubTask
    {
        public int SubTask_id { get; set; }
        public string Name { get; set; }
        

        public SubTask() { }

        public SubTask(int subTaskId, string name)
        {
            SubTask_id = subTaskId;
            Name = name;

        }

        public SubTask(string name)
        {
            Name = name;

        }
    }

}
