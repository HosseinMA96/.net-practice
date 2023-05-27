<template>
    <h2>{{ header }}</h2>
    <p>{{ description }}</p>
    <button  v-on:click="action" id="mybutton">Get all employees</button>
    <br><br>
    <table  v-show="results">
    <thead>
      <tr>
        <th>id</th>
        <th>College Name</th>
        <th>City</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for='item in data'>
        <td>{{item.EmpId}}</td>
        <td>{{item.Empname}}</td>
        <td>{{item.Password}}</td>
      </tr>
    </tbody>
  </table>

</template>

<script>
import axios from 'axios';
export default {
data() {
    return {
        header: 'Get all employees',
        description: 'Returns all employees in a table',
        results: false,
        data: null
    }
},
methods: {
  async action() {
      const response = await fetch("https://localhost:7133/api/Employees");
      const data = await response.json();
      this.data = data
      this.results = true
      console.log(data[2])

  }
  //https://fontawesomeicons.com/fa/vue-js-json-data-display-in-table
}
};
</script>

<style scoped>
</style>          