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
              :students="item.students"
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
import KanbanCard from './KanbanCard.vue';

  export default {
    name: 'KanbanDashboard',
    data() {
      return {
        items: [
          {
            code: 1,
            name: 'Quadro 1',
            subjects: 'Subjects',
            activities: 'Activities',
            students: 'Students',
            progress: 'Progress',
          },
          {
            code: 2,
            name: 'Quadro 2',
            subjects: 'Subjects',
            activities: 'Activities',
            students: 'Students',
            progress: 'Progress',
          },
          {
            code: 3,
            name: 'Quadro 3',
            subjects: 'Subjects',
            activities: 'Activities',
            students: 'Students',
            progress: 'Progress',
          },
          {
            code: 4,
            name: 'Quadro 4',
            subjects: 'Subjects',
            activities: 'Activities',
            students: 'Students',
            progress: 'Progress',
          },
          {
            code: 5,
            name: 'Quadro 5',
            subjects: 'Subjects',
            activities: 'Activities',
            students: 'Students',
            progress: 'Progress',
          }
        ]
      }
    },
    components: {
      KanbanCard,
    },
    methods: {
      goToBoard(){
        this.$router.push('/kanban/board');
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
