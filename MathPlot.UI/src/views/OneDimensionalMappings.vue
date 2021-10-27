<template>
    <b-container fluid>
        <b-row>
            <b-col></b-col>
            <b-col cols="8">
                <h1 class = "d-flex justify-content-center" >Одномерные точечные отображения</h1>
                <h4>Общие свойства отображений</h4>
                <p>Точечными отображениями принято называть раздел динамики, в котором изучаются сиистемы
                    с дискретным "Временем". В этом случае оператор эволюции есть некоторая функция,
                    которая сопоставляет набор динамических переменных в $$x = {-b \\pm \\sqrt{b^2-4ac} \\over 2a}.$$
                </p>
                <vue-mathjax :formula="formula"></vue-mathjax>
            </b-col>
            <b-col></b-col>
        </b-row>
    </b-container>
</template>

<script>

</script>

