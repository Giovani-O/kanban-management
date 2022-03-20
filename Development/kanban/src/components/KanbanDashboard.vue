<template>
  <v-container>
    <h2>Quadros Kanban</h2>

    <v-card class="mt-6" flat color="transparent">
      <v-row>
        <v-col cols="4" v-for="item in items" :key="item.code">
          <!-- Adicionar aqui o componente representando o card -->
          <KanbanCard 
            :cardName="item.name"
            :subjects="item.subjects"
            :activities="item.activities"
            :students="item.students"
            :progress="item.progress"
            :add="item.add"
          ></KanbanCard>
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
          },
          {
            code: 6,
            name: 'Quadro 6',
            Add: 'Add',
          },
        ]
      }
    },
    components: {
      KanbanCard,
    }
  }
</script>
