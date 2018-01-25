const mongoose = require('mongoose');

let tripSchema = mongoose.Schema({
    origin: {type:'string',required:'true'},
    destination: {type:'string',required:'true'},
    business: {type:'number',required:'true'},
    economy: {type:'number',required:'true'},
});

let Trip = mongoose.model('Trip', tripSchema);

module.exports = Trip;