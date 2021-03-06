<template>
    <b-container fluid id="mainMappingInfoTheory">
        <b-row>
            <b-col></b-col>
            <b-col cols="8" id="mainTheoryinfo">
                <h1 class = "d-flex justify-content-center" >Одномерные точечные отображения</h1>
                <h4>Общие свойства отображений</h4>
                <p>Точечными отображениями принято называть раздел динамики, в котором изучаются сиистемы
                    с дискретным "Временем". В этом случае оператор эволюции есть некоторая функция,
                    которая сопоставляет набор динамических переменных в
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\vec{x}_{n%2B1}=\vec{f}(\vec{x}_n)"> (1)
                </div>
                <p>где
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\vec{x}_{n}">
                    - вектор состояния, компонентами которого являются значения динамичесих переменных в момент времени
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n">, а под 
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=f"> понимается
                    некоторое преобразование вектора, позволяющее получить новое состояние в следующий момент
                    времени. Заметим, что даже относительно простые отображения с одной динамической переменной могут демонстрировать сложную динамику. В некоторых
                    случаях эти одномерные точечные отображения ведут себя хаотическим образом, поэтому их часто используют для наглядной демонстрации аппарата анализа нелинейных систем.
                </p>
                <p>
                    Обычно с хаосом связывают непериодические (и неквазипериодические!) случайные сложные процессы с
                    непредсказуемым поведением. Однако в нелинейных системах возможен т.н. <em>детерминированный хаос</em>. В этом устоявшемся понятии
                    связано два, казалось бы, противоположных свойства: хаос и детерминированность, ведь последнее означает полную предопределенность системы.
                    Детерминированным хаосом называют такой режим поведения системы, в котором
                    поведение детерминированной (определенной какими-нибудь уравнениями или
                    отображением) системы непредсказуемо в том смысле, что незначительное изменение начальных данных приводит к значительным изменениям в
                    ходе эволюции системы. Оказалось, что детерминированный хаос может возникать не
                    только в сложных, многомерных системах, которые обладают неустойчивостью
                    к начальным условиям, но и в системах, описываемых одномерными отображениями
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_{n%2B1}=f(x_n)"> (2)
                </div>
                <p>
                    Свойства одномерных отображений обычно демонстрируют 
                    при помощи различных средств, таких как построение лестницы
                    Ламерея, бифуркационные диаграммы или спектр показателей Ляпунова.
                </p>
                <p>
                    Важными для понимания свойств отображений (2) являются понятия неподвижных точек разной кратности, циклы, их устойчивость.
                </p>
                <p>
                    <em>Неподвижная точка</em> <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*">
                    переходит сама в себя под действием отображения (2), то есть удовлетворяет соотношению
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*=f(x^*)"> (3)
                </div>
                <p>Неподвижная точка является <em>устойчивой</em>, если в данной точке выполнено условие</p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=|f^'(x^*)|<1"> (4)
                </div>
                <p>
                    где  <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=f^'(x^*)"> - значение производной функции
                    отображения в точке  <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*">. Стоит отметить, что 
                    устойчивую точку  <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*"> нередко называют <em>притягивабщей</em>.
                </p>
                <p>
                    Если, стартуя из точки  <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*">, в результате m-кратного выполнения отображения
                     <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=f(x)">, получается то же самая точка <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*">
                     , говорят, что <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*"> - неподвижная точка кратности m. Формально это записывается как
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*=\overbrace{f(f(...f(x_1^*)...))}^{m}=f^m(x^*_1)"> (5)
                </div>
                <p>
                    Правая часть уравнения (5) представляет из себя последовательное m-кратное выполнение отображения.
                    Дальнейшее выполнение отображения приведет к тому же результату, поэтому последовательность
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_2^*=f(x_1^*),x_3^*=f(x_2^*),...x_{m%2B1}^*=f(x_m^*)=x_1^*">
                    называются <em>циклом порядка</em> m. Каждая точка данной последовательности является неподвижной точкой кратности m.
                </p>
                <p>Цикл порядка m является устойчивым в случае выполнения следующего условия:</p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=|f^'(x_1^*)\cdot ...\cdot f^'(x^*_{m-1})\cdot f^'(x^*_m)|<1"> (6)
                </div>
                <p>
                    Неравенство (6) легко получить, рассмотрев вопрос об устойчивости точки 
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*"> 
                    в отображении <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=f^m(x_1^*)">, как сложной функции, с учетом формулы (5)
                </p>
                <p>
                    Проанализировать поведение (2) на плоскости можно с помощью диаграммы
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_{n%2B1}(x_n)">(см. Рис. 1). Для такого анализа
                    важное значение имеет биссектриса первого и третьего квадрантов 
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_{n%2B1}=x_n"> (7)
                </div>
                <p>
                    Во-первых, пересечение биссектрисы 
                     <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y=x">
                     и функции  <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y = f(x)">
                     дает неподвижные точки, а, во-вторых, поскольку производная по 𝑥 у биссектрисы равна 
                     единице, визуально легко определить устойчивость неподвижной точки.
                </p>
                <p>
                    На Рис. 1 приведена диаграмма произвольного отображения, которая изображена
                    фиолетовым цветом. Зеленым цветом представлена биссектриса
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=y=x">, а точки пересечения этой
                    биссектрисы с графиком отмечены кружками. Эти точки являются неподвижными: красная
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{'}}"> - устойчивой, а синее
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{''}}"> и
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*}"> - неустойчивыми.
                </p>
                <p>
                    Красный штриховой квадрат, около точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{''}}">
                    , обозначает предельный цикл второго порядка. Как видим, ему соответствуют точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{(1)}}"> и <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{(2)}}">
                </p>
                <p>
                    На Рис. 1 также приведен пример построения <em>лестницы Ламерея</em>. Это иллюстративный метод, с
                     помощью которого удобно демонстрировать, какие точки являются притягивающими, а какие нет. Видно, что, начиная из точки
                     <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_0"> в итоге можно прийти в точку
                     <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*{'}}">, а , стартовав с <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^'_0">
                     придем к циклу <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^{*^{(1)}}-x^{*^{(2)}}">.
                </p>
                <div style="text-align: center">
                    <img src="../../assets/paint_1.png">
                </div>   
                <p>
                    Алгоритмы перечисленных выше методов будут ниже обсуждены на конкретных
                    примерах динамических систем. В качестве «базовой» была выбрана система,
                    динамика которой задается <em>логистическим отображением</em>.
                </p>
                <div style="text-align: center">
                     <router-link
                            to="/OneDimensionalMappings/1"
                            >                      
                            <a href="#" id="functionsLayouts">Далее</a>
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
            pageName: "OneDimensionalMappings",
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
</style>

