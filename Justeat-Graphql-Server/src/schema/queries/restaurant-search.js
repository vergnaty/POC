const graphql = require('graphql')
const restaurantTypes = require('./../types/restaurant-types')
const axios = require('axios')
const _ = require('lodash')
const exports = module.exports = {}

const { GraphQLObjectType, GraphQLString, GraphQLInt, GraphQLList, GraphQLNonNull, GraphQLBoolean, GraphQLEnumType, GraphQLInputObjectType } = graphql

exports.search = {
    type: restaurantTypes.ResultType,
    args: {
        q: { type: GraphQLString },
        pagination: { type: restaurantTypes.PaginationType }
    },
    resolve(root, args, ctx) {
        // use spesific endpoint to resolve the current request
        var url = ctx.apiUrls.restaurants + '?q=' + args.q
        return axios.get(url, { headers: root.headers })
            .then(res => pagination(res.data.Restaurants, args.pagination.page, args.pagination.totalItems))
            .catch(function (thrown) {
                console.log('Error', thrown.message)
            })
    }
}

//pagination using lodash and return list of restaurants and totalRecords
const pagination = (data, page, total) => {
    var skip = page == 1 ? 0 : page * total
    var result = {
        items: _.slice(data, skip, skip + total),
        totalRecords: data.length
    }
    return result
}