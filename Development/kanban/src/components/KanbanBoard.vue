<template>
  <v-container>
    <h1>Quadro</h1>
    <v-card color="transparent" flat class="pa-4">
      <v-row>
        <v-col cols="4">
          <h3>
            Em fila 
            <v-btn fab x-small depressed color="transparent">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in todo" :key="item.code">
              <p>
                {{ item.text }}
              </p>
            </v-card>
          </v-card>
        </v-col>

        <v-col cols="4">
          <h3>
            Em progresso
            <v-btn fab x-small depressed color="transparent">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in progress" :key="item.code">
              <p>
                {{ item.text }}
              </p>
            </v-card>
          </v-card>
        </v-col>

        <v-col cols="4">
          <h3>
            Finalizados
            <v-btn fab x-small depressed color="transparent">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in finished" :key="item.code">
              <p>
                {{ item.text }}
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
        // Em fila
        todo: [
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
        ],
        // Em progresso
        progress: [
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
        ],
        // Concluído
        finished: [
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
        ]
      }
    }
  }
</script>

<style>
  .activity {
    background-color: rgba(255, 255, 255, .05) !important;
    padding: 12px 12px !important;
    margin-top: 4px !important;
  }

  .activity p {
    text-shadow: none !important;
  }

  .column-card {
    height: auto !important;
  }
</style>