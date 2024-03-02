using ClassFormWithDb.Classes;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Xml.Linq;
using TaskManagementAPI.Classes.Database;
using static System.Reflection.Metadata.BlobBuilder;
namespace ClassFormWithDb
{
    public partial class Form1 : Form
    {
        /*private User mainUser = new User();
        private Dictionary<String, User> user_task_mapper = new Dictionary<String, User>();
        private Dictionary<String, User> task_category_mapper = new Dictionary<String, User>();*/


        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        public Form1()
        {
            InitializeComponent();

            DatabaseLayer mainDb = new DatabaseLayer();

            //here we test if data arrives
            Console.WriteLine("OUR DATA");
            foreach (var obj in mainDb.Users)
            {
                allInfoBox.Text += obj.Email;
            }

            foreach (var obj in mainDb.Categories)
            {
                allInfoBox.Text += obj.Name;
            }


        }


        /*
        //Some changes to be made and add functionality before delering to remove links to children
        private void insertTask(Classes.Task task)
        {
            var insertBook = "insert into task(name, description, priority, category, deadline) values(@nameBox, @descriptionBox, @priorityBox, @categoryBox, @dateBox)";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand q = new MySqlCommand(insertBook, connection))
                    {
                        q.Parameters.AddWithValue("@nameBox", task.Name);
                        q.Parameters.AddWithValue("@descriptionBox", task.Description);
                        q.Parameters.AddWithValue("@priorityBox", task.Priority);
                        q.Parameters.AddWithValue("@categoryBox", task.Category);
                        q.Parameters.AddWithValue("@dateBox", task.DeadlineDate);



                        int rowsAffected = q.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book added successfully!");

                            refreshLatestChanges(task.Task_id);
                        }
                        else
                        {
                            MessageBox.Show("Error adding the book.");
                        }
                    }
                   

                }
                catch (Exception ex)
                {

                }
            }

                    

        }

        private void updateTask(Classes.Task task)
        {
            var updateBook = "UPDATE task SET name = @nameBox, description = @descriptionBox, priority = @priorityBox, category = @categoryBox, date = @dateBox WHERE id = @taskId";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@taskId", task.Task_id);
                        q.Parameters.AddWithValue("@nameBox", task.Name);
                        q.Parameters.AddWithValue("@descriptionBox", task.Description);
                        q.Parameters.AddWithValue("@priorityBox", task.Priority);
                        q.Parameters.AddWithValue("@categoryBox", task.Category);
                        q.Parameters.AddWithValue("@dateBox", task.DeadlineDate);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book updated successfully!");

                            refreshAllChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the book.");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                connection.Close();
            }



        }

        private void deleteTask(Classes.Task task)
        {
            var updateBook = "delete from task where id = @taskId";
            //before deleting from task we need to search in Task_has_Category and task_has_SubTasks for any links that the task has with anything and
            //then get all the id's and delete them from the linking tables

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@taskId", task.Task_id);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully!");
                            refreshAllChanges();

                        }
                        else
                        {
                            MessageBox.Show("Error Deleting Task.");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }


        }

        private void GetTasks(List<Classes.Task> tasksList)
        {
            if (tasksList.Count != 0)
            {
                tasksList.Clear();
            }
            var selectBooks = "SELECT * FROM book";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(selectBooks, connection))
                    {
                        using (MySqlDataReader reader = q.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Classes.Task temp;
                                while (reader.Read())
                                {
                                    int taskId = reader.GetInt32("id");
                                    string name = reader.GetString("title");
                                    string description = reader.GetString("author");
                                    string priority = reader.GetString("priority");
                                    DateTime deadlineDate = reader.GetDateTime("deadline");

                                    try
                                    {

                                        Category category = GetCategory(new Classes.Task(taskId));
                                        temp = new Classes.Task(taskId, name, description, priority, category, deadlineDate, category.Category_id);
                                        tasksList.Add(temp);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("No Books found.");

                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("No books found.");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No connection established.");
                }
                connection.Close();
            }
        }

        private Category GetCategory(Classes.Task task)
        {
            var selectCategory = "SELECT name from category where Category.category_id = Task.Category_category_id and Task.task_id = @taskId";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    try
                    {
                        using (MySqlCommand q = new MySqlCommand(selectCategory, connection))
                        {
                            q.Parameters.AddWithValue("@taskId", task.Task_id);

                            using (MySqlDataReader reader = q.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Category temp;
                                    while (reader.Read())
                                    {
                                        int categoryId = reader.GetInt32("id");
                                        string category = reader.GetString("category");

                                        temp = new Category(categoryId, category);
                                        connection.Close();
                                        return temp;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No Categories found.");
                                    return null;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);

                    }

                    return null;
                }
                catch (Exception ex2)
                {

                }
                connection.Close();
            }
            return null;


        }


        //Some changes to be made and add functionality before delering to remove links to children
        private void insertSubTask(Classes.Task task, int subTaskId)
        {
            var insertBook = "insert into subtask(name) values(@nameBox)";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(insertBook, connection))
                    {

                        //getting specific subtask using FirstOrDefault
                        var subtaskToUpdate = task.SubTasks.FirstOrDefault(x => x.SubTask_id == subTaskId);


                        q.Parameters.AddWithValue("@nameBox", subtaskToUpdate.Name);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book added successfully!");

                            //Here we call a function that refreshes the local data
                            *//*refreshLatestChanges(name);*//*

                            //After it we need to call a function that inserts a connection between subtask and Parent task: Task_has_SubTask TABLE
                        }
                        else
                        {
                            MessageBox.Show("Error adding the book.");
                        }
                    }


                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }



        }

        private void updateSubTask(Classes.Task task, int subTaskId)
        {
            var updateBook = "UPDATE subtask SET name = @nameBox WHERE SubTask.subTask_id = subTaskId";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        //getting specific subtask using linq
                        var subtaskToUpdate = task.SubTasks.FirstOrDefault(x => x.SubTask_id == subTaskId);

                        q.Parameters.AddWithValue("@subTaskId", subTaskId);
                        q.Parameters.AddWithValue("@nameBox", subtaskToUpdate.Name);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book updated successfully!");

                            refreshAllChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the book.");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                connection.Close();
            }



        }

        private void deleteSubTask(Classes.Task task, int subTaskId)
        {
            var updateBook = "delete from subtask where subTask_id = @subTaskId";

            //first we need to delete the link of the subtask form Task_has_SubTask TABLE
            //function here:

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        var subtaskToUpdate = task.SubTasks.FirstOrDefault(x => x.SubTask_id == subTaskId);

                        q.Parameters.AddWithValue("@subTaskId", subtaskToUpdate.SubTask_id);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("SubTask deleted successfully!");
                            refreshAllChanges();

                        }
                        else
                        {
                            MessageBox.Show("Error Deleting SubTask.");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }


        }


        //Some changes to be made and add functionality before delering to remove links to children
        private void insertCategory(Category category)
        {
            var insertBook = "insert into category(name) values(@nameBox)";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(insertBook, connection))
                    {
                        q.Parameters.AddWithValue("@nameBox", category.Name);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!");

                            //refresh local category
                            *//*refreshLatestChanges(category.Name);*//*
                        }
                        else
                        {
                            MessageBox.Show("Error adding the Category.");
                        }
                    }


                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }



        }

        private void updateCategory(Category category)
        {
            var updateBook = "UPDATE category SET name = @nameBox WHERE id = @categoryId";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@categoryId", category.Category_id);
                        q.Parameters.AddWithValue("@nameBox", category.Name);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!");

                            //change this
                            refreshAllChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the Category.");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                connection.Close();
            }



        }

        private void deleteCategory(Category category)
        {
            var updateBook = "delete from task where id = @taskId";
            //before deleting from task we need to search in Task_has_Category and task_has_SubTasks for any links that the task has with anything and
            //then get all the id's and delete them from the linking tables

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@taskId", category.Category_id);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully!");
                            refreshAllChanges();

                        }
                        else
                        {
                            MessageBox.Show("Error Deleting Task.");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }


        }


        //Some changes to be made and add functionality before delering to remove links to children
        private void insertUser(User user)
        {
            var insertUser = "insert into user(profilePic, email, username, registration_date, passId, platform_account) values(@pfpBox, @emailBox, @usernameBox, @registrationDateBox, @passIdBox, @platformAccBox)";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(insertUser, connection))
                    {
                        q.Parameters.AddWithValue("@pfpBox", user.ProfilePic);
                        q.Parameters.AddWithValue("@emailBox", user.Email);
                        q.Parameters.AddWithValue("@usernameBox", user.Username);
                        q.Parameters.AddWithValue("@registrationDateBox", user.Registration_date);
                        q.Parameters.AddWithValue("@passIdBox", user.PassId);
                        q.Parameters.AddWithValue("@platformAccBox", user.Platform_account);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!");

                            //change
                            *//*refreshLatestChanges(user.Email);*//*
                        }
                        else
                        {
                            MessageBox.Show("Error adding the User.");
                        }
                    }


                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }



        }

        private void updateUser(User user)
        {
            var updateBook = "UPDATE user SET profilePic = @pfpBox, email = @emailBox, username = @usernameBox, registration_date = @registrationDateBox, passId = @passIdBox, platform_account = @platformAccBox WHERE user_id = @userId";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@userId", user.User_id);
                        q.Parameters.AddWithValue("@pfpBox", user.ProfilePic);
                        q.Parameters.AddWithValue("@emailBox", user.Email);
                        q.Parameters.AddWithValue("@usernameBox", user.Username);
                        q.Parameters.AddWithValue("@registrationDateBox", user.Registration_date);
                        q.Parameters.AddWithValue("@passIdBox", user.PassId);
                        q.Parameters.AddWithValue("@platformAccBox", user.Platform_account);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!");

                            //change this
                            refreshAllChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the Category.");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                connection.Close();
            }



        }

        private void disableUser(User user)
        {
            var updateBook = "update user set disabled = 1 where user_id = @userId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand q = new MySqlCommand(updateBook, connection))
                    {
                        q.Parameters.AddWithValue("@userId", user.User_id);



                        int rowsAffected = q.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully!");
                            refreshAllChanges();

                        }
                        else
                        {
                            MessageBox.Show("Error Deleting Task.");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }


        }







        private int checkDuplicateCategory(MySqlConnection connection, String category)
        {
            var checkCatDuplicate = "select id from category where category = @categoryBox";


            using (MySqlCommand q = new MySqlCommand(checkCatDuplicate, connection))
            {
                q.Parameters.AddWithValue("@categoryBox", category);

                var idDuplicate = q.ExecuteScalar();

                return idDuplicate!= null ? (int)idDuplicate : 0;
            }

        }

        private int checkDuplicateTitle(MySqlConnection connection, String title)
        {
            var checkCatDuplicate = "select id from book where title = @title";


            using (MySqlCommand q = new MySqlCommand(checkCatDuplicate, connection))
            {
                q.Parameters.AddWithValue("@title", title);

                var idDuplicate = q.ExecuteScalar();

                return idDuplicate!= null ? (int)idDuplicate : 0;
            }

        }

        //Function made to refresh Specific
        //local changes (either objects or lists or objects or dictionaries)
        private void refreshLatestChanges(int id)
        {
            //OLD code example


            *//*GetBooks(listOfAllBooks);
            foreach (Book book in listOfAllBooks)
            {
                if (book.title == title && !booksMapper.ContainsKey(title))
                {
                    booksMapper.Add(title, book);
                    booksCategoryMapper.Add(book.category.category, book);
                    //we empty list to refill with new data (slow but its assignment :/)
                    allBooksComboBox.Items.Clear();
                    categoryComboBox.Items.Clear();
                    allBooksComboBox.Items.AddRange(booksMapper.Keys.ToArray());
                    categoryComboBox.Items.AddRange(booksCategoryMapper.Keys.ToArray());
                    break;
                }
            }*//*
        }

        //Function made to refresh All
        //local changes (either objects or lists or objects or dictionaries)
        private void refreshAllChanges()
        {
        }*/




        private void submitBook_Click(object sender, EventArgs e)
        {

        }

        private void allBooksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void saveChanges_Click(object sender, EventArgs e)
        {

        }

        private void modifyCategory_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void deleteBook_Click(object sender, EventArgs e)
        {

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void allInfoBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
