const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => {
            let openTask = [];
            let inProgressTask = [];
            let finishedTask = [];

            for (let i = 0; i < tasks.length; i++) {
                let currentTask = tasks[i];

                if (currentTask.status === 'Open') {
                    openTask.push(currentTask);
                } else if (currentTask.status === "In Progress") {
                    inProgressTask.push(currentTask);
                } else if (currentTask.status === "Finished") {
                    finishedTask.push(currentTask);
                }
            }

            res.render('task/index', {
                'openTasks': openTask,
                'inProgressTasks': inProgressTask,
                'finishedTasks': finishedTask
            });
        });
    },

    createGet: (req, res) => {
        res.render('task/create')
    },

    createPost: (req, res) => {
        let task = req.body;

        Task.create(task).then(task => {
            res.redirect('/');
        });
    },

    editGet: (req, res) => {
        let taskId = req.params.id;

        Task.findById(taskId).then(task => {
                if (task) {
                    res.render('task/edit', task);
                }
            });
    },
        editPost:    (req, res) => {
            let taskId = req.params.id;
            let task = req.body;

            Task.findByIdAndUpdate(taskId,task).then(task=>{
                res.redirect('/');
            });
        }
    };