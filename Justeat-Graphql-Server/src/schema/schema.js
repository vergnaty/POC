const graphql = require('graphql');
const restaurantSearch = require('./queries/restaurant-search.js');
const { GraphQLSchema, GraphQLObjectType } = graphql;

//Root query access layer 
const RootQuery = new GraphQLObjectType({
    name: 'RootQueryType',
    fields: () => ({
        restaurants: restaurantSearch.search
    })
})

module.exports = new GraphQLSchema({
    query: RootQuery
});