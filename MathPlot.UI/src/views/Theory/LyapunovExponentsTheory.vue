<template>
     <b-container fluid>
        <b-row>
            <b-col></b-col>
            <b-col cols="8">
                <h4>Показатель Ляпунова</h4>
                <p>
                    Очень эффективным способом оценки «хаотичности» является рассмотрение такой величины 
                    как <em>показатель Ляпунова</em>. Это показатель, который определяет
                    димости траектории, т.е. характер изменения траектории в зависимости от изменения
                    начального условия.
                </p>
                <p>
                    Система называется <em>устойчивой по Ляпунову</em>, если две траектории, стартовавшие
                    из близких начальных точек, остаются близкими в любой последующий момент
                    времени. Далее мы опишем это условие математически.
                </p>
                <p>
                    Динамическая система, как уже упоминалось выше, может быть задана обыкновенным дифференциальным уравнением вида
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\frac{d\vec{x}}{dt}=F(\vec{x})">(11)
                </div>
                <p>Рассмотрим одномерный случай. В этом случае уравнение (11) запишется как:</p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\dot{x}=F(x)">(12)
                </div>
                <p>
                    Пусть <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_0(t)"> - это некоторое решение уравнения (12), а
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y(t)"> - это отклонение от начальной траектории, реалезующееся в результате
                    выбора другого начального условия. В результате получаем, что <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x(t)=x_0(t)+y(t)">. Подставим
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x(t)"> в формулу (12) и разложим правую часть в ряд:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\frac{dx_0}{dt}%2B\frac{dy}{dt}=F(x_0)%2B(\frac{\partial F}{\partial x})_{x=x_0}\cdot y %2B ...">
                </div>
                <p>Ограничиваясь линейным приближением, получаем</p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\frac{dy}{dt}=(\frac{\partial F}{\partial x})_{x=x_0}\cdot y %2B ...">(13)
                </div>
                <p>Решение уравнения (13) запишется следующим образом:</p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y=y(0)\cdot e^{\Lambda t}">,
                </div>
                <p>где <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y(0)"> - начальное смещение</p>
                <p>
                    Получаем, что при <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda >0"> траектория <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x(t)">
                    будет экспоненциально расходиться с траектории <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_0(t)">. Если же 
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda <0">, то, напротив, траектории будет со временем сближаться. Показатель степени экспоненты
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda"> называется <em>показателем Ляпунова</em> и определяется как:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda = \lim\limits_{t\to \infty} \frac{1}{t}\cdot ln|\frac{y(t)}{y(0)}|">(14)
                </div>
                <p>
                    Обобщая данный результат на случай многомерного фазового пространства и вводя <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\vec{y}(0)"> - 
                    вектор начального смещения, можем записать следующее:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda(\vec{y}(0)) = \lim\limits_{t\to \infty} \frac{1}{t}\cdot ln|\frac{\vec{y}(t)}{\vec{y}(0)}|">(15)
                </div>
                <p>
                    При всех возможных поворотах вектора <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\vec{y}(0)"> в (15) <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda(\vec{y}(0))"> будет давать набор
                    дискретных значений. Причем количество возможных значений будет соответствовать размерности фазового пространства. Набор чисел <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\{\Lambda_1, \Lambda_2,...,\Lambda_N\}">
                    называют <em>спектром ляпуновских показателей</em>. Очевидно, что если в наборе присутствует хотя бы один положительный показатель, то система по данному направлению фазового пространства неустойчива. Если все показатели отрицательны,
                    то система устойчива. Равенство нулю показателя Ляпунова обычно свидетельствует о недостаточности линейного анализа устойчивости.
                </p>
                <p>
                    Показатели Ляпунова чрезвычайно полезны при описании различных динамических систем, и возможности использования этого подхода весьма широки
                </p>
                <p>
                    Для одномерных отображений формулу (14) после математических упрощений
                    можно записать в виде:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\Lambda = \lim\limits_{n\to \infty} \frac{1}{n}\sum^n_i ln|f^'(x_i)|">(16)
                </div>
                <p>
                    Для расчета показателя Ляпунова в случае одномерного отображения можно восспользоваться следующим алгоритмом:
                    <ol>
                        <li>Вычисляется последовательность <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n">
                            для какого-то начального значения <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_0">.
                            Рекомендуется выбирать достаточко большое <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n">, т.к. в формуле (2)
                            предполагается, что <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n"> стремится к бесколечности.
                        </li>
                        <li>
                            Далее, берется производная от функции отображения <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=f">, и точки из набора
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n"> отображается в другой набор <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n^'">
                            по правилу <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n^'=f^'(x_n)">
                        </li>
                        <li>
                            Производится суммирование по всем прологарифмированным членам полученной последовательности, и полученная сумма делится на <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n">.
                        </li>
                    </ol>
                </p>
                <p>
                    На Рис. 8 построена зависимость показателя Ляпунова для логистического отображения от управляющего параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">.
                </p>
                <div style="text-align: center">
                    <img src="../../assets/paint_8.png">
                </div>
                <p>
                    Обратим внимание, что показатель Ляпунова на Рис. 8 обращается в ноль при тех
                    же самых значениях параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">, что и точки бифуркации удвоения периода,
                    возникавшие на Рис. 5. Это говорит о том, что при помощи зависимости показателя Ляпунова
                     от управляющего параметра можно не только определять устойчивость системы, но и выявлять точки бифуркации.
                </p>
                <p>
                    Как оказалось, анализировать столь специфический класс динамических систем, поведение которых описывают одномерные отображения, даже для простых моделей
                    не так-то просто. Однако интересно, что методы, применяемые здесь, оказываются
                    полезными и при анализе явлений, возникающих в более сложных моделях.
                </p>
                <div style="text-align: center">
                    <router-link
                        to="/OneDimensionalMappings/2"
                        >                      
                        <a href="#" id="functionsLayouts">Назад</a>
                    </router-link>
                </div>
                <form id="commentForm">
                    <div v-if ="autorize === true" class="form-group row">
                        <div class="form-group col-md-10">
                            <input type="text" class="form-control" v-model="newComment">
                        </div>
                        <div class="form-group col-md-2">
                            <b-button type="button" v-on:click="addComment" form="commentForm" variant="secondary">Submit</b-button>
                        </div>
                    </div>
                    <div v-if="autorize === false">
                        <p>Авторизируйтесь, чтобы оствлять комментарии</p>
                    </div>
                </form>
                <div v-if="comments != null">
                    <div  style="display: inline" id="comments">
                        <div style="display: flex;" v-for="comment in  comments" :key="comment.id">
                            <b-img :src="require('../../UserImages/'+comment.login+'/'+comment.imagePath)"
                            rounded="circle" 
                            v-bind="mainProps" 
                            v-if="comment.imagePath != null"></b-img>
                            <b-img v-bind="defaultProps" rounded="circle" v-if="comment.imagePath == null"></b-img>
                            <p>{{comment.login}}:{{comment.comment}}</p>
                        </div>
                    </div>
                </div> 
            </b-col>
            <b-col></b-col>
        </b-row>
     </b-container>
</template>

<script>
export default{
     data(){
        return{
            newComment: "" ,
            pageName: "LyapunovExponentsTheory",
            autorize: sessionStorage.getItem("accessToken") === null ? false:true,
            comments: null,
            mainProps: {width: 40, height: 40},
            defaultProps: { blank: true, blankColor: '#777', width: 40, height: 40 }
        }
    },
    methods:{
        async addComment(){
             const response = await fetch("http://localhost:56063/api/commented",
           {
               method: "POST",
               headers: {"Accept": "application/json", "Content-Type": "application/json"},
               body: JSON.stringify({
                   userName: sessionStorage.getItem("login"),
                   pageName: this.pageName,
                   commentText: this.newComment
               })
           });
           if(response.ok === true){
               console.log(response.json());
               this.addCommentInDOM()
           }
           else{
                const errorData = await response.json();             
                console.log("errors",errorData);
           }
        },
        async getComments(){
             const response = await fetch("http://localhost:56063/api/commented/"+this.pageName,
            {
                method: "GET",
                headers: {"Accept": "application/json"}
            });
            if(response.status >=200 && response.status <= 299){
                return await response.json();               
            }
            else{
                console.log(response.status, response.statusText);
            }
        },
        async addCommentInDOM(){
            this.comments = await this.getComments();           
        }
    },
    beforeMount(){
        this.addCommentInDOM()
    }
}
</script>

<style>
   p {
    margin-top: 0em; /* Отступ сверху */
    margin-bottom: 0em; /* Отступ снизу */
   }
   th,td{
       border: 1px solid black;
   }
</style>