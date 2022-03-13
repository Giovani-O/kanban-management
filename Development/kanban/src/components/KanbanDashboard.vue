<template>
  <v-container>
    <h2>Quadros Kanban</h2>

    <v-card class="mt-6" flat color="transparent">
      <v-row>
        <v-col cols="4" v-for="item in items" :key="item.code">
          <!-- Adicionar aqui o componente representando o card -->
          Teste
        </v-col>
      </v-row>
    </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'KanbanDashboard',
    data() {
      return {
        items: [
          {
            code: 1,
            name: 'Quadro 1',
          },
          {
            code: 2,
            name: 'Quadro 2',
          },
          {
            code: 3,
            name: 'Quadro 3',
          },
          {
            code: 4,
            name: 'Quadro 4',
          },
          {
            code: 5,
            name: 'Quadro 5',
          },
        ]
      }
    }
  }
</script>
