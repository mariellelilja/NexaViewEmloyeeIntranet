<template>
  <div class="login-form-container">
    <h2 class="form-title">Login to Employee Intranet</h2>
    <form @submit.prevent="handleSubmit" class="login-form row g-3 needs-validation" novalidate>
      <div class="form-group">
        <label for="username" class="form-label">Username: </label>
        <input type="text" id="username" v-model="formData.username" :class="{ 'input-error': errors.username }" required
          class="form-control">
        <div v-if="errors.username" class="error-message">{{ errors.username }}</div>
      </div>
      <!-- <div class="form-group">
        <label for="email" class="form-label">Email:</label>
        <input type="email" id="email" v-model="formData.email" required class="form-control">
      </div> -->
      <div class="form-group">
        <label for="password" class="form-label">Password: </label>
        <input type="password" id="password" v-model="formData.password" :class="{ 'input-error': errors.password }"
          required class="form-control">
        <div v-if="errors.password" class="error-message">{{ errors.password }}</div>
      </div>
      <div class="form-group">
        <AppButton :disabled="isLoading" type="submit" :buttonId="'loginButton'" :buttonText="'Log in'"
          :styleClass="['nvi-btn', 'nvi-btn-primary']"></AppButton>
        <div class="feedback-container">
          <LoadingIndicator :isLoading="isLoading"></LoadingIndicator>
        </div>
      </div>
    </form>
    <div class="wide-container">
      <p class="mt-5 m-4">Not registered yet? </p>
      <!---TODO style btn-wide and set @click to route to login:-->
      <!--TODO, as it is internal website, should say 'Request an account', and backoffice should be set to only grant membership after admins approval-->
      <AppButton :buttonId="'toRegistrationBtn'" :buttonText="'Register'" :styleClass="['nvi-btn', 'nvi-btn-secondary']">
      </AppButton>
    </div>
  </div>
</template>


  
<script>
import AppButton from './AppButton.vue';
import apiService from '@/services/apiService';
import LoadingIndicator from './LoadingIndicator.vue';

export default {
  name: 'LoginForm',
  props: {},
  components: { AppButton, LoadingIndicator },
  data() {
    return {
      formData: {
        username: '',
        // email: '',
        password: ''
      },
      errors: {
        username: 'This user does not exist', //hardcoded for demo purpose, until fixed
        password: ''
      },
      isLoading: true,
      errorMessage: ''
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
  }
}
</script>
  
<style scoped>
.login-form-container {
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

.login-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.wide-container {
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

/** TODO move */
.input-error {
  border-color: #ff3860;
  /* Red border color */
}

.error-message {
  color: #ff3860;
  /* Red text color */
  margin-top: 0.25rem;
  font-size: 0.875rem;
}</style>