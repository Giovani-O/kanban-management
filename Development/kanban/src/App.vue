<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-row>
        <v-col cols="12">
          <v-btn depressed class="mx-2 px-4 py-2">
            <v-icon left>
              mdi-view-dashboard
            </v-icon>
            Quadros
          </v-btn>
        </v-col>

        <v-col cols="12">
          <v-btn depressed class="mx-2 px-4 py-2">
          <v-icon left>
              mdi-forum
          </v-icon>
            Forum de Disciplinas
          </v-btn>
        </v-col>

        <v-col cols="12">
          <v-btn depressed class="mx-2 px-4 py-2">
          <v-icon left>
              mdi-cog
          </v-icon>
            Configurações
          </v-btn>
        </v-col>

        <v-col cols="12" align-self="end">
          <v-btn depressed class="mx-2 px-4 py-2">
          <v-icon left>
              mdi-exit-run
          </v-icon>
            Sair
          </v-btn>
        </v-col>
      </v-row>
    </v-navigation-drawer>

    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-toolbar-title>Application</v-toolbar-title>
    </v-app-bar>

    <v-main>
      <!--  -->
    </v-main>
  </v-app>
</template>

<script>
  export default {
    data: () => ({ drawer: null }),
  }
</script>