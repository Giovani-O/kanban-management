<template>
  <v-container>
    <h2>Quadros Kanban</h2>

    <v-card class="mt-6" flat color="transparent">
      <v-row>
        <v-col cols="4" v-for="item in items" :key="item.code">
          <v-card class="card-container" @click="goToBoard()">
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
          <v-card class="card-container">
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
  </v-container>
</template>

<script>
import axios from "axios";
import KanbanCard from './KanbanCard.vue';

  export default {
    name: 'KanbanDashboard',
    data() {
      return {
        items: []
      }
    },
    components: {
      KanbanCard,
    },
    mounted() {
      this.getBoards();
    },
    methods: {
      goToBoard(){
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
                activities: 'N Atividades',
                progress: x.status,
              };
              this.items.push(loadedBoard);
            })
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
