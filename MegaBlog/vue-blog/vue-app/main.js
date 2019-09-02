import Vue from "vue";
import App from "./App.vue";
import Vuex from "vuex";
import VueRouter from "vue-router";
import Axios from 'axios';
import Main from "./pages/Main.vue";
import Post from "./pages/Post.vue";

Vue.use(Vuex);
Vue.use(VueRouter);

var store = new Vuex.Store({
    state: {
        blogs: [],
        selectedBlog: null     
    },
    mutations: {
        saveBlogs(state, blogs){
            state.blogs = blogs;
        },
        saveBlog(state, blogs){
            state.selectedBlog = blogs;
        },
        clearBlog(state) {
            state.selectedBlog = null;
        }
        
    },
    actions: {
        loadBlogs({ commit }){
            Axios.get('./blog').then(res =>{
                commit("saveBlogs", res.data);
            });
        },
        loadBlog({ commit }, id){
            Axios.get(`/blog/${id}`).then(res =>{
                commit("saveBlog",res.data);
            });
        }
    }
})

var router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '/',
            component: Main
        },
        {
            path: '/:id',
            component: Post
        }
    ]
})

var app = new Vue({
    store,
    router,
    render: h => h(App)
});

app.$mount('#app')