# ToDo API

---

## Introduction

---

    This API allows users to access ToDo management system.
    This system supports following functions
    	- Create a new ToDo item
    	- Edit an ToDo item
    	- Delete a ToDo item
    	- Search ToDo item(s) by Due Date
    	- List all ToDo item

## Design

---

### Models

---

    - We have defined structure of our data using C# classes(POCO).
    - We have three classes in Models folder
    	- ToDoItem

---

### Controllers

This folder has a single controlelr ToDoItemController. This controller implements HTTP methods using Verbs
[HttpGet]
[HttpGet("{dueDate}")]
[HttpPost]
[HttpPut("{todoId}")]
[HttpDelete("{todoId}")]
