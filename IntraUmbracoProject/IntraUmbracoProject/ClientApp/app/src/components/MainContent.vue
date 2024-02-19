<template>
  <main>
    <div class="content">
      <div  v-if="isLoggedIn" class="personal-message">
      <h2>Welcome, {{ username }}!</h2>
  <h3>What are you looking for today? </h3>
</div>
<div v-else> <!--Temporary demo solution, TODO route to pages instead etc--->
  <LoginForm></LoginForm>
<RegisterForm></RegisterForm>

</div>
</div>
  </main>
</template>

<script>
// import AppButton from './AppButton.vue';
import RegisterForm from './RegisterForm.vue';
import LoginForm from './LoginForm.vue';
import apiService from '@/services/apiService';

export default {
  name: 'MainContent',
  props: {},/* ['isLoggedIn'],*/
  components: { RegisterForm, LoginForm},
  data() {
    return {
      isLoggedIn:false,
      formData: {
        username: '',
        email: '',
        password: ''
      }
    };
  },
  methods: { /* TODO move auth logic? */
    fetchData() {
      apiService.post("/user/login", {});
    },
    handleSubmit() {
      apiService.post("/user/login", this.formData).then(response => { 
        console.log(response);
      });
    },
    async fetchEmployeeName() {
      try {
        const response = await apiService.get('/api2/user/GetCurrentUserName');
        this.username = response.data;
      } catch (error) {
        console.error('There was an error fetching the employee name:', error);
      }
    },
  }
}
</script>

<style scoped>
main {
  padding-top: 5rem;
  padding-bottom: 5rem;
  background-color: #eeeeee; /** or #e6e3e0, #F4F2EE */
}

.content {
  max-width: 600px;
  margin: 0 auto;
  text-align: center;

}
</style>