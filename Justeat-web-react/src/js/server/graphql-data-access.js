import ApolloClient, { createNetworkInterface } from 'apollo-client';
import gql from 'graphql-tag';


const exports = module.exports = {};

const client = new ApolloClient({
    networkInterface: createNetworkInterface({
        uri: 'http://localhost:4000/graphql',
    }),
});

exports.getRestaurants = (q,page,totalItems) => {
    return client.query({
        query: gql`
        query result($q: String, $page: Int,$totalItems:Int ) {
            restaurants(q:$q,pagination:{
                page : $page,
                totalItems : $totalItems
            }) {
                totalRecords,
                items {
                Name
                RatingStars
                CuisineTypes{
                    Name
                }
                }
            }
        }`,
        variables: {
            q: q,
            page: page,
            totalItems : totalItems
        },
        data: {
            restaurants: [],
        }
    }).then(data => data);
}