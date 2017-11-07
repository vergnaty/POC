const graphql = require('graphql');
var exports = module.exports = {};

const {
    GraphQLObjectType,
    GraphQLString,
    GraphQLInt,
    GraphQLSchema,
    GraphQLList,
    GraphQLNonNull,
    GraphQLBoolean,
    GraphQLEnumType,
    GraphQLInputObjectType
} = graphql;

exports.PaginationType = new GraphQLInputObjectType({
    name: 'PaginationType',
    fields: () => ({
        page: { type: GraphQLInt },
        totalItems: { type: GraphQLInt }
    })
});

exports.CuisineType = new GraphQLObjectType({
    name: 'CuisineTypes',
    fields: () => ({
        Id: { type: GraphQLInt },
        Name: { type: GraphQLString },
        SeoName: { type: GraphQLString }
    })
});

exports.ResultType = new GraphQLObjectType({
    name: 'ResultType',
    fields: () => ({
        items: { type: new GraphQLList(exports.RestaurantType) },
        totalRecords: { type: GraphQLInt }
    })
});

exports.RestaurantType = new GraphQLObjectType({
    name: 'RestaurantType',
    fields: () => ({
        Name: { type: GraphQLString },
        Address: { type: GraphQLString },
        City: { type: GraphQLString },
        RatingStars: { type: GraphQLInt },
        Postcode: { type: GraphQLString },
        CuisineTypes: { type: new GraphQLList(exports.CuisineType) }
    })
});