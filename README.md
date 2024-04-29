# <span style="color:purple">API Task Management</span>  
This is a university Advanced programming class final project. Our objective is to make a task management API and oprionally a frontend integration of it.

### To Install Dependencies  

To run API, first we clone using this command:
```bash
clone https://github.com/HyperJAK/TaskManagementAPI.git
```  

<span style="color:red">(Important, read!)</span>  
The API can be opened in the browser using swagger, by accessing this link:
 ```bash
http://localhost:5183/swagger
```

However, you can also access it using the frontend web application available here:
https://github.com/HyperJAK/Task-Management-Frontend

Or you can clone using: 
```bash
clone https://github.com/HyperJAK/Task-Management-Frontend.git
``` 


### To Start
<details>
<summary>To run the API:</summary>
<br>  

We open project and type in terminal:
```bash
dotnet run
```

</details>  

<details>
<summary>To run Frontend web app:</summary>
<br>  

First we open project and install all dependencies:
```bash
npm install
```

Then we run this command to start project:
```bash
npm run dev
```

</details>



### About database:  
```bash
We have 5 tables: 

Users, 
Projects, 
Tasks, 
Subtasks,
Tags, 
ProjectUser  

Each of these tables have a connection with another table and we are using Linq to manage all the data coming and going from the database
```  


#
# Overview  

