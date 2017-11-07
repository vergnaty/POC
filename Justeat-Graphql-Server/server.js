const express = require('express');
const session = require('express-session');
const expressGraphQL = require('express-graphql');
const schema = require('./src/schema/schema');

const app = express();

app.use(function(req, res, next) {
    var oneof = false;
    if (req.headers.origin) {
        res.header('Access-Control-Allow-Origin', req.headers.origin);
        oneof = true;
    }
    if (req.headers['access-control-request-method']) {
        res.header('Access-Control-Allow-Methods', req.headers['access-control-request-method']);
        oneof = true;
    }
    if (req.headers['access-control-request-headers']) {
        res.header('Access-Control-Allow-Headers', req.headers['access-control-request-headers']);
        oneof = true;
    }
    if (oneof) {
        res.header('Access-Control-Max-Age', 60 * 60 * 24 * 365);
    }

    // intercept OPTIONS method
    if (oneof && req.method == 'OPTIONS') {
        res.send(200);
    } else {
        next();
    }
});

app.use('/graphql', expressGraphQL({
    schema,
    graphiql: true,
    rootValue: {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Basic VGVjaFRlc3RBUEk6dXNlcjI=",
            // "Accept-Tenant": "uk",
            "Accept-Language": "en-GB"
        }
    },
    context: {
        apiUrls: {
            restaurants: 'https://public.je-apis.com/restaurants'
        }
    }
}));

app.listen(4000, () => {
    console.log('GraphQL running on http://localhost:4000/graphql');
});