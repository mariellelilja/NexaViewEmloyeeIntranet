<template>
  <div class="header-user-status">
    <p v-if="isLoggedIn">
      <span class="online-icon"></span>
      <span class="full-text">Logged in as {{ username }}</span>
      <span class="short-text">Logged in</span>
    </p>
    <p v-else><a href="/login">Log in</a> </p>
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
  position: absolute;
  right: 20px;
  top: 10%;
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

.full-text {
  display: inline;
}

.short-text {
  display: none;
}

@media (max-width: 768px) {
  .full-text {
    display: none;
  }

  .short-text {
    display: inline;
  }
}
</style>