<template>
    <h2>{{ header }}</h2>
    <p>{{ description }}</p>
    <form v-on:submit.prevent="action">
    <p>
      Enter city name?
      <input type="text" required placeholder="City name ..." v-model="cityName">
    </p>
    
  
    <button type="submit">Get weather</button>
    </form>
  
    <br><br>
      <table  v-show="results">
    <thead>
      <tr>
        <th>temp</th>
        <th>gust</th>
        <th>wind</th>
      </tr>
    </thead>
    <tbody>
      <tr v-if='results'>
        <td>{{msg.temp}}</td>
        <td>{{msg.gust}}</td>
        <td>{{msg.wind}}</td>
      </tr>
    </tbody>
  </table>
  <p v-show="blank">No such city</p>
  
  </template>
  
  <script>
  import axios from 'axios';
  export default {
  data() {
    return {
        header: 'Get weather of a city',
        description: 'Get temperature and wind of a city',
        data: null,
        cityName: null,
        msg: false,
        results: false,
        blank: null
    }
  },
  methods: {
  async action() {
  
      //console.log(this.employeeId + ' ' + this.employeeName + ' ' + this.password)
      const response = await axios.get('https://localhost:7133/api/Weather/' + this.cityName);
      
      if (response.data == "ERROR")
      {
        this.msg = "City doesn\'t exist"
        this.blank = true
        this.results= false
      }
      
      else{
        this.results = true
        this.msg = {temp: response.data.temperature, gust:  response.data.gust,  wind:  response.data.wind }
      }
      console.log(response.data)
  
  }
  }
  };
  </script>
  
  <style scoped>
  </style>          