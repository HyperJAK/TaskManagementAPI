using System;

namespace ClassFormWithDb.Classes
{
    public class Task
    {
        public int Task_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public Category Category { get; set; }
        public DateTime DeadlineDate { get; set; }

        public int Category_category_id { get; set; }

        public List<SubTask> SubTasks { get; set; }

        public Task() { }

        public Task(int id) {
            this.Task_id = id;
        }

        public Task(int taskId, string name, string description, string priority, Category category, DateTime deadlineDate, int category_category_id)
        {
            Task_id = taskId;
            Name = name;
            Description = description;
            Priority = priority;
            Category = category;
            DeadlineDate = deadlineDate;
            Category_category_id = category_category_id;
        }
    }

}
