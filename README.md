# A simple REST API Backend Application

**REST API Backend** is a simple backend REST API based application that implements the four REST operations - GET, POST, PUT & DELETE. The opertaions are done on an Employee Table.

The Response headers for all the opeartions holds the following information:
	1. if the opeartion was successful(e.g. 200 OK) and
	2. A status message (E.g. Employee Added Successfully, Employee Deleted Sucessfully etc).

## User Stories

The following features are implemented:
```sh
- [X] GET - All the records in the Employee Table will be displayed
- [X] POST - Inserts a new Record into the Employee Table
- [X] PUT - Updates the phone number of the Employee
- [X] DELETE - Deletes the record from the Employee Table
```

Running the curl commands from gitbash:
=======================================
Open Gitbash and run the following commands for each of the operations
```sh
1. GET:
curl -i -X GET --header 'Accept: application/json' 'http://*AWS_URL*/employeedetails'

2. POST: Give an ID which is currently not in the employee table, Since Id is the Primary Key
curl -i -X POST -H 'Content-Type: application/json' -H 'Accept: application/json' 'http://*AWS_URL*/employee' -d '{"Id": 6, "firstName": "test6", "lastName": "test6", "phoneNumber": "test6", "emailId": "test6@gmail.com", "age": 6}'

3. PUT:
curl -i -X PUT -H 'Accept: application/json' 'http://*AWS_URL*/employee/6/123456' -d '{"Id": 6, "phoneNumber": "123456"}'

4. DELETE:
curl -i -X DELETE --header 'Accept: application/json' 'http://*AWS_URL*/employee/delete/6'
```

###### *Please contact deepthi.warrier@gmail.com for more info on the code
