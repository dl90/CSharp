<template>
  <div id="app">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link> |
    <router-link to="/don">Don</router-link> |
    <router-link to="/details/20/Friday/January">Details</router-link>
    <hr />
    <router-view />
    Footer
  </div>
</template>

<script>
export default {
  name: "app",
};
</script>
