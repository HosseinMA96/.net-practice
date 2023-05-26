<template>
    <h2>{{ header }}</h2>
    <p>{{ description }}</p>
    <form v-on:submit.prevent="action">
    <p>
      Enter employee id?
      <input type="text" required placeholder="Employee id ..." v-model="employeeId">
    </p>
    
    <p>
      Enter employee name?
      <input type="text" required placeholder="Employee name ..." v-model="employeeName">
    </p>

    <p>
      Enter password?
      <input type="password" required placeholder="Password ..." v-model="password">
    </p>

    <button type="submit">Add employee</button>
    </form>

    <br><br>
    <p  v-show="msg">{{ msg }}</p>


</template>

<script>
import axios from 'axios';
export default {
data() {
    return {
        header: 'Add an employee',
        description: 'Add an employee to the database',
        data: null,
        employeeId: null,
        employeeName: null,
        password: null,
        msg: false
    }
},
methods: {
  async action() {
    try{
      //console.log(this.employeeId + ' ' + this.employeeName + ' ' + this.password)
      const payload =  {"EmpId": this.employeeId ,"Empname":  this.employeeName ,"Password": this.password}
      const response = await axios.post('https://localhost:7133/api/Employees', payload);
      console.log(response.data); // Handle the response data
      this.msg = 'Employee was added'
    }
    catch(erro){
      this.msg = 'Failed to add employee'
    }
  }
}
};
</script>

<style scoped>
#red {
font-weight: bold;
color: rgb(144, 12, 12);
}

button {
background-color: #4CAF50; /* Green */
border: none;
color: white;
padding: 15px 32px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;

}

button:hover {
background-color: #4CAF50; /* Green */
cursor: pointer;
color: white;
}

table {
  font-family: Arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
  margin-bottom: 20px;
}

thead {
  background-color: #333;
  color: #fff;
}

th,
td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

tr:hover {
  background-color: #f5f5f5;
}

tr:nth-child(even) {
  background-color: #f2f2f2;
}
  </style>          