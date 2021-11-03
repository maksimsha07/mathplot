<template>
     <b-container fluid>
        <b-row>
            <b-col></b-col>
            <b-col cols="8">
                <h4>Бифуркационные диаграммы</h4>
                <p>
                    Одним из способов исследования отображений является построение <em>бифуркационной диаграммы</em>. Такая диаграмма демонстрирует,
                     как меняется поведение системы в зависимости от управляющего параметра. В случае одномерного отображения это делается довольно просто. 
                     Для данного значения управляющего параметра находятся все значения неподвижных точек и возможных предельных
                     циклов, т.е. все значения, к которым может перейти система после большого числа итераций
                </p>
                <p>
                    Для построения бифуркационной диаграммы рекомендуется воспользоваться
                    следующим алгоритмом:
                    <ol>
                        <li>
                            Стартуя из произвольной начальной точки <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_0"> и выбрав какое-то <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">,
                             в результате итераций получаем значения <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n=\{\ x_1,x_2,x_3 ... \}">. Число итераций выбирается достаточно большим (порядка тысячи).
                        </li>
                        <li>
                            Из всего набора <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x_n">  оставляется несколько последних, например,
                             20-100 значений. Эти значения записываются вместе со значением <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">.
                        </li>
                        <li>
                            То же самое проделывается и для других случайных точек и того же <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">.
                        </li>
                        <li>
                            Пункты 1 и 2 повторяются для другого значения <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">.
                        </li>
                        <li>
                            Записанные числа отображаются в зависимости от <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">. То есть на экране
                            должны появиться все точки, которые были записаны при данном <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">.
                        </li>
                    </ol>                       
                </p>
                <p>
                    На Рис. 5 приведена бифуркационная диаграмма логистического отображения, на
                    которой видно, что при малых значениях параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r"> система имеет лишь одну
                    устойчивую неподвижную точку, однако при увеличении <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r"> сначала система образует цикл второго порядка, затем четвертого и вскоре демонстрирует хаос.
                </p>
                <div style="text-align: center">
                    <img src="../assets/paint_5.png">
                </div>
                <p>
                    Как показано на бифуркационной диаграмме, изменение управляющего параметра влечет <em>каскад
                    бифуркаций удвоения периода</em>. Это означает, что при увеличении управляющего параметра
                    и достаточно большом числе итераций отображение переходит сначала в устойчивую точку,
                    затем в цикл с периодом два, потом в цикл с периодом 4 и так далее. Такой процесс называют переходом к хаосу
                    через бесконечную последовательность бифуркаций удвоения периода. Этот
                    сценарий перехода к хаосу называют <em>сценарием Фейгенбаума</em>.
                </p>
                <p>
                    Митчел Фейгенбаум, в честь которого был назван сценарий, описанный выше,
                    заметил интересную особенность логистического отображения. Оказалось,
                    критические значения параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r">, которые принято записывать как <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_k">, образуют
                    последовательность, которая стремится к некоторому значению <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_{\infty}">. Приведем
                    несколько начальных критических значений:
                </p>
                <p>
                    <table border = "1" width="100%" cellpadding="5">
                        <tr>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_1"></th>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_2"></th>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_3"></th>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_4"></th>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_5"></th>
                            <th>...</th>
                            <th><img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_{\infty}"></th>
                        </tr>
                        <tr>
                            <td>3,0</td>
                            <td>3,449949...</td>
                            <td>3,54409...</td>
                            <td>3,568759...</td>
                            <td>3,569692...</td>
                            <td>...</td>
                            <td>3,5699457...</td>
                        </tr>
                    </table>
                </p>
                <p>
                    Оказалось, что последовательность <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_k">
                    подчиняется следующему соотношению:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\lim\limits_{k\to \infty} \frac{r_k-r_{k-1}}{r_{k%2B1}-r_k}=\delta=4,669209..."> (9)
                </div>
                <p>
                    Константа <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\delta"> характеризует скорость сходимости критических значений
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_k"> к пределу <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r_{\infty}">.
                    Константа <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\delta"> называется <em>универсальной постоянной Фейгенбаума</em>. Как
                    показали исследования, величина <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\delta"> не зависит от конкретного вида отображения,
                    главное, чтобы оно было унимодальным (имело один экстремум).
                </p>
                <p>
                    <img src="../assets/paint_6.png" style="float: right">
                    Получается, что любое отображение, испытывающее каскад бифуркаций удвоения периода, переходит к хаосу с одинаковой скоростью.
                </p>
                <p>
                    На этом интересные свойства логистического отображения не заканчиваются.
                    Определим на бифуркационной диаграмме расстояния относительно <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=x = 0.5">
                    между подобными ветвями диаграммы и
                    обозначим расстояния как <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=d_k">, как это показано на Рис. 6. Этот процесс называют
                    <em>дроблением масштабов</em>.            
                </p>
                <p>
                    Полученные значения <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=d_k"> образуют последовательность, которая обладает следующим свойством:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\lim\limits_{k\to \infty} \frac{d_k}{d_{k%2B1}}=\alpha=-2,502907..."> (10)
                </div>
                <p>
                    Постоянная <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=\alpha"> называется <em>универсальным масштабным множителем</em>
                </p>
                <p>
                    Помимо хаотических траекторий, логистическое отображение имеет в области
                    параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r>r_{\infty}"> множество периодических траекторий. Среди них можно
                    найти траектории с периодом 3 , 5 или 7 . Это подтверждает <em>теорему Ли и Йорке</em>,
                    известную под названием «период три рождает хаос», которая говорит, что если
                    в системе существует цикл периода 3, то в ней имеется и набор начальных условий, который приводит к хаотической динамике.
                </p>
                <p>
                    Одномерные отображения, реализующие циклы с периодом три, имеют также
                    циклы с любым другим числом периодов. Об этом гласит <em>теорема Шарковского</em>.
                    Её более точная формулировка такая: если непрерывное отображение одномерного
                     интервала в себя имеет цикл периода <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n">, то оно имеет также и циклы со всевозможными периодами <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=m">, 
                     которые находятся справа от <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=n"> в ряду:
                </p>
                <div style="text-align: center">
                    <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=3,5,7,9,...,2\cdot3 , 2\cdot 5, 2\cdot 7,2\cdot9,...,2^2\cdot3,2^2\cdot5,2^2\cdot7, 2^2\cdot9,...2^3\cdot3,2^3\cdot5,2^3\cdot7, 2^3\cdot9,...,2^4\cdot3,2^4\cdot5,2^4\cdot7, 2^4\cdot9,...,2^3,2^2,2^1,1">
                </div>
                <p>
                    Приведенный ряд натуральных чисел называется <em>порядком Шарковского</em> и представляет собой упорядоченный натуральный ряд.
                </p>
                <p>
                    На Рис. 7 можно убедиться в том, что в бифуркационной диаграмме логистического отображения возникают так называемые «окна периодичности» в области
                    параметра <img src="https://chart.googleapis.com/chart?cht=tx&amp;chl=r>r_{\infty}">. На рисунке выделены значения параметра, при котором
                    можно наблюдать соответствующие периоды.
                </p>
                <div style="text-align: center">
                    <img src="../assets/paint_7.png">
                </div>
                <div style="text-align: center">
                    <router-link
                        to="/OneDimensionalMappings/1"
                        >                      
                        <a href="#" id="functionsLayouts">Назад</a>
                    </router-link>
                    <router-link
                        to="/OneDimensionalMappings/3"
                        >                      
                        <a href="#" id="functionsLayouts">Далее</a>
                    </router-link>
                </div>
                <form id="commentForm">
                    <div v-if ="autorize === true" class="form-group row">
                        <div class="form-group col-md-10">
                            <input type="text" class="form-control" v-model="Comment">
                        </div>
                        <div class="form-group col-md-2">
                            <b-button type="button" v-on:click="addComment" form="commentForm" variant="secondary">Submit</b-button>
                        </div>
                    </div>
                    <div v-if="autorize === false">
                        <p>Авторизируйтесь, чтобы оствлять комментарии</p>
                    </div>
                </form>
                <div id="comments"></div>    
            </b-col>
            <b-col></b-col>
        </b-row>
     </b-container>
</template>

<script>
export default{
     data(){
        return{
            Comment: "" ,
            pageName: "BifurcationTheory",
            autorize: sessionStorage.getItem("accessToken") === null ? false:true      
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
                   commentText: this.Comment
               })
           });
           if(response.ok === true){
               console.log(response.json());
               const p = document.createElement("p");
                p.append(sessionStorage.getItem("login")+":"+ this.Comment);
                document.getElementById("comments").append(p);
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
            const comments = await this.getComments();
            console.log(comments);
            this.clearBox("comments");           
            comments.forEach(comment => {
                const p = document.createElement("p");
                p.append(comment);
                document.getElementById("comments").append(p);
            });
        },
        clearBox(elementID)
        {
            var div = document.getElementById(elementID);
            while(div.firstChild){
                div.removeChild(div.firstChild);
             }
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