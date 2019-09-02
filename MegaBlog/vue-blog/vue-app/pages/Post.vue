<template>
        <div>
            <div v-if="selectedBlog" class="post">
                <header>{{selectedBlog.title}}</header>
                <div>{{selectedBlog.body}}</div>
            </div>
            <div v-else>
                Loading Blog...
            </div>
            <router-link to="/">I'm done reading.</router-link>
        </div>
</template>

<script>
import { mapState, mapActions } from "vuex";
export default {
    created() {
        this.loadBlog(this.$route.params.id);
    },
    methods: mapActions(["loadBlog"]),
    beforeRouteLeave(to, from, next) {
        this.$store.commit('clearBlog');
        next();
    },
    computed: mapState(["selectedBlog"])
};
</script>

<style>
</style>