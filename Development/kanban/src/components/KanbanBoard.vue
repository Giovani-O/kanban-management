<template>
  <v-container>
    <h1>Quadro</h1>
    <v-card color="transparent" flat class="pa-4">
      <v-row>
        <v-col cols="4">
          <v-card class="pa-1">
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
          </v-card>
        </v-col>

        <v-col cols="4">
          <v-card class="pa-1">
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
          </v-card>
        </v-col>

        <v-col cols="4">
          <v-card class="pa-1">
            <v-card class="activity">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </v-card>
          </v-card>
        </v-col>
      </v-row>
    </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'KanbanBoard',
    data() {
      return {

      }
    }
  }
</script>

<style>
  .activity {
    background-color: rgba(255, 255, 255, .2) !important;
    padding: 12px 12px !important;
    margin-top: 4px !important;
  }
</style>