<template>
  <div class="registration-form-container">
    <h2 class="form-title">Register to Employee Intranet
    </h2>

    <form @submit.prevent="handleSubmit" class="registration-form">
      <div class="form-group">
        <label for="username" class="form-label">Username:</label>
        <input type="text" id="username" v-model="formData.username" required class="form-control">
      </div>
      <div class="form-group">
        <label for="email" class="form-label">Email:</label>
        <input type="email" id="email" v-model="formData.email" required class="form-control">
      </div>
      <div class="form-group">
        <label for="password" class="form-label">Password:</label>
        <input type="password" id="password" v-model="formData.password" required class="form-control">
      </div>
      <AppButton type="submit" :buttonId="'registerButton'" :buttonText="'Register'"
        :styleClass="['m-3', 'nvi-btn', 'nvi-btn-primary']"></AppButton>
    </form>
    <p class="mt-5, m-4">Already registered? </p>
    <!---TODO style btn-wide and set @click to route to login:-->
    <AppButton :buttonId="'toLoginBtn'" :buttonText="'Log in'"
      :styleClass="['nvi-btn', 'nvi-btn-secondary', 'nvi-btn-wide']"></AppButton>

  </div>
</template>

  
<script>
import AppButton from './AppButton.vue';
import apiService from '@/services/apiService';

export default {
  name: 'MainContent',
  props: {},
  components: { AppButton },
  data() {
    return {
      formData: {
        username: '',
        email: '',
        password: ''
      }
    };
  },
  methods: { /* TODO move auth logic? */
    fetchData() {
      apiService.post("/user/CreateUser", {});  /* "/user/login" */
    },
    handleSubmit() {
      apiService.post("/user/CreateUser", this.formData).then(response => { /* "/user/login" */
        console.log(response);
      });
    },
  }
}
</script>
  
<style scoped>
.registration-form-container {
  visibility: hidden;
  /** Until pages are implemented */
  max-width: 500px;
  margin: 0 auto;
  padding: 20px;
  /* background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); */
}

.form-title {
  margin-bottom: 1.5rem;
  color: #333;
  text-align: center;
}

.registration-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-label {
  margin-bottom: 0.5rem;
  font-weight: bold;
  color: #444;
}

.form-control {
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1rem;
}

/* .submit-btn {
    margin-top: 1rem;
  padding: 12px 20px;
  background-color: #4CAF50;
  color: #fff;
  border: none;
  border-radius: 4px;
  font-family: 'Montserrat', sans-serif;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.3s ease, box-shadow 0.2s ease;
  outline: none;
} 

.submit-btn:hover {
    background-color: #45a049; 
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}
.submit-btn:focus {
  box-shadow: 0 0 0 3px rgba(72, 159, 74, 0.5); 
}
.submit-btn:active {
  background-color: #3e8e41;
  box-shadow: none;
} */
</style>