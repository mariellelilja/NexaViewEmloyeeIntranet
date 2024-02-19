<template>
  <div id="app">
    <AppHeader></AppHeader>
    <MainContent></MainContent>
    <AppFooter></AppFooter>
    <ScrollToTopButton></ScrollToTopButton>
  </div>
</template>

<script>
import AppHeader from './components/AppHeader.vue'
import AppFooter from './components/AppFooter.vue'
import MainContent from './components/MainContent.vue'
import ScrollToTopButton from './components/ScrollToTopButton.vue'


export default {
  name: 'App',
  components: {
    AppHeader,
    MainContent,
    AppFooter,
    ScrollToTopButton,
  }
}

</script>

<style>
#app {
  /* display: flex;
  flex-direction: column; */
  min-height: 100vh;
  color: #2c3e50;
  /* #333 */
}

body {
  margin: 0;
  padding: 0;
}

/* main {
  background-color: #ECEBED;
  padding: 20px;
} */
</style>
