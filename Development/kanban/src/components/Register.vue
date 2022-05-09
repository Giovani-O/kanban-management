<template class="main">
  <v-container class="background d-flex align-center justify-center">
    <v-card width="40%" height="71vh" class="mt-12 mb-12 pa-4" color="rgb(0, 0, 0, 0.7)">
      <h1>Criar conta</h1>

      <v-text-field color="#771cff" label="Nome" type="name"></v-text-field>
      <v-text-field color="#771cff" label="E-mail" type="email"></v-text-field>
      <v-text-field color="#771cff" label="Senha" type="password"></v-text-field>
      <v-switch
        color="#771cff"
        label="Professor?"
      ></v-switch>

      <v-row>
        <v-col cols="12">
          <v-btn width="100%" color="#771cff">Registrar</v-btn>
        </v-col>
      </v-row>

    </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'Register',
    data() {
      return {

      }
    }
  }
</script>

<style>
  .background {
    background: url('../assets/background.png') !important;
    background-size: cover !important;
    margin: 0, 0, 0, 0 !important;
    max-width: 100%;
    max-height: 100%;
  }
</style>
