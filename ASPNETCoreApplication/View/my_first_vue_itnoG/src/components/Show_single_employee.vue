<template>
    <h2>{{ header }}</h2>
    <p>{{ description }}</p>
    <form v-on:submit.prevent="action">
    <p>
      Enter employee id?
      <input type="text" required placeholder="Employee id ..." v-model="employeeId">
    </p>
    <button type="submit">Get employee</button>
    </form>

    <br><br>
    <table  v-show="results">
  <thead>
    <tr>
      <th>EmpId</th>
      <th>Empname</th>
      <th>Password</th>
    </tr>
  </thead>
  <tbody>
    <tr v-if='results'>
      <td>{{fetchedEmployee.EmpId}}</td>
      <td>{{fetchedEmployee.Empname}}</td>
      <td>{{fetchedEmployee.Password}}</td>
    </tr>
  </tbody>
</table>
<p v-show="blank">No such employee</p>

</template>

<script>
import axios from 'axios';
export default {
data() {
    return {
        header: 'Get single employee',
        description: 'Return a single employee given its Empid',
        results: false,
        data: null,
        employeeId: null,
        fetchedEmployee : null,
        blank: null
    }
},
methods: {
  async action() {
  
      const response = await fetch("https://localhost:7133/api/Employees/" + this.employeeId);
      const data = await response.json();
      this.data = data
      this.results = true
      this.fetchedEmployee = {"EmpId": data.EmpId ,"Empname":  data.Empname ,"Password": data.Password}
      console.log(data)
      this.blank=false

      if(data.EmpId == null)
      {
        this.results = false
        this.blank = true
      }



  }
}
};
</script>

<style scoped>
</style>          