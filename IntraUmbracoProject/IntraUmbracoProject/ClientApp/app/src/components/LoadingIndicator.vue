<template>
  <div v-if="isLoading" class="loading-container text-primary" role="status">
    <div class="spinner">
      <svg viewBox="0 0 50 50">
        <circle class="path" cx="25" cy="25" r="20" fill="none" stroke-width="5"></circle>
      </svg>
    </div>
  </div>
  <p>Loading...</p>
</template>

<script>
export default {
  name: 'LoadingIndicator',
  props: {
    isLoading: Boolean
  }
}
</script>
  
<style scoped>
.loading-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100px;
}

.spinner {
  width: 30px;
  height: 30px;
  stroke: #5652bf;
  stroke-linecap: round;
  animation: spin 3s linear infinite;
}

.spinner .path {
  stroke: #5652bf;
  stroke-linecap: round;
  animation: spin linear infinite;
  /* 
    stroke-linecap: round;
    stroke-dasharray: 80;
    stroke-dashoffset: 0; */

}

.spinner svg {
  display: block
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
    stroke-dasharray: 1, 200;
    stroke-dashoffset: 0;
  }

  50% {
    stroke-dasharray: 89, 200;
    stroke-dashoffset: -35px;
  }

  100% {
    transform: rotate(360deg);
    stroke-dasharray: 89, 200;
    stroke-dashoffset: -124px;
  }
}
</style>
  