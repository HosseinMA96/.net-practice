<template>

  <p>Choose what part of this page you want to see:</p>
  <router-link to="/weather">Weather</router-link><br>
  <router-link to="/add">Add</router-link><br>
  <router-link to="/delete">Delete</router-link><br>
  <router-link to="/all">All</router-link><br>
  <router-link to="/single">single</router-link><br>
   <div>
   <router-view></router-view>
   </div>
</template>


 
<style>
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

a {
    display: inline-block;
    background-color: black;
    border: solid 1px black;
    color: white;
    padding: 5px;
    margin: 10px;
  }
  a:hover,
  a.router-link-active {
    background-color: rgb(110, 79, 13);
  }
  div {
    border: dashed black 1px;
    padding: 20px;
    margin: 10px;
    display: inline-block;
  }
</style>          