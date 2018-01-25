const userController = require('./../controllers/user');
const homeController = require('./../controllers/home');
const articleController=require('./../controllers/article');


module.exports = (app) => {
    //Main index path:
    app.get('/', homeController.index);

    //Register paths:
    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);

    //Article paths:
    app.get('/article/create',articleController.createGet);
    app.post('/article/create',articleController.createPost);

    app.get('/article/details/:id',articleController.details);

    //Login paths:
    app.get('/user/login', userController.loginGet);
    app.post('/user/login', userController.loginPost);

    //Logout path:
    app.get('/user/logout', userController.logout);
};

