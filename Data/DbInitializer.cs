using System;
using System.Linq;
using TaskManagementAPI_proj.Models;

namespace TaskManagementAPI_proj.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaskManagerContext context)
        {
            if (context.Users.Any()
                && context.Projects.Any()
                && context.Tasks.Any()
                && context.SubTasks.Any())
            {
                return;   // DB has been seeded
            }

            var user1 = new User
            {
                ProfilePic = "profile1.jpg",
                Email = "user1@example.com",
                Username = "user1",
                Password = "password1",
                RegistrationDate = DateTime.Now,
                PlatformAccount = "local",
                Disabled = 0
            };

            var user2 = new User
            {
                ProfilePic = "profile2.jpg",
                Email = "user2@example.com",
                Username = "user2",
                Password = "password2",
                RegistrationDate = DateTime.Now,
                PlatformAccount = "local",
                Disabled = 0
            };

            var project1 = new Project
            {
                Title = "Project 1",
                Description = "Description for Project 1",
                CreationDate = DateTime.Now
            };

            var task1 = new Models.Task
            {
                Name = "Task 1",
                Description = "Description for Task 1",
                Priority = "High",
                Deadline = DateTime.Now.AddDays(7),
            };


            var tag1 = new Models.Tag
            {
                Name = "Tag 1",
                
            };

            var subtask1 = new SubTask
            {
                Name = "Subtask 1"
            };

            // Associating entities
            project1.Users.Add(user2);
            project1.Tasks.Add(task1);
            task1.SubTasks.Add(subtask1);
            task1.Tags.Add(tag1);

            project1.CreatorId = 1;

            // Add entities to context
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Projects.Add(project1);
            context.Tasks.Add(task1);
            context.SubTasks.Add(subtask1);
            context.Tags.Add(tag1);

            // Save changes to database
            context.SaveChanges();
        }
    }
}
