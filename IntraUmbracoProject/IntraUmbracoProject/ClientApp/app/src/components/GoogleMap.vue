<template>
    <div class="map-container">
        <a href="https://www.google.com/maps?q=Your+Company+Address" target="_blank" rel="noopener noreferrer" class="map-link">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2250.7821458616213!2d12.605073576603129!3d55.657997999289634!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4652534d04f60957%3A0xf9af3c20ef935eff!2sst1%2C%20Englandsvej%201%2C%202300%20K%C3%B8benhavn!5e0!3m2!1ssv!2sdk!4v1708190259752!5m2!1ssv!2sdk" width="300" height="150" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </a>
    </div>
</template>

<script>
export default {
    name: 'GoogleMap'
}
</script>

<style scoped>
.map-container {
  position: relative;
}

.map-link {
  /* position: absolute; */
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 1;
}

iframe {
  filter: sepia(50%);
  border-top-right-radius: 20%;
  border-bottom-left-radius: 20%;

}
</style>