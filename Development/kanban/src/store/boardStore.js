import { defineStore } from 'pinia'

export const useBoardStore = defineStore("board", {
  state: () => ({
    id: '',
  }),
  getters: {
    getId() {
      return this.id
    }
  },
  actions: {
    setId(value) {
      this.id = value;
    },
    reset() {
      this.id = '';
    }
  }
})