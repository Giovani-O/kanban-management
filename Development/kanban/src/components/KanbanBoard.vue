<template>
  <v-container>
    <h1>Quadro</h1>
    <v-card color="transparent" flat class="pa-4">
      <v-row>
        <v-col cols="4">
          <h3>
            Em fila 
            <v-btn fab x-small depressed color="transparent" @click="addActivity('0')">
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
            <v-btn fab x-small depressed color="transparent" @click="addActivity('1')">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in progress" :key="item.id">
              <p>
                {{ item.text }}
              </p>
            </v-card>
          </v-card>
        </v-col>

        <v-col cols="4">
          <h3>
            Finalizados
            <v-btn fab x-small depressed color="transparent" @click="addActivity('2')">
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </h3>

          <v-card class="pa-1 column-card">
            <v-card draggable class="activity" v-for="item in finished" :key="item.id">
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
          
          <v-text-field color="#771cff" label="Descrição" v-model="description"></v-text-field>
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
  import { bus } from '@/main'

  export default {
    name: 'KanbanBoard',
    data() {
      return {
        axiosHeaders: {
          'Content-Type': 'application/json',
        },

        loading: false,
        dialog: false,
        description: '',
        currentColumn: '-1',
        boardId: '',
        // Em fila
        todo: [],
        // Em progresso
        progress: [],
        // Concluído
        finished: []
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
            response.data.forEach(x => {
              if (x.column == '0' /* && x.boardId == this.boardId */) this.todo.push(x);
              if (x.column == '1' /* && x.boardId == this.boardId */) this.progress.push(x);
              if (x.column == '2' /* && x.boardId == this.boardId */) this.finished.push(x);
            })
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => this.loading = false)
      },

      addActivity(boardId) {
        this.currentColumn = boardId;
        this.dialog = !this.dialog;
      },
      saveActivity() {
        axios
          .post(
            `https://localhost:5001/v1/Save`,
            {
              BoardId: 1,
              Text: this.description,
              Column: this.currentColumn,
            },
            { headers: this.axiosHeaders }
          )
          .then(response => {
            this.description = '';
            this.todo = [];
            this.progress = [];
            this.finished = [];
            this.getTodo();
            this.dialog = false;
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => {this.loading = false; this.currentColumn = '-1';})
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