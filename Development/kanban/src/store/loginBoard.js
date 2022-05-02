import { defineStore } from 'pinia'

export const useLoginStore = defineStore("login", {
  state: () => ({
    email: '',
    username: '',
    usertype: '',
  }),
  getters: {
    getEmail() {
      return this.email
    },
    getUsername() {
      return this.username
    },
    getUsertype() {
      return this.usertype
    }
  },
  actions: {
    setEmail(value) {
      this.email = value;
    },
    setUsername(value) {
      this.username = value;
    },
    setUsertype(value) {
      this.usertype = value;
    },
    reset() {
      this.email = '',
      this.username = '',
      this.usertype = ''
    }
  }
})