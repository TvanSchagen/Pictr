<script setup lang="ts">
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <img class="spin" alt="Vue logo" src="./assets/camera.png" />
  <HelloWorld msg="Welkom bij Pictr." />
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.spin {
  animation-name: spin;
  animation-duration: 15000ms;
  animation-iteration-count: infinite;
  animation-timing-function: linear; 
}
@keyframes spin {
    from {
        transform:rotate(0deg);
    }
    to {
        transform:rotate(360deg);
    }
}
</style>
