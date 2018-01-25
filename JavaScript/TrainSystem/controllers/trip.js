const Trip = require('../models/Trip');

module.exports = {
    index: (req, res) => {
        Trip.find().then(trips => {
            return res.render('trip/index', {'trips': trips})
        })
    },
    createGet: (req, res) => {
        res.render('trip/create');
    },
    createPost: (req, res) => {
        let trip = req.body;

        Trip.create(trip).then(trip => {
            res.redirect('/')
        })
    },
    editGet: (req, res) => {
        let tripId = req.params.id;
        Trip.findById(tripId).then(trip => {
            if (trip) {
                res.render('trip/edit', trip);
            } else {
                res.redirect('/');
            }
        })
    },
    editPost: (req, res) => {
        let tripId = req.params.id;
        let trip = req.body;

        Trip.findByIdAndUpdate(tripId,trip ,{runValidators:true}).then(trips=>{
            res.redirect("/");
        })
    },
    deleteGet: (req, res) => {
        let tripId=req.params.id;

        Trip.findById(tripId).then(trip=>{
            if (trip){
                res.render('trip/delete',trip);
            } else{
                res.redirect('/');
            }
        })
    },
    deletePost: (req, res) => {
        let tripId=req.params.id;

        Trip.findByIdAndRemove(tripId).then(trips=>{
            res.redirect('/');
        })
    }
};