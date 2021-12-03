<template>
<div>
    <header>
        <b-container fluid class="header">
            <b-row>
                <b-col cols="2">
                    <router-link
                        :to="{name: 'home'}"
                    >                       
                    <img src="../../assets/mainlogo.png" alt="Func" id="logoHeader"> 
                    <a href="to"><p id="logoname">MathPlot</p></a>
                    </router-link>  
                </b-col>
                <b-col cols="8">
                    <div class="d-flex justify-content-center">
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
                </b-col>
                <b-col cols="2">
                    <div>
                        <div v-if="autorize === false" id="UserNotNull" >                  
                            <b-button @click="$bvModal.show('registrationsModal')" type="button" id="buttonSing" >Sing up</b-button>
                            <b-button @click="$bvModal.show('authModal')" type="button" id="buttonSing" style="margin-left:5px">Sing in</b-button>
                        </div>
                        <div v-if="User != null" id="UserNotNull">                  
                            <b-nav-item-dropdown right split style="list-style-type: none">
                            <template #button-content>
                                <b-img :src="require('../../UserImages/'+User['login']+'/'+User['imagePath'])" rounded="circle" v-bind="mainProps" v-if="User['imagePath'] != null"></b-img>
                                <b-img v-bind="defaultProps" rounded="circle" v-if="User['imagePath'] == null" ></b-img>
                            </template>

                            <router-link
                                tag="li"
                                :to="{name: 'ProfileUser', params:{login: logn}}"
                            >                      
                                <b-dropdown-item href="to">Профиль</b-dropdown-item>
                            </router-link>
                            <router-link
                                tag="li"
                                :to="{name: 'ChartsUser', params:{login: logn}}"
                            >                      
                                <b-dropdown-item href="to">Ваши графики</b-dropdown-item>
                            </router-link>
                            <b-dropdown-divider></b-dropdown-divider>
                            <b-dropdown-item v-on:click="logouts">Выйти</b-dropdown-item>
                            </b-nav-item-dropdown>
                        </div>
                    </div>
                </b-col>
            </b-row>
        </b-container>
    </header>

    <!-- Modal Sing UP -->
    <b-modal
        id ="registrationsModal"
        ref = "modal"
        title="Sing Up"
        hide-footer
        >
        <div class="container overflow-hidden">
            <div id="errors" class="alert alert-danger" style="display:none;"></div>
            <form id="registrationForm" @submit.prevent = "registerClick">
                <div class="form-group row ">
                    <div class="form-group col-md-6">
                        <label for="registrationInputFirstName">FirstName</label>
                        <input type="text" class="form-control" v-model="FirstName" id="registrationInputFirstName" placeholder="Enter FirstName">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputLastName">LastName</label>
                        <input type="text" class="form-control" v-model="LastName" id="registrationInputLastName" placeholder="Enter LastName">
                    </div>
                </div>
                <div class="form-group" id="modalrowsize">
                    <label for="registrationInputLogin">Login</label>
                    <input type="Login" class="form-control" v-model="Login" id="registrationInputLogin" placeholder="Enter Login">
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <legend class="col-form-label col-sm-2 pt-0">Genres</legend>
                        <div class="form-group row">
                            <div class="form-check col-md-6" style="margin-left:15px">
                                <input class="form-check-input" type="radio" name="IsMale" id="registrationRadioMale" value="true"  v-model="Genre" checked>
                                <label class="form-check-label" for="registrationRadioMale">
                                    Male
                                </label>
                            </div>
                            <div class="form-check col-md-4">
                                <input class="form-check-input" type="radio" name="IsMale" id="registrationRadioFemale" value="false"  v-model="Genre"  checked>
                                <label class="form-check-label" for="">
                                    Female
                                </label>
                            </div>
                            <input type="file" @change="onFileChange"/>
                        </div>
                    </div>
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <label for="registrationInputEmail">Email Address</label>
                        <input type="Email" class="form-control" id="registrationInputEmail" v-model="Email"  placeholder="Enter email">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputTelephone">Phone Number</label>
                        <input type="Phone" class="form-control" id="registrationInputTelephone"  v-model="Phone">
                    </div>
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <label for="registrationInputPassword">Password</label>
                        <input type="Password" class="form-control" id="registrationInputPassword" placeholder="Enter Password"  v-model="Password" >
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputPasswordReturn">Password</label>
                        <input type="Password" class="form-control" id="registrationInputPasswordReturn" placeholder="Enter Password">
                    </div>
                </div>
            </form>
        </div>
            <div class="modal-footer">
                <b-button type="submit" form="registrationForm" variant="secondary">Submit</b-button>
            </div>
    </b-modal>
    <!--Modal Sing Up-->
    <!-- Modal Sing IN -->
     <b-modal
        id ="authModal"
        ref = "modal"
        title="Sing in"
        hide-footer
        >
         <div class="container overflow-hidden">
             <div id="errorsLog" class="alert alert-danger" style="display:none;"></div>
                <form id="authForm">
                    <div class="form-group">
                        <label for="authInputEmail">Login</label>
                        <input type="Login" class="form-control" id="authInputEmail" placeholder="Enter Login" v-model="Login">
                    </div>
                    <div class="form-group" id="modalrowsize">
                        <label for="authInputPassword">Password</label>
                        <input type="Password" class="form-control" id="authInputPassword" placeholder="Enter Password" v-model="Password">
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <b-button type="button" form="authForm" variant="secondary" v-on:click="getTokenAsync">Submit</b-button>
            </div>
     </b-modal>
</div>
</template>

<script>
import { uuid } from 'vue-uuid';
var tokenKey = "accessToken";
var lg = "login";
export default{
    data(){
        return{
            Id: uuid.v1(),
            logn:  sessionStorage.getItem(lg),
            FirstName : "",
            LastName: "",
            Login: "",
            Genre: "true",
            Email: null,
            Phone: null,
            Password: "",
            file: null,
            User: null,
            mainProps: {width: 20, height: 20},
            defaultProps: { blank: true, blankColor: '#777', width: 20, height: 20 },
            autorize: sessionStorage.getItem(tokenKey) === null ? false:true,
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
    mounted(){
        if(this.autorize){
            this.GetUsers()
        }
    },
    methods:
    {
        async GetUsers(){
            const response = await fetch("http://localhost:56063/api/user/" + sessionStorage.getItem("login"),
            {
                method: "GET",
                headers: {"Accept": "application/json"}
            });
            if(response.status >=200 && response.status <= 299){
                this.User = await response.json()
            }
            else{
                console.log(response.status, response.statusText);
            }
        },
        async registerClick(){
           const response = await fetch("http://localhost:56063/api/user",
           {
               method: "POST",
               headers: {"Accept": "application/json", "Content-Type": "application/json"},
               body: JSON.stringify({
                    Id :this.Id,
                    FirstName : this.FirstName,
                    LastName: this.LastName,
                    Login: this.Login,
                    Genre: this.Genre == "true" ? true : false,
                    Email: this.Email,
                    Phone: (this.Phone == null || this.Phone == "") ? null :Number(this.Phone),
                    Password: this.Password,
                    ImagePath: null
               })
           });
           if(response.ok === true){
               console.log("ok");
                if(this.file != null){
                    let formdata = new FormData()
                    formdata.append('file',this.file)
                    formdata.append('login',this.Login)
                    console.log(formdata['file'],formdata['login'])
                    const response = await fetch("http://localhost:56063/api/UserImage", {
                        method: "PUT",
                        body: formdata
                    });
                    if(response.status >=200 && response.status <= 299){
                        this.User = await response.json()
                        console.log(this.User)
                    }
                    else{
                        console.log(response.status, response.statusText);
                    }
                }
           }
           else{
              const errorData = await response.json();             
              this.clearBox("errors");
              if(errorData.errors){
                  if(errorData.errors["Login"]){
                      this.addError(errorData.errors["Login"],"errors");
                  }
                   if(errorData.errors["FirstName"]){
                      this.addError(errorData.errors["FirstName"],"errors");
                  }
                   if(errorData.errors["LastName"]){
                      this.addError(errorData.errors["LastName"],"errors");
                  }
                 if(errorData.errors["Password"]){
                        this.addError(errorData.errors["Password"],"errors");
                   }                  
              }
              if(errorData["Login"]){
                 this.addError(errorData["Login"],"errors");
              }
              if(errorData["FirstName"]){
                 this.addError(errorData["FirstName"],"errors");
              }
              if(errorData["LastName"]){
                 this.addError(errorData["LastName"],"errors");
              }
              if(errorData["Password"]){
                 this.addError(errorData["Password"],"errors");
              }
              document.getElementById("errors").style.display = "block";
           }
        },
        addError(errors,elementid) {
            errors.forEach(error => {
                const p = document.createElement("p");
                p.append(error);
                document.getElementById(elementid).append(p);
            });
        },
        clearBox(elementID)
        {
            var div = document.getElementById(elementID);
            while(div.firstChild){
                div.removeChild(div.firstChild);
             }
        },
        async getTokenAsync(){
            const response = await fetch("http://localhost:56063/api/Auth",{
                method: "POST",
                headers: {"Accept": "appication/json","Content-Type": "application/json"},
                body: JSON.stringify({
                    login: this.Login,
                    password: this.Password
               })
            });
            if(response.ok === true){   
                const data = await response.json();
                sessionStorage.setItem(tokenKey,data.access_token);
                sessionStorage.setItem(lg,this.Login);
                window.location.reload();
            }
            else{
                const errorData = await response.json();             
                this.clearBox("errorsLog");
                if(errorData["Pass"]){
                    this.addError(errorData["Pass"],"errorsLog");
                }
                document.getElementById("errorsLog").style.display = "block";
           }
            
        },
        logouts(){
            sessionStorage.removeItem(tokenKey);
            sessionStorage.removeItem(lg);
            this.autorize = false;
            this.$router.push({ name: 'home' });
            window.location.reload();
        },
        onFileChange(e) {
            this.file = e.target.files[0];
        }

    }
}
</script>

<style>
#UserNotNull{
    position: absolute;
    right: 0;
}
</style>