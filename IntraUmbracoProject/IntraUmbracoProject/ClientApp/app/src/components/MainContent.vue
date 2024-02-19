<template>
  <main>
    <div class="main-content">
      <div v-if="isLoggedIn">
        <LandingDashboard></LandingDashboard>



      </div>
      <div v-else> <!--Temporary demo solution, TODO route to pages instead etc--->
        <LoginForm></LoginForm>
        <RegisterForm></RegisterForm>
      </div>


    </div>
  </main>
</template>

<script>
import RegisterForm from './RegisterForm.vue';
import LoginForm from './LoginForm.vue';
import apiService from '@/services/apiService';
import LandingDashboard from './LandingDashboard.vue';


export default {
  name: 'MainContent',
  props: {},/* ['isLoggedIn'],*/
  components: { RegisterForm, LoginForm, LandingDashboard },
  data() {
    return {
      isLoggedIn: true,
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
  padding-top: 3rem;
  padding-bottom: 3rem;
  background-color: #eeeeee;
  /** or #e6e3e0, #F4F2EE */
}

.main-content {
  padding-top: 2rem;
  padding-left: 2.5rem;
  padding-right: 2.5rem;
}
</style>