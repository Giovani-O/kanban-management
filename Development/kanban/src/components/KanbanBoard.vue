<template>
  <v-container>
    <h1>Quadro</h1>
    <v-card color="transparent" flat class="pa-4">
      <v-row>
        <v-col cols="4">
          <h3>
            Em fila 
            <v-btn fab x-small depressed color="transparent" @click="addActivity()">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in todo" :key="item.id">
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

    <div class="text-center">
      <v-dialog
        v-model="dialog"
        width="900"
        overlay-opacity=".95"
        overlay-color="black"
        dark
        transition="dialog-bottom-transition"
        class="pa-4"
        :scrollable="false"
      >
        <template> 
          <h1 style="color: white">Descreva a atividade</h1>
          
          <v-text-field label="Descrição" v-model="description"></v-text-field>
          <v-btn 
            dark color="transparent" 
            class="rounded-pill action-btn mr-4"
            style="border: 1px solid !important; border-color: #771cff !important;"
            @click="saveActivity()"
            width="100px"
          >
            Salvar
          </v-btn>
        </template>
      </v-dialog>
    </div>

  </v-container>
</template>

<script>
  import axios from "axios";

  export default {
    name: 'KanbanBoard',
    data() {
      return {
        axiosHeaders: {
          'Content-Type': 'application/json',
        },

        // Em fila
        loading: false,
        dialog: false,
        description: '',
        todo: [],
        // Em progresso
        progress: [
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 2,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
        ],
        // Concluído
        finished: [
          {
            code: 1,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 2,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
          {
            code: 3,
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
          },
        ]
      }
    },
    mounted() {
      this.getTodo();
    },
    methods: {

      getTodo(){
        this.loading = true;
        axios
          .get(
            `https://localhost:5001/v1/Get`,
            { headers: this.axiosHeaders }
          )
          .then(response => {
            this.todo = response.data;

            console.log(this.todo);
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => this.loading = false)
      },

      addActivity() {
        this.dialog = !this.dialog;
      },
      saveActivity() {
        axios
          .post(
            `https://localhost:5001/v1/Save`,
            {
              BoardId: '1',
              Text: this.description,
              Column: '1'
            },
            { headers: this.axiosHeaders }
          )
          .then(response => {
            console.log(response);
            this.description = '';
            this.todo = [];
            this.getTodo();
            this.dialog = false;
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => this.loading = false)
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