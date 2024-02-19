<template>
  <header class="site-header">
    <div class="header-content">

      <div class="logo-container">
        <img src="@/assets/nw-logo-white.png" alt="NexaView" class="company-logo">
        <h1 class="site-title">Employee Intranet</h1>
      </div>
    <nav class="nav-bar">
      <ul class="nav-list">
        <li class="nav-item"><a class="nav-link active" href="#">Home</a></li> <!--style menu links, add hovering and click response-->
        <li class="nav-item"><a class="nav-link" href="#">News</a></li>
        <li class="nav-item"><a class="nav-link" href="#">People</a></li>
        <li class="nav-item"><a class="nav-link" href="#">Documents</a></li>
        <li class="nav-item"><a class="nav-link" href="#">Resources</a></li> <!--TODO: sub > IT Support, HR, Finance, Legal, etc -->
        <li class="nav-item"><a class="nav-link" href="#">Social</a></li>
        <li class="nav-item"><a class="nav-link" href="#">CoE</a></li>
        </ul>
    </nav>
  </div>
  <OnlineStatus :is-logged-in="isLoggedIn" :username="username"></OnlineStatus>
  </header>
</template>

<script>
import OnlineStatus from './OnlineStatus.vue';

export default {
  name: 'AppHeader',
  components: {
    OnlineStatus,
  },
  data() {
    return {
      isLoggedIn: false, //TODO logic + refactor/move
      username: '...',
    };
  },
  created() {  //TODO logic (set status + name) + refactor/move
  },
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@600&display=swap'); /* TODO include final fonts globally in proj */
.site-title {
  padding: 2rem;
  font-family: 'Montserrat', 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: 700;
  font-size: 3rem;
  color: rgb(10, 10, 10);
  /* text-shadow: 
  -1px -1px 0 #fff,  
     1px -1px 0 #fff,
    -1px  1px 0 #fff,
     1px  1px 0 #fff,
    -2px  0 0 #fff,
     2px  0 0 #fff,
     0  2px 0 #fff,
     0 -2px 0 #fff,
    -2px -2px 0 #fff,
     2px -2px 0 #fff,
    -2px  2px 0 #fff,
     2px  2px 0 #fff; */
}
.site-header {
  padding: 10px 10px;
  position:relative;
  background-color: #ffffff;
  min-height: 35vh;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 20px; 
}
.header-content {
  flex-grow: 1;
}

.nav-item{
  padding: 1rem;
  /* margin:1rem; */
}
.nav-link {
  padding: 0.5rem 1rem;
  display: block;
}

.nav-bar{
  width: 100%;
  margin-left: 2rem;
  margin-right: 20rem;
}

@media (max-width: 768px) {
  .nav-list {
    display: none;
  }
  .mobile-menu-icon {
    display: block;
  }}

  .logo-container {
  display: flex;
  align-items: center;
  justify-content: center;
}

.company-logo {
  height: 100px; /* Adjust based on your preference */
  margin-right: 1rem;
}

</style>
