<h1 align="center"> <b>Postman - Integration Test</b> </h1>

> 🔗  https://www.getpostman.com/collections/02771d65ff7004ddfaea

 ## ![postman](https://user-images.githubusercontent.com/35347777/147509734-b58b6d8d-1780-4d9b-8c4f-ffcb545d3a1d.png) Postman


## SignIn Testleri

<details>
    <summary><strong>Success sign in</strong></summary>

--------
 
Responses durumlarında başarılı işlemin 200 dönmesi gerektiği söylenmiş ama işlem 201 Created olarak geliyor. Bu yüzden testi fail olarak aldım.
 
![Success_signinv2](https://user-images.githubusercontent.com/35347777/149654893-b4e1a464-4990-49ac-b88d-6b23458c75b1.PNG) 

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 
pm.test("Response control", function () { 
  pm.expect(response.to.have.status(200));
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
  pm.expect(pm.response.to.have.jsonBody('access_token'));
}); 
 
tests["Size control"] = size == 1;   
tests["Access token type control"] = typeof(actualResponse.access_token) === "string";
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("OK")); 
});
  

pm.test("Response should not be error", function () { 
    pm.expect(response.to.not.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Failed sign in</strong></summary>

--------
  
![Failed_signin](https://user-images.githubusercontent.com/35347777/149537722-ad32a73f-dd66-4537-b2f4-817c96b2a42c.PNG) 

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 

tests["Size control"] = size == 2;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string"; 


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(401));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode')); 
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "Unauthorized"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Unauthorized")); 
  console.log("Error: Unauthorized" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>
  
<details>
    <summary><strong>Email null & Password undefined</strong></summary>

--------
   
![Email null   Password undefined](https://user-images.githubusercontent.com/35347777/149538446-700e6f14-406b-4cb0-9339-77c4dddc6c07.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 

tests["Size control"] = size == 2;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string"; 


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(401));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode')); 
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "Unauthorized"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  
pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Unauthorized")); 
  console.log("Error: Unauthorized" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email null & Password null</strong></summary>

--------
    
![Email null   Password null](https://user-images.githubusercontent.com/35347777/149538577-bf949458-1aeb-44ee-9557-9e627af450bf.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 

tests["Size control"] = size == 2;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string"; 


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(401));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode')); 
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "Unauthorized"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Unauthorized")); 
  console.log("Error: Unauthorized" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email undefined & Password undefined</strong></summary>

--------
     
![Email undefined   Password undefined](https://user-images.githubusercontent.com/35347777/149538695-ef75b0f6-bf35-4cbd-968d-3b0b3f04ea4b.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 

tests["Size control"] = size == 2;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string"; 


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(401));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode')); 
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "Unauthorized"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Unauthorized")); 
  console.log("Error: Unauthorized" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email undefined & Password null</strong></summary>

--------
     
![Email undefined   Password null](https://user-images.githubusercontent.com/35347777/149538826-e76b4fde-9ea5-4cda-9ab7-6167bc04ca6d.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 

tests["Size control"] = size == 2;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string"; 


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(401));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode')); 
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "Unauthorized"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Unauthorized")); 
  console.log("Error: Unauthorized" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>


## SignUp Testleri

<details>
    <summary><strong>Successfully signed-up</strong></summary>

--------
SignIn'deki durum benzeri, 201 döndüğü için fail olarak aldım.
 
![signup_successv2](https://user-images.githubusercontent.com/35347777/149654948-65a2df2b-d177-49b3-aef9-a646f770f2c5.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
pm.environment.set("UserAccessToken",actualResponse.access_token);
 
pm.test("Response control", function () { 
  pm.expect(response.to.have.status(200));
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
  pm.expect(pm.response.to.have.jsonBody('access_token'));
}); 
 
tests["Size control"] = size == 1;   
tests["Access token type control"] = typeof(actualResponse.access_token) === "string";
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("OK")); 
});
   
pm.test("Response should not be error", function () { 
    pm.expect(response.to.not.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Already signed-up</strong></summary>

--------
       
![Already signed-up](https://user-images.githubusercontent.com/35347777/149540646-26d9d66f-cf85-4843-bd1f-d36d70dfdab6.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(409));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "User already exist!"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Conflict")); 
  console.log("Error: Conflict" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email null & Password undefined</strong></summary>

--------
        
![Email null   Password undefined](https://user-images.githubusercontent.com/35347777/149540814-e70c67cd-9c38-42d1-8947-bbc08f6de23e.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
   
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= [
            "email should not be null or undefined",
            "email must be shorter than or equal to 100 characters",
            "email should not be empty",
            "email must be an email",
            "password should not be null or undefined",
            "password must be shorter than or equal to 20 characters",
            "password must be longer than or equal to 8 characters",
            "password should not be empty",
            "password must be a string"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email null & Password null</strong></summary>

--------
         
![Email null   Password null](https://user-images.githubusercontent.com/35347777/149540923-9a73526f-91a2-4fed-8331-30a95b7ef2bc.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
   
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= [
            "email should not be null or undefined",
            "email must be shorter than or equal to 100 characters",
            "email should not be empty",
            "email must be an email",
            "password should not be null or undefined",
            "password must be shorter than or equal to 20 characters",
            "password must be longer than or equal to 8 characters",
            "password should not be empty",
            "password must be a string"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email undefined & Password undefined</strong></summary>

--------
          
![Email undefined   Password undefined](https://user-images.githubusercontent.com/35347777/149541098-b46ea2d2-5ada-4daf-952d-02f5ddf31538.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 
  
var expectedResponse= [
            "email should not be null or undefined",
            "email must be shorter than or equal to 100 characters",
            "email should not be empty",
            "email must be an email",
            "password should not be null or undefined",
            "password must be shorter than or equal to 20 characters",
            "password must be longer than or equal to 8 characters",
            "password should not be empty",
            "password must be a string"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email undefined & Password null</strong></summary>

--------
           
![Email undefined   Password null](https://user-images.githubusercontent.com/35347777/149541204-b0b5732f-ccc8-44c5-8f46-53ffa06a1b5f.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
  
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";
  
pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 


var expectedResponse= [
            "email should not be null or undefined",
            "email must be shorter than or equal to 100 characters",
            "email should not be empty",
            "email must be an email",
            "password should not be null or undefined",
            "password must be shorter than or equal to 20 characters",
            "password must be longer than or equal to 8 characters",
            "password should not be empty",
            "password must be a string"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});



pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Password is short character</strong></summary>

--------
            
![Password is short character](https://user-images.githubusercontent.com/35347777/149541815-05e3beba-5563-45b0-98f6-12578276eef3.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
  

tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "password must be longer than or equal to 8 characters"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message[0]).to.eql(expectedResponse); 
});

  
pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Password is long character</strong></summary>

--------
             
![Password is long character](https://user-images.githubusercontent.com/35347777/149542331-74b66f74-ba3d-48e4-a95a-9abc811cb8dc.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
  
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= (
            "password must be shorter than or equal to 20 characters"
);
   
pm.test("Check response is true", () => {
    pm.expect(actualResponse.message[0]).to.eql(expectedResponse); 
});
 
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Password type is not string</strong></summary>

--------
              
![Password type is not string](https://user-images.githubusercontent.com/35347777/149542419-201b0cfd-4f91-45e5-9c83-71fb2f40427d.PNG)

```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
  
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
   
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= [
          "password must be shorter than or equal to 20 characters",
          "password must be longer than or equal to 8 characters",
          "password must be a string"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>

<details>
    <summary><strong>Email type is not string</strong></summary>

--------
              
![Email type is not string](https://user-images.githubusercontent.com/35347777/149542574-696a2301-0f1e-4bcc-ae21-3fd74f50b573.PNG)
  
```javascript
const response = pm.response;

const actualResponse = response.json();
var size = Object.keys(actualResponse).length;  
var responsLimit = 1000; 
var responseTime = response.responseTime; 
 
 
tests["Size control"] = size == 3;   
tests["Status code type control"] = typeof(actualResponse.statusCode) === "number";
tests["Message type control"] = typeof(actualResponse.message[0]) === "string";
tests["Error type control"] = typeof(actualResponse.error) === "string";


pm.test("Response control", function () { 
  pm.expect(response.to.have.status(400));
  pm.expect(pm.response.to.have.jsonBody('message'));
  pm.expect(pm.response.to.have.jsonBody('statusCode'));
  pm.expect(pm.response.to.have.jsonBody('error'));
   
  pm.expect(response.to.be.withBody);
  pm.expect(response.to.be.json);
}); 

var expectedResponse= [
          "email must be shorter than or equal to 100 characters",
          "email must be an email"
];
   
pm.test("Check response is true", () => {
    for (var i = 0; i < expectedResponse.length; i++){
        pm.expect(actualResponse.message[i]).to.eql(expectedResponse[i]);  
    }
});
  

pm.test("Status code name has string", () => {
  pm.expect(response.to.have.status("Bad Request")); 
  console.log("Error: Bad Request" +"\n"
                +"Message Error: "+actualResponse.message); 
});
   
pm.test("Response should be error", function () { 
    pm.expect(response.to.be.error); 
}); 

pm.test("Check response time", () => {  
  if (responseTime > responsLimit) {       
    console.log("Response time was longer than " + responsLimit + " ms " + "(" + responseTime + " ms)" + " / Response Date: " + pm.response.headers.get("Date"));
  }
  pm.expect(responseTime).to.be.below(responsLimit); 
});
 
 pm.test("Response has charset in content-type header", function () {
    pm.expect(pm.response.to.have.header("Content-Type"));
    pm.expect(pm.response.to.have.header('Content-Type', 'application/json; charset=utf-8'));
});
```
</details>
 
##  ![postman monitoring](https://user-images.githubusercontent.com/35347777/147594384-6d3a8248-fb31-450f-8f8c-e7a786057fcb.png) Postman Collection Run

<details>
  <summary> (<i>Görüntülemek için tıklayın</i>)</summary>
   
![out](https://user-images.githubusercontent.com/35347777/149655155-dcd69400-8acd-4140-a0cb-d8c54efca64f.gif)

</details>

  
##  ![newman](https://user-images.githubusercontent.com/35347777/147482415-33220019-78d5-4a50-8855-a2f8fe3b8070.png) Newman Raporu

Daha detaylı incelemek için [**buraya**](https://onurerdemiroglu.com.tr/html-test-reports/) tıklayınız.

<details>
  <summary> (<i>Raporu görüntülemek için tıklayın</i>)</summary>
  
 ![newwman](https://user-images.githubusercontent.com/35347777/149655368-fb2d6fe9-6ec5-4ddf-9be1-fd0053f24a00.png)


</details>
 
##  ![1200px-Jenkins_logo svg](https://user-images.githubusercontent.com/35347777/147480987-e53e1e34-a6b5-4491-982f-d95c081112c5.png) Jenkins - Newman Konsol Çıktısı
 
 Daha detaylı incelemek için [**buraya**](https://onurerdemiroglu.com.tr/cs-images/jenkins-console-newman.png) tıklayınız.
 
<details>  
  <summary> (<i>Raporu görüntülemek için tıklayın</i>)</summary>
  
 ![jenkins_1](https://user-images.githubusercontent.com/35347777/149655465-42ee2ab6-c41b-4bce-b45a-337ed8417221.png)


</details>
