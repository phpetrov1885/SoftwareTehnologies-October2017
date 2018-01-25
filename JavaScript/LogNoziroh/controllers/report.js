const Report = require('../models/Report');

module.exports = {
    index: (req, res) => {
        Report.find().then(reports=>{
            return res.render('report/index',{'reports':reports})
        })

    },
    createGet: (req, res) => {
        res.render('report/create');
    },
    createPost: (req, res) => {
        let report = req.body;

        Report.create(report).then(report=>{
            res.redirect('/');
        })
    },
    detailsGet: (req, res) => {
        let reportId=req.params.id;

        Report.findById(reportId).then(report=> {
            if (report) {
                res.render('report/details', report);
            }
        })
    },

    deleteGet: (req, res) => {
        let reportId=req.params.id;

        Report.findById(reportId).then(report=> {
            if (report) {
                res.render('report/delete', report);
            }
        })
    },
    deletePost: (req, res) => {
        let reportId=req.params.id;

        Report.findByIdAndRemove(reportId).then(report=>{
            res.redirect('/');
        })
    }

};