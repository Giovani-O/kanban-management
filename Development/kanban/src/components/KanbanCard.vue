<template>
  <v-container>
      <v-card
        :color="color"
      >
        <p>Teste</p>
      </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'KanbanCard',
    data() {
      return {
        props: {
          color: {
            type: String,
            default: '#532a8e',
          }
        }
      }
    }
  }

</script>
