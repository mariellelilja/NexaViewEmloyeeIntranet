<template>
    <footer>
      <div class="footer-content">

        <div class="company-info">
          <!--Contact information-->
          <p>NexaView, Copenhagen</p>
          <p>Amagergade 51</p>
          <p>&copy; 2024 NV </p>
        </div>

        <div class="company-map-container">
          <p>Find us!</p>
          <GoogleMap></GoogleMap>
        </div>

      </div>
    </footer>
</template>

<script>
import GoogleMap from './GoogleMap.vue'

export default {
    name: 'AppFooter',
    components: {GoogleMap}
}
</script>

<style scoped>
footer {
  background-color: #333;
  color: #fff;
  padding: 3rem;
}

.footer-content{
  display: flex;
  justify-content: center;
  align-items: center;
}

.company-info, .company-map-container {
  padding: 0 3rem; /* Add some padding for spacing */
}

p {
  text-align: left;
}
</style>