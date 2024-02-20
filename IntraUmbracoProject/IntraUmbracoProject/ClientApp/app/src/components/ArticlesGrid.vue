<template>
  <div class="articles-grid">
    <div class="nv-article" v-for="article in latestArticles" :key="article.id">
      <div class="article-content">
        <h3 class="colored-title">{{ article.title }}</h3>
        <p>{{ article.summary }}</p>
      </div>
      <div class="article-footer">
        <a :href="article.url">Read more</a>
        <p class="posted-date mt-3">Posted on: {{ formatDate(article.date) }}</p>
      </div>
    </div>
  </div>
</template>
  
<script>
export default {
  name: 'ArticlesGrid',
  data() {
    return {
      articles: []
    };
  },
  computed: {
    latestArticles() {
      // Original array + sorted copy (To avoid mutating original array)
      return [...this.articles]
        .sort((a, b) => new Date(b.date) - new Date(a.date))
        .slice(0, 3);
    }
  },
  async created() {
    await this.fetchArticles();
  },
  methods: {
    async fetchArticles() {
      // MOCK DATA
      // Later: Umbraco backoffice API call
      this.articles = [
        { id: 1, title: 'We are live!', summary: 'The company has now opened, in the heart of Amager', url: '#', date: '2023-01-01' },
        { id: 2, title: 'Say hi to Mr CEO', summary: 'Albert Skov - the man, the myth, the legend', url: '#', date: '2023-01-03' },
        { id: 3, title: 'Praised work', summary: 'Team 1 produced app for Hilmer AB - the response has been amazing', url: '#', date: '2023-01-02' },
      ];
    },
    formatDate(date) {
      return new Date(date).toLocaleDateString('en-US', {
        day: 'numeric',
        month: 'long',
        year: 'numeric'
      });
    }
  }
};
</script>
  
<style scoped>
.articles-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
  /* flex: 3; */
}

/* @media (max-width: 768px) {
  .articles-grid {
    grid-template-columns: 1fr;
  }
} */

@media (max-width: 1200px) {
  .articles-grid {
    grid-template-columns: 1fr;
  }
}

.nv-article {
  border: 1px solid #ccc;
  padding: 20px;
  display: flex;
  /* Make .nv-article a flex container */
  flex-direction: column;
  /* Arrange children in a column */
  justify-content: space-between;
  /* Distribute space between items */
  height: 100%;
}

.nv-article h3,
.nv-article p,
.posted-date,
a {
  /* overflow: hidden; */
  padding: 10px;

  text-align: left;
}

.article-content {
  flex-grow: 1;
}

.article-footer {
  align-self: flex-start;
}

.nv-article h3 {
  font-size: 1.5rem;
}

.nv-article p {
  font-size: 1rem;
  margin-bottom: 3rem;
  ;
}



/* Fun effect with lower underline */
a:hover {
  text-underline-offset: 5px;
}

.posted-date {
  font-style: italic;
  font-size: 14px !important;
  align-self: flex-start;
  margin-bottom: 0rem !important;
}


/* Dynamical sizing (calc with viewpotr): */
/* .nv-article h3 {
  font-size: calc(1rem + 0.5vw);
}

.nv-article p {
  font-size: calc(14px + 0.5vw);
} */
</style>
  