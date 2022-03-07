<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-row>
        <v-col cols="12">
          <v-btn block class="mx-2 px-4 py-2">
            Quadros
          </v-btn>
        </v-col>

        <v-col cols="12">
          <v-btn block class="mx-2 px-4 py-2">
            Forum de Disciplinas
          </v-btn>
        </v-col>

        <v-col cols="12">
          <v-btn block class="mx-2 px-4 py-2">
            Configurações
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