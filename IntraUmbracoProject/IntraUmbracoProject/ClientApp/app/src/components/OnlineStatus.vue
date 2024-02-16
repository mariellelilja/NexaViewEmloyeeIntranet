<template>
  <div class="header-user-status">
    <p v-if="isLoggedIn">
      <span class="online-icon"></span> You are logged in as {{ username }}
    </p>
    <p v-else><a href="/login" >Log in</a> </p>    
  </div>
</template>

<script>
export default {
    name: 'OnlineStatus',
    props: ['isLoggedIn', 'username'],
}
</script>

<style scoped>
.header-user-status {
  margin: 1rem;
    position: absolute	;
    right: 20px;
    top:10%;
    transform: translateY(-50%);
    white-space: nowrap;
  /* display: flex;
  align-items: center;
  gap: 10px;
  margin-right: 2rem;
  margin-top: -10rem; */
  max-width: 400px;
  overflow: hidden;
  text-overflow: ellipsis;
}

.online-icon {
  width: 10px;
  height: 10px;
  background-color: green;
  border-radius: 50%;
  display: inline-block;
  margin-right: 5px;
}
</style>