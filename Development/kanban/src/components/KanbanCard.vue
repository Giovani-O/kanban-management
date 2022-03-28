<template>
  <v-container>
      <v-card class="pa-4 card-height" :color="selectColor">
        <v-row>
          <v-col 
            cols="12" 
            class="mt-2 mb-0 mx-0 pa-0"
          >
            <h4>{{ cardName }}</h4>
          </v-col>

          <v-col 
            cols="12" 
            class="mt-2 mb-0 mx-0 pa-0"
          >
            <p>{{ subjects }}</p>
          </v-col>

          <v-col 
            cols="12" 
            class="mt-2 mb-0 mx-0 pa-0"
          >
            <p>{{ activities }}</p>
          </v-col>

          <v-col 
            cols="6" 
            class="mt-2 mb-0 mx-0 pa-0"
          >
            <p>{{ students }}</p>
          </v-col>

          <v-col 
            cols="6" 
            class="mt-2 mb-0 ml-0 mr-0 pa-0 text-right"
          >
            <p>{{ progress }}</p>
          </v-col>

        </v-row>
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
    computed: {
      selectColor: function() {
        return "#" + Math.floor(Math.random()*16777215).toString(16);
      },
    },
    methods: {

    }
  }

</script>

<style>
  h4, p {
    text-shadow: 4px 2px 6px #000000 !important;
  }

  .card-height {
    height: 30vh !important;
  }
</style>
