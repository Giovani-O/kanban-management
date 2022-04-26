<template>
  <v-container>
    <v-row>
      <v-col cols="10">
        <h1>Quadro</h1>
      </v-col>
      <v-col cols="2">
        <v-btn color="#771cff" @click="addFile()">Enviar arquivo</v-btn>
      </v-col>
    </v-row>
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
              <h3>
                {{ item.text }}
              </h3>
              <p>
                Descrição...
              </p>
              <p>
                Início: 25/04  -  Fim: 30/04
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
              <h3>
                {{ item.text }}
              </h3>
              <p>
                Descrição...
              </p>
              <p>
                Início: 25/04  -  Fim: 30/04
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
              <h3>
                {{ item.text }}
              </h3>
              <p>
                Descrição...
              </p>
              <p>
                Início: 25/04  -  Fim: 30/04
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
          
          <v-row>
            <v-col cols="12"><v-text-field color="#771cff" label="Nome" v-model="name"></v-text-field></v-col>
            <v-col cols="12"><v-text-field color="#771cff" label="Descrição" v-model="description"></v-text-field></v-col>
            <v-col cols="6"><v-text-field color="#771cff" label="Data de início" v-model="startDate"></v-text-field></v-col>
            <v-col cols="6"><v-text-field color="#771cff" label="Data de fim" v-model="endDate"></v-text-field></v-col>
          </v-row>
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

    <div class="text-center">
      <v-dialog
        v-model="fileDialog"
        width="900"
        overlay-opacity=".95"
        overlay-color="black"
        dark
        transition="dialog-bottom-transition"
        class="pa-4"
        :scrollable="false"
      >
        <template> 
          <h1 style="color: white">Entregar atividade</h1>
          <v-file-input
            label="Arquivo(s)"
            multiple
            small-chips
            color="#771cff"
          ></v-file-input>
          <v-text-field color="#771cff" label="Descrição"></v-text-field>
          <v-btn 
            dark color="transparent" 
            class="rounded-pill action-btn mr-4"
            style="border: 1px solid !important; border-color: #771cff !important;"
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
  import { useBoardStore } from '@/store/boardStore';
  import { mapState } from "pinia";
  import { bus } from '@/main';

  export default {
    name: 'KanbanBoard',
    data() {
      return {
        boardStore: '',
        axiosHeaders: {
          'Content-Type': 'application/json',
        },

        loading: false,
        dialog: false,
        fileDialog: false,
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
      this.boardStore = useBoardStore();
      this.boardId = this.boardStore.getId;
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
              if (x.column == '0' && x.boardId == this.boardId) this.todo.push(x);
              if (x.column == '1' && x.boardId == this.boardId) this.progress.push(x);
              if (x.column == '2' && x.boardId == this.boardId) this.finished.push(x);
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
      addFile() {
        this.fileDialog = !this.fileDialog;
      },
      saveActivity() {
        axios
          .post(
            `https://localhost:5001/v1/Save`,
            {
              BoardId: this.boardId,
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