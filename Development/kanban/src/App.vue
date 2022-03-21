<template>
  <v-app>
    <v-navigation-drawer
      class="frame-color"
      v-model="drawer"
      app
    >
      <v-row>
        <!-- Quadros Kanban -->
        <v-col cols="12">
          <v-btn 
            depressed
            class="sidebar-btn mx-0 px-4 py-4"
            @click="goToKanban()"
          >
            <v-icon left>
              mdi-view-dashboard
            </v-icon>
            Quadros
            <v-spacer />
          </v-btn>
        </v-col>

        <!-- Configurações -->
        <v-col cols="12">
          <v-btn 
          depressed 
          class="sidebar-btn mx-0 px-4 py-4" 
          @click="goToSettingsDash()"
        >
            <v-icon left>
                mdi-cog
            </v-icon>
              Configurações
              <v-spacer />
          </v-btn>
        </v-col>
      </v-row>
    
      <!-- Sair -->
      <v-row>
        <v-col 
          cols="12" 
          class="d-flex align-end"
        >
          <v-btn 
            depressed 
            class="sidebar-btn mx-0 px-4 py-4"
          >
            <v-icon left>
                mdi-exit-run
            </v-icon>
              Sair
              <v-spacer />
          </v-btn>
        </v-col>
      </v-row>
    </v-navigation-drawer>

    <v-app-bar app class="frame-color">
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-toolbar-title>Kanban</v-toolbar-title>
    </v-app-bar>

    <v-main 
      class="mb-16 pb-10"
    >
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
// JavaScript, lógica do front-end
  export default {
    data() { 
      return {
        drawer: null,
      }
    },
    methods: {
      goToKanban() { 
        this.$router.push('/');
      },
      goToSettingsDash() { 
        this.$router.push('/settings/dashboard');
      }
    }
  }

</script>

<style>
  .frame-color {
    background-color: #111111 !important;
  }

  .sidebar-btn {
    width: 100% !important;
    text-align: left !important;
    background-color: transparent !important;
  }
</style>