<template>
    <div class="app">
        <div>
            <h1>Mega Blog</h1>
            <router-view></router-view>
        </div>  
    </div>   
</template>

<script>
import Axios from 'axios';
    export default {
        data(){
            return{
            };
        },
        created(){
          
        },
        methods: {
            loadBlog(id) {
              
            }
        }
    };
</script>

<style>
html{
    background: azure;
}
body{
margin: 0;
}
.app{
    display: flex;
    justify-content: center;
}
.app > div{
    max-width: 400px;
    width: 100%;
}
.card,
.post{
    display: block;
    margin-top: 0.5rem;
    padding: 0.5rem;
    background-color: bisque;
    box-shadow: 0 1px 2px 0 #444;
    color: black;
    text-decoration: none;
}
.card:hover{
    cursor: pointer;
}
</style>