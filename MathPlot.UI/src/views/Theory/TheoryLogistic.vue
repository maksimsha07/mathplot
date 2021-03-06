<template>
     <b-container fluid id="mainMappingInfoTheory">
        <b-row>
            <b-col></b-col>
            <b-col cols="8" id="mainTheoryinfo">
                <h4>Логистическое отображение</h4>
                <p>
                   Логистическое (или <em>квадратичное</em>) отображение – это одно из самых известных
                   отображений, которое демонстрирует хаотическую динамику, и оно выражается
                   удивительно простым законом. Этот закон имеет в литературе несколько 
                   различных модификаций, сводящихся друг к другу, мы остановимся на таком варианте: 
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_{n%2B1}=f(x_n)=rx_n(1-x_n)"> (8)
                </div>
                <p>
                    Функция, стоящая в правой части формулы (8), связана с именем бельгийского
                    математика Пьера Ферхюльста, который в первой половине 19-го века предложил ее
                    в качестве модели для скорости изменения численности популяции с учетом
                    борьбы особей за ограниченные ресурсы или место обитания (в дополнение к известной теории 
                    народонаселения Мальтуса). Мы рассмотрим дискретный аналог
                    дифференциального логистического уравнения Ферхюльста. В этом случае
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n"> - это
                    нормированная численность популяции некоторого вида в какой-то момент времени (например, в какой-то год), а
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_{n%2B1}"> это численность того же вида в следующий 
                    год. Значение 𝑥 меняется в пределах от 0 до 1, а в качестве <em>управляющего параметра</em> выступает 𝑟 – величина, меняющаяся от 0 до 4, 
                    характеризующая скороста популяции («рождаемость минус смертность»).
                </p>
                <div style="text-align: center">
                    <img src="../../assets/paint_2.png">
                </div>   
                <p>
                    На Рис. 2 и Рис. 3 с помощью уже знакомой лестницы Ламерея показано, как
                    происходит отображение одних точек в другие.
                </p>
                <p>
                    <ol>
                        <li>
                            От начальной точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;0)"> следует двигаться вертикально к линии
                            отображения. Записывается точка пересечения с линией <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;x_1)">, где
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1"> получена в результате итерации <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1=f(x_0)">
                        </li>
                        <li>
                            От точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;x_1)"> нужно переходить по горизонтали к точке <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_1;x_1)"><div class=""></div>
                            Совокупность точек, в которых обе координаты равны, – это биссектриса первой четверти, следовательно, горизонтальная линия должна соединять кривую отображения с биссектрисой.
                        </li>
                        <li>
                            От биссектрисы снова строится вертикальная линия до пересечения с кривой отображения, т.е. к точке 
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_1;x_2)">, где <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_2"> получена в результате итерации 
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_2=f(x_1)"> и повторяются пункты, начиная со второго.
                        </li>
                        <li>
                            От начальной точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;0)"> следует двигаться вертикально к линии
                            отображения. Записывается точка пересечения с линией <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;x_1)">, где
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1"> получена в результате итерации <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1=f(x_0)">
                        </li>
                        <li>
                            От точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_0;x_1)"> нужно переходить по горизонтали к точке <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_1;x_1)"><div class=""></div>
                            Совокупность точек, в которых обе координаты равны, – это биссектриса первой четверти, следовательно, горизонтальная линия должна соединять кривую отображения с биссектрисой.
                        </li>
                        <li>
                            От биссектрисы снова строится вертикальная линия до пересечения с кривой отображения, т.е. к точке 
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=(x_1;x_2)">, где <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_2"> получена в результате итерации 
                            <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_2=f(x_1)"> и повторяются пункты, начиная со второго.
                        </li>
                    </ol>                   
                </p>
                <div style="text-align: center">
                    <img src="../../assets/paint_3.png">
                </div>
                <div style="text-align: center">
                    <img src="../../assets/paint_4.png">
                </div>
                <p>
                    В конечном счете получается похожая на "лестницу" ломаная линия, по которой
                    очень легко наблюдать, как отображение приходит к притягивающим точкам или
                    к устойчивым циклам.
                </p>
                <p>
                    Наблюдая за тем, как выглядит лестница Ламерея при различных значениях параметра 𝑟
                    , мы можем увидеть, что при определенных значениях параметра меняется
                    результат построения лестницы. Такое изменение можно назвать <em>бифуркацией</em>.
                </p>
                <p>
                    Термин бифуркация означает смену установившегося режима поведения системы, как правило,
                     вследствие изменения управляющего параметра. Момент такой смены называют <em>точкой бифуркации</em>.
                </p>
                <p>
                    Например, в логистическом отображении при переходе управляющего параметра 𝑟
                    через начальное <em>критическое значение</em> <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_0 = 1"> неподвижная
                    <em>устойчивая точка</em> <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_1^*=0"> теряет свою устойчивость, и рядом
                    с ней возникает новая неподвижная <em>устойчивая</em> точка <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*_2=1-1/r">(см. Рис. 2.).
                    Далее при увеличении управляющего параметра, при <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_1 = 3"> уже
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x^*_2"> становится неустойчивой, а вокруг нее возникает устойчивый (его также называют <em>предельный</em>)
                    цикл с периодом 2 (см. Рис. 3.). При следующем критическом значении <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_2 = 1%2B\sqrt{6}\approx 3.45">
                    уже цикл с периодом 2 становится неустойчивым, и появляется устойчивый цикл с периодом 4. Такие изменения называют бифуркациями удвоения периода.
                </p>
                <div style="text-align: center">
                    <router-link
                        to="/OneDimensionalMappings/0"
                        >                      
                        <a href="#" id="functionsLayouts">Назад</a>
                    </router-link>
                    <router-link
                        to="/OneDimensionalMappings/2"
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
            pageName: "TheoryLogistic",
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
        },
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