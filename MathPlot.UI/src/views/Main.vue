<template>
      <canvas id="myChart" width="628" height="400"></canvas>
</template>

<script type="text/javascript">
  //Готовим диаграмму
  var Chart = require('chart.js');
 function Diagram () {
  var ctx = document.getElementById("myChart");
  var myChart = new Chart (ctx, {
   type: 'line',
   data: {
    labels: [], //Подписи оси x
    datasets: [
     {
      label: 'f(x)', //Метка
      data: [], //Данные
      borderColor: 'blue', //Цвет
      borderWidth: 2, //Толщина линии
      fill: false //Не заполнять под графиком
     }
     //Можно добавить другие графики
    ]
   },
   options: {
    responsive: false, //Вписывать в размер canvas
    scales: {
     xAxes: [{
      display: true
     }],
     yAxes: [{
      display: true
     }]
    }
   }
  });
  //Заполняем данными
  for (var x = 0.1; x<=4.9; x+=0.1) {
   myChart.data.labels.push(''+x.toFixed(2));
   myChart.data.datasets[0].data.push(f(x).toFixed(10));
  }
  //Обновляем
  myChart.update();

  function f(x) { //Вычисление нужной функции
   return (4*Math.pow(x,3))/(1+Math.exp(x));
  }
 }

 //Ставим загрузку диаграммы на событие загрузки страницы
 window.addEventListener("load", Diagram); 
var r = 4;
const N = 1000;
let x = [];
let y = [];
let i = 0.0;
while(i<N){
    x.push(i);
    i = i+0.1;
}
for(let i = 0;i<x.length;i++){
    y[i] = (r*x[i]^3)/(1+Math.exp(x[i]));
}
</script>

<style>
  .small {
    max-width: 600px;
    margin:  150px auto;
  }
</style>