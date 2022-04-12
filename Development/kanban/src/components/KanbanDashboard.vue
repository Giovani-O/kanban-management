<template>
  <v-container>
    <h2>Quadros Kanban</h2>

    <v-card class="mt-6" flat color="transparent">
      <v-row>
        <v-col cols="4" v-for="item in items" :key="item.code">
          <v-card class="card-container" @click="goToBoard(item.code)">
            <KanbanCard 
              :cardName="item.name"
              :subjects="item.subjects"
              :activities="item.activities"
              :progress="item.progress"
              :add="item.add"
            ></KanbanCard>
          </v-card>
        </v-col>

        <v-col cols="4">
          <v-card class="card-container" @click="addBoard()">
            <v-card color="transparent" flat outlined>
              <v-row>
                <v-col cols="12" class="text-center ma-2">
                  <v-card 
                    class="kanban-card" 
                    style="
                      border: 2px dashed rgb(63, 63, 63) !important; 
                      display: flex !important;
                      align-items: center !important;
                      justify-content: center;
                      cursor: pointer !important;
                    "
                  >
                    <span>Adicionar quadro</span>
                    <v-icon
                      large
                      color="white"
                    >
                      mdi-plus-box-outline
                    </v-icon>
                  </v-card>
                </v-col>
              </v-row>
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
          
          <v-text-field color="#771cff" label="Nome" v-model="name"></v-text-field>
          <v-select :items="subject" v-model="selectedSubject" label="Disciplinas" color="#771cff"></v-select>
          <v-select :items="status" v-model="selectedStatus" label="Status" color="#771cff"></v-select>
          <v-btn 
            dark color="transparent" 
            class="rounded-pill action-btn mr-4"
            style="border: 1px solid !important; border-color: #771cff !important;"
            @click="saveBoard()"
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
import KanbanCard from './KanbanCard.vue';
import { useBoardStore } from '@/store/boardStore';
import { mapState } from "pinia";
import { bus } from '@/main';

  export default {
    name: 'KanbanDashboard',
    data() {
      return {
        boardStore: '',
        items: [],
        subject: [
          'TCC',
          'Desenvolvimento Web',
          'Sistemas Distribuídos',
          'Projeto Integrador de Programação',
          'Gestão de novos negócios',
        ],
        status: [
          'Em fila',
          'Em progresso',
          'Finalizado'
        ],
        name: '',
        selectedSubject: '',
        selectedStatus: '',
        dialog: false,
        axiosHeaders: {
          'Content-Type': 'application/json',
        },
      }
    },
    components: {
      KanbanCard,
    },
    mounted() {
      this.boardStore = useBoardStore();
      this.getBoards();

    },
    methods: {
      goToBoard(code){
        this.boardStore.setId(code);
        this.$router.push('/kanban/board');
      },

      getBoards() {
        this.loading = true;
        axios
          .get(
            `https://localhost:5001/v1/Board/Get`,
            { headers: this.axiosHeaders }
          )
          .then(response => {
            response.data.forEach(x => {
              var loadedBoard = {
                code: x.id,
                name: x.name,
                subjects: x.subject,
                activities: x.activityCount,
                progress: x.status,
              };
              this.items.push(loadedBoard);
            })
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => this.loading = false)
      },
      addBoard() {
        this.dialog = !this.dialog;
      },
      saveBoard() {
        axios
          .post(
            `https://localhost:5001/v1/Board/Save`,
            {
              Name: this.name,
              Subject: this.selectedSubject,
              Status: this.selectedStatus,
            },
            { headers: this.axiosHeaders }
          )
          .then(response => {
            this.name = '';
            this.selectedSubject = '',
            this.selectedStatus = '',
            this.items = [],
            this.getBoards();
            this.dialog = false;
          })
          .catch(error => {
            console.log("ＳＹＳＴＥＭ　ＥＲＲＯＲ: " + error)
          })
          .finally(() => {this.loading = false; this.currentColumn = '-1';})
      },
    }
  }
</script>

<style>
  .kanban-card {
    height: 190px !important;
  }

  .card-container .container{
    padding: 0px 0px !important;
  }

  .row .text-center {
    margin: 0px 0px !important;
  }
</style>
