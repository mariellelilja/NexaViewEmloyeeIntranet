<template>
  <header class="site-header">
    <div class="header-content">

      <div class="logo-container">
        <img src="@/assets/nw-logo-white.png" alt="NexaView" class="company-logo">
        <h1 class="site-title">Employee Intranet</h1>
      </div>
      <nav class="nav-bar">
        <ul class="nav-list mt-3">
          <li class="nav-item"><router-link class="nav-link active" to="/">Home</router-link></li>
          <!--style menu links, add hovering and click response-->
          <li class="nav-item"><router-link class="nav-link" to="/nvarticles">News</router-link></li>
          <li class="nav-item"><router-link class="nav-link" to="/nvpeople">People</router-link></li>
          <li class="nav-item"><router-link class="nav-link" to="/nvdocs">Documents</router-link></li>
          <li class="nav-item"><router-link class="nav-link" to="/nvresources">Resources</router-link></li>
          <!--TODO: sub > IT Support, HR, Finance, Legal, etc -->
          <li class="nav-item"><router-link class="nav-link" to="/nvsocial">Social</router-link></li>
          <li class="nav-item"><router-link class="nav-link" to="/nvcoe">CoE</router-link></li>
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
      isLoggedIn: true, //TODO logic + refactor/move
      username: 'Lise Mockname',
    };
  },
  created() {  //TODO logic (set status + name) + refactor/move
  },
}
</script>

<style scoped>
.site-title {
  padding: 0.5rem;
  font-family: 'Montserrat', 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: 700;
  font-size: 60px;
  color: rgb(10, 10, 10);
}

.site-header {
  position: relative;
  background-color: #ffffff;
  min-height: 15vh;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.header-content {
  flex-grow: 1;
}

.nav-item {}

.nav-link {
  display: block;
  padding-left: 2rem;
  padding-right: 2rem;
  margin-bottom: 0px !important;
}

.nav-bar {
  width: 100%;
  text-align: center;
}



.logo-container {
  display: flex;
  align-items: self-end;
  justify-content: center;
}

.company-logo {
  height: 90px;
  margin-right: 0.5rem;
}

@media (max-width: 768px) {
  .site-title {
    font-weight: 500;
    font-size: 30px;
  }

  .nav-list {
    display: none;
  }

  .mobile-menu-icon {
    display: block;
  }

  .company-logo {
    height: 70px;
    margin-right: 0.25rem;
    padding: 0.5rem;
  }

}
</style>
