<template>
  <v-container>
      <v-card>
        <h4>{{ cardName }}</h4>
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
    },
    data() {
      return {
        
      }
    },
  }

</script>
