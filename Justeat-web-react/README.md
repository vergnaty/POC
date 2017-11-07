install nodejs and npm (https://www.npmjs.com/get-npm)

#Make sure that GraphQL-Server is running before to launch the react application

#open command line - execute the following command
npm install 
npm run dev 

#-----------------------------
Server : http://localhost:8080

1.	How long did you spend on the coding test?   What would you add to your        solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.

        - I spent 1h more less for the First example built using AngularJS
        - I spent 3h more less to build using GraphQL, ReactJS , Apollo-client
        - Nice to have - Responsive Application 

2. What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.

        - For the client prospective have GraphQL as Query language for the API is important, for the following reasons :

        - The client can Get only the list of fields needed, this is very usful when you are dealing with mobile/Tablat applications, which evey device could have different requirment and visualization. 
        - Have abstract access layer and unique rather have a lot of APIs, this is very important when you are dealing with microserves which every service has his own responsability and they need to be integrated with the application.
        - GraphQL isn't tied to any specific database or storage engine and is instead backed by your existing code and data


3. How would you track down a performance issue in production? Have you ever had to do this?

    - if you have a proper log, which log everything related to the execution time and which endpoint and which server (very important factor when you have multiple servers manged by load blancer or Queues), then will be good to start to investigate why is taking long time what that specific endpoint dose. 

    - Elastic-Stack is good tool to use for logging and search (Kibana, Logstash, MachineLearinig (detation an expected behavior))

    - Use any tool to check Memory allocation or CPU of that specific server, if you are getting a lot of request and that server can not handle then you should to scale by adding another server (tipically this is done by cloud services (AWS,Azure, Google Cloud))

    - Try to simulate the same request by checking the data you are passing as parameter, in order to understand if that spesific parmeter is causing an issues. 

    -  If the problem is caused by the database is good to use such as explanation plan for Relational Database to understand which statment or query is tacking a long.

    - Dipende on the context you can do different type of investigation, I had multiple times an expected issues in production... Database, API, SPA but its long to explain for every scenarios what I have done... 

4. How would you improve the JUST EAT APIs that you just used?

    - Documentation using swagger or any another tool to understand what i can do using that API
    - Pagination, does not make any sense load a all list of dats, you could face a lot of performance issues due to the paylod is passing though the network. 
    - The API has a lot of informations if the client does not need in one shot then its good practice to split in different endpoints for each context.
    - Nice to have: Use GraphQL for the reason I described above. 

5. Please describe yourself using JSON.

{
    name:"Natnael",
    surename:"Getu",
    role:"Senior Software Developer",
    description : "I love my job and I love to face new challenges to improve my self and what I am doing, do It always better and better!"
    hobbies :["football","travel","photography","coding","cinema","psicology"],
    quote:"help others acchive thier dreams and you will acchive yours!",
    github: "https://github.com/vergnaty"
}