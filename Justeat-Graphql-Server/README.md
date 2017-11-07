install nodejs and npm (https://www.npmjs.com/get-npm)

#open command line - execute the following command
npm install 
npm run start 

#----------------------------------------------
Graphql-server :  http://localhost:4000/graphql
Query example : 
{
 {
  restaurants(q: "se19", pagination: {page: 1, totalItems: 10}) {
   totalRecords
   items {
     Name
     Address
     City
     RatingStars
     Postcode
     CuisineTypes {
       Name
     }
   }
   
  }
 }
}