<template>
    <h2>{{ header }}</h2>
    <p>{{ description }}</p>
    <form v-on:submit.prevent="action">
    <p>
      Enter employee id?
      <input type="text" required placeholder="Employee id ..." v-model="employeeId">
    </p>
    <button type="submit">Delete employee</button>
    </form>
  
    <p v-show="results">{{ msg }}</p>
  
  </template>
  
  <script>
  import axios from 'axios';
  export default {
  data() {
    return {
        header: 'Delete an employee',
        description: 'Delete an employee given its Empid',
        results: false,
        msg: 'null',
        data: null
    }
  },
  methods: {
  async action() {
  
      const response = await axios.delete("https://localhost:7133/api/Employees/" + this.employeeId);
      this.data = response.data
      console.log(response.data) 
      this.results = true
      if (this.data.StatusCode == 404)
        this.msg = 'Employee doesn\'t exist'
      
        else
        this.msg = 'Employee successfully deleted'
  
    }
  }
  };
  </script>
  
  <style scoped>
  </style>          