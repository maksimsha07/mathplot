<template>
     <footer id="footer">
        <b-container fluid >
              <b-row>
                <b-col style="text-align: center">
                  <router-link
                        :to="{name: 'home'}"
                    >                   
                    
                  
                    <a href="to"><p><img src="../../assets/mainlogo.png" alt="Func" id="logoFooter" align="middle"> MathPlot</p></a>
                    </router-link>
                    <div style="position: relative; top:-50px;">
                      <p>+79094352590</p>
                      <p>Info@mysite.com</p>
                    </div>
                </b-col>
                <b-col style="text-align: center">
                  <div>
                     <b-dropdown text="Графики" class="dropbutton">
                            <router-link
                            v-for="link in linksgraf"
                            :key="link.url"
                            tag="li"
                            :to="link.url"
                            >                      
                            <b-dropdown-item href="to" id="functionsLayouts">{{link.title}}</b-dropdown-item>
                            </router-link>
                        </b-dropdown>
                        <b-dropdown text="Теория"  class="dropbutton">
                            <router-link
                            v-for="link in linkstheory"
                            :key="link.url"
                            tag="li"
                            :to="link.url"
                            >                      
                            <b-dropdown-item href="to" id="functionsLayouts">{{link.title}}</b-dropdown-item>
                            </router-link>
                        </b-dropdown>
                  </div>
                </b-col >
                <b-col style="text-align: center">
                  <p style="margin-top:36px">Follow Us On:</p>
                  <b-icon icon="facebook" id="footerIcon"></b-icon>
                  <b-icon icon="instagram" id="footerIcon"></b-icon>
                  <b-icon icon="linkedin" id="footerIcon"></b-icon>
                </b-col>
              </b-row>
        </b-container>
     </footer>
</template>

<script>
  export default {
    data(){
      return{
        linksgraf:[
                {title:'Логистическое Отображение',url:'/MappLogistic'},
                {title:'Отображение Синус', url: '/MappSinus'},
                {title:'Отображение Гаусса', url:'/MappGaus'},
                {title:'Двусторонее отображение',url:'/MappTwoStor'},
                {title:'Отображение планка',url:'/MappPlank'},
            ],
        linkstheory: [
            {title:'Одномерные точечные отображения', url: '/OneDimensionalMappings/0'},
            {title:'Двумерные точечные одображения', url: '/TwoDimensionalMappings/0'}
        ]
      }
    },
    name: 'FooterPage',
    components: {
    }
  }
</script>

<style>
#footerIcon{
  position: relative;
  top:-15px;
  color: aqua;
  width: 25px;
  height: 25px;
  padding-right: 5px;
}
</style>