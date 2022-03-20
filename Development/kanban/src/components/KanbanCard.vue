<template>
  <v-container>
      <v-card>
        <h4>{{ cardName }}</h4>
        <h4>{{ subjects }}</h4>
        <h4>{{ activities }}</h4>
        <h4>{{ students }}</h4>
        <h4>{{ progress }}</h4>
        <h2>{{ add }}</h2>
      </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'KanbanCard',
    props: {
      cardName: {
        type: String,
        default: '',
      },
      subjects: {
        type: String,
        default: '',
      },
      activities: {
        type: String,
        default: '',
      },
      students: {
        type: String,
        default: '',
      },
      progress: {
        type: String,
        default: '',
      },
      add: {
        type: String,
        default: '',
      },
    },
    data() {
      return {
        
      }
    },
  }

</script>
