<template>
  <button v-if="shouldShowScrollButton" @click="scrollToTop">  
  <svg  id="scrollToTopBtn" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-chevron-up" viewBox="0 0 16 16">
      <path fill-rule="evenodd" d="M7.646 4.646a.5.5 0 0 1 .708 0L12 8.293 12.354 8.646a.5.5 0 0 1 0 .708l-.708.708L8 6.707l-3.646 3.647-.708-.708a.5.5 0 0 1 0-.708l.708-.708L7.646 4.646z"/>
    </svg>
  </button>
</template>
  <!-- <svg id="scrollToTopBtn"  width="24" height="24" viewBox="0 0 24 24" fill="none" class="m-1"><path d="M17 13L12 18L7 13M12 6L12 17" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path></svg>        -->


<script>
export default {
  name: 'ScrollToTopBtn',
  data() {
    return {
      shouldShowScrollButton: false
    };
  },
  mounted(){
    window.addEventListener('scroll', this.handleScroll);
  },
  beforeUnmount() {
    window.removeEventListener('scroll', this.handleScroll);
  },
  props: {},
  methods: {
    handleScroll() {
      this.shouldShowScrollButton = window.scrollY > 0;
    },
    scrollToTop() {
      window.scrollTo({
        top: 0,
        behavior: 'smooth'
      });
    }
  }
}
</script>

<style scoped>
#scrollToTopBtn {
  /* ... other styles ... */
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
}

#scrollToTopBtn {
  position: fixed;
  bottom: 20px;
  right: 20px;
  background-color: rgba(51, 51, 51, 0.75);
  color: #fff;
  border: none;
  padding: 10px;
  padding-left: 15px;
  padding-right: 15px;
  cursor: pointer;
  border-radius: 50%;
}

#scrollToTopBtn:hover {
  display: block;
  animation: bounce 1s ease;
}
@keyframes bounce {
  0% {
    transform: translateY(0);
  }

  50% {
    transform: translateY(-10px);
  }

  75% {
    transform: translateY(3px);
  }

  100% {
    transform: translateY(0);
  }
}
</style>