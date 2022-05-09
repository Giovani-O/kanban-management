<template class="main">
  <v-container class="background d-flex align-center justify-center">
    <v-card width="40%" height="71vh" class="mt-12 mb-12 pa-4" color="rgb(0, 0, 0, 0.7)">
      <h1>Login</h1>
      <v-text-field color="#771cff" label="E-mail" type="email"></v-text-field>

      <v-text-field color="#771cff" label="Senha" type="password"></v-text-field>

      <v-row>
        <v-col cols="6">
          <v-btn width="100%" color="#771cff">Login</v-btn>
        </v-col>
        <v-col cols="6">
          <v-btn width="100%" color="#222222" @click="createAccount()">Criar conta</v-btn>
        </v-col>
      </v-row>

      <v-img
        class="mt-14"
        src="../assets/logo.png"
      ></v-img>
    </v-card>
  </v-container>
</template>

<script>
  export default {
    name: 'Login',
    data() {
      return {

      }
    },
    methods: {
      createAccount() {
        this.$router.push('register');
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
